SELECT CASE WHEN EXISTS (
SELECT 1 
FROM [PortalPageDefinitions] 
WHERE [ModelName] = @PRM_PortalPageDefinition_ModelName ) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END