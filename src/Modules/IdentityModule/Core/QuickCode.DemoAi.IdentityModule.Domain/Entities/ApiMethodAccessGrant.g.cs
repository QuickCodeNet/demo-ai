using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.IdentityModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Domain.Entities;

[PrimaryKey("PermissionGroupName", "ApiMethodDefinitionKey")]
[Table("ApiMethodAccessGrants")]
public partial class ApiMethodAccessGrant : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("PermissionGroupName")]
	[StringLength(1000)]
	public string PermissionGroupName { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("ApiMethodDefinitionKey")]
	[StringLength(1000)]
	public string ApiMethodDefinitionKey { get; set; }
	
	[Column("ModifiedBy", TypeName = "nvarchar(250)")]
	public ModificationType ModifiedBy { get; set; }
	
	[Column("IsActive")]
	public bool IsActive { get; set; }
	
	[ForeignKey("ApiMethodDefinitionKey")]
	[InverseProperty(nameof(ApiMethodDefinition.ApiMethodAccessGrants))]
	public virtual ApiMethodDefinition ApiMethodDefinition { get; set; } = null!;


	[ForeignKey("PermissionGroupName")]
	[InverseProperty(nameof(PermissionGroup.ApiMethodAccessGrants))]
	public virtual PermissionGroup PermissionGroup { get; set; } = null!;

}

