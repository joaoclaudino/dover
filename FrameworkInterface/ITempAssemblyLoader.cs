using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dover.Framework.Interface
{
    public interface ITempAssemblyLoader
    {
        List<Model.AssemblyInformation> GetAssemblyInfoFromBin(byte[] asmBytes, Model.AssemblyInformation asmInfo);
    }
}
