SELECT [Key], [ModuleName], [ModelName], [HttpMethod], [ControllerName], [MethodName], [UrlPath] 
FROM [ApiMethodDefinitions] 
WHERE [ModelName] = @PRM_ApiMethodDefinition_ModelName 
ORDER BY [Key] 