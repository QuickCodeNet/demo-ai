SELECT [PermissionGroupName], [PortalPageDefinitionKey], [PageAction], [ModifiedBy], [IsActive] 
FROM [PortalPageAccessGrants] 
WHERE [PermissionGroupName] = @PRM_PortalPageAccessGrant_PermissionGroupName 
	AND [IsActive] = 1 
ORDER BY [PermissionGroupName], [PortalPageDefinitionKey], [PageAction] 