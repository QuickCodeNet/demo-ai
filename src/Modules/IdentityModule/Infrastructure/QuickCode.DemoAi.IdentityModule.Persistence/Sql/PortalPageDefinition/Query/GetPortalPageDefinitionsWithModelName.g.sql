SELECT [Key], [ModuleName], [ModelName], [PageAction], [PagePath] 
FROM [PortalPageDefinitions] 
WHERE [ModelName] = @PRM_PortalPageDefinition_ModelName 
ORDER BY [Key] 