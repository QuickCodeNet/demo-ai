using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.CustomerManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;

[Table("CUSTOMER_PREFERENCES")]
public partial class CustomerPreference : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("PREFERENCE_TYPE")]
	[StringLength(250)]
	public string PreferenceType { get; set; }
	
	[Column("PREFERENCE_VALUE")]
	[StringLength(250)]
	public string PreferenceValue { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.CustomerPreferences))]
	public virtual Customer Customer { get; set; } = null!;

}

