SELECT [PermissionGroupName], [PortalPageDefinitionKey], [PageAction], [ModifiedBy], [IsActive] 
FROM [PortalPageAccessGrants] 
WHERE [PortalPageDefinitionKey] = @PRM_PortalPageAccessGrant_PortalPageDefinitionKey 
	AND [PermissionGroupName] = @PRM_PortalPageAccessGrant_PermissionGroupName 
	AND [PageAction] = @PRM_PortalPageAccessGrant_PageAction 
	AND [IsActive] = 1 
ORDER BY [PermissionGroupName], [PortalPageDefinitionKey], [PageAction] 