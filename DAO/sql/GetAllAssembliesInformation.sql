﻿SELECT 
    Code
    , U_Namespace Namespace
    , U_Name Name
    , ISNULL(U_Description, U_Name) Description
    , U_FileName FileName
    , U_Version Version
    , U_MD5 MD5
    , U_Date Date
    , U_Size Size
    , U_Type TypeCode 
FROM 
    [@DOVER_MODULES]
where 
    U_Type = '{0}'