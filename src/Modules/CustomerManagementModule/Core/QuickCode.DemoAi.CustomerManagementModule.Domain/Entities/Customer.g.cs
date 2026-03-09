using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.CustomerManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;

[Table("CUSTOMERS")]
public partial class Customer : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("FIRST_NAME")]
	[StringLength(250)]
	public string FirstName { get; set; }
	
	[Column("LAST_NAME")]
	[StringLength(250)]
	public string LastName { get; set; }
	
	[Column("EMAIL")]
	[StringLength(500)]
	public string Email { get; set; }
	
	[Column("PHONE_NUMBER")]
	[StringLength(50)]
	public string PhoneNumber { get; set; }
	
	[Column("LOYALTY_TIER", TypeName = "nvarchar(250)")]
	public LoyaltyTier LoyaltyTier { get; set; }
	
	[Column("NOTES")]
	[StringLength(1000)]
	public string Notes { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(CustomerAddress.Customer))]
	public virtual ICollection<CustomerAddress> CustomerAddresses { get; } = new List<CustomerAddress>();


	[InverseProperty(nameof(CustomerNote.Customer))]
	public virtual ICollection<CustomerNote> CustomerNotes { get; } = new List<CustomerNote>();


	[InverseProperty(nameof(CustomerPreference.Customer))]
	public virtual ICollection<CustomerPreference> CustomerPreferences { get; } = new List<CustomerPreference>();


	[InverseProperty(nameof(CustomerLoyaltyPoint.Customer))]
	public virtual ICollection<CustomerLoyaltyPoint> CustomerLoyaltyPoints { get; } = new List<CustomerLoyaltyPoint>();

}

