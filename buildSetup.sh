#!/bin/bash
export fulltag=$(git describe --tags)
export tag=$(echo $fulltag | sed s/-/./ | sed s/-.*//)
export dots=${tag//[^.]}

if [ ${#dots} -lt 3 ]
then
    tag=$tag".0"
fi

MSBuild.exe AddOnInstallAPI/AddOnInstallAPI.sln //p:Configuration=Release
MSBuild.exe Dover.sln //p:Configuration=Release //p:Platform=x64

cp AddOnInstallAPI/bin/Release/AddOnInstallAPI.exe Core/bin/x64/Release
cp Install/Doverx64.iss Core/bin/x64/Release
pushd .
cd Core/bin/x64/Release
iscc Doverx64.iss
popd

echo "Creating ard file for $fulltag on branch $branch - git_branch $GIT_BRANCH"

rm -rf build

export setup_dir=build/x64/setup
export exe_dir=build/x64/exe
export dll_dir=build/x64/dll

mkdir -p $exe_dir
mkdir -p $dll_dir
mkdir -p $setup_dir

cp -a Core/bin/x64/Release/*.exe $exe_dir
echo "JBC-1"

cp -a Core/bin/x64/Release/*.dll $dll_dir
echo "JBC-2"

cp -a Core/bin/x64/Release/pt-BR $dll_dir
echo "JBC-3"

mkdir -p Core/bin/x64/Release/Output


echo $setup_dir
cp -a Core/bin/x64/Release/Output/mysetup.exe $setup_dir
echo "JBC-4"


rm -rf temp
echo "JBC-5"
mkdir temp
echo "JBC-6"
cp Install/Doverx64.xml temp
echo "JBC-7"
cp $setup_dir/mysetup.exe temp
echo "JBC-8"
cp $exe_dir/Dover.exe temp
echo "JBC-9"



echo $tag
echo "JBC-9"

cd temp
AddOnRegDataGen Doverx64.xml $tag mysetup.exe myssetup.exe Dover.exe
cd ..

echo $setup_dir

mv temp/Doverx64.xml $setup_dir
<<COMMENT1
COMMENT1
