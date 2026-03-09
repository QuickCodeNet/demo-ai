SELECT [Key], [ModuleName], [ModelName], [HttpMethod], [ControllerName], [MethodName], [UrlPath] 
FROM [ApiMethodDefinitions] 
WHERE [ModuleName] = @PRM_ApiMethodDefinition_ModuleName 
ORDER BY [Key] 