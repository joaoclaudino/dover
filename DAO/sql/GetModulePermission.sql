﻿SELECT 
	Code AddinCode
	, U_Name AddInName
	, U_Status PermissionStr 
from 
	[@DOVER_MODULES] 
where 
	U_Type = 'A' and U_DueDate > GETDATE()