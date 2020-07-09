SELECT "Code", "U_Namespace" AS "Namespace", "U_Name" AS "Name", "U_Description" AS "Description","U_Version" AS "Version", 
    CASE 
        WHEN "U_Type" = 'C' THEN 'Core' 
        ELSE 'AddIn' 
    END AS "Type", "U_Installed" AS "Installed", 'S' AS "Status", '...' AS "History" 
FROM "@DOVER_MODULES"
WHERE "U_Type" in ('C', 'A')
ORDER BY "Code"
