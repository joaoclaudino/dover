﻿select U_Name Name, U_Version Version, case when U_Type = 'C' THEN 'Core' else 'AddIn' End Type, U_Installed Installed, 'S' Status, '...' History from [@DOVER_MODULES] order by Code