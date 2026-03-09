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

[Table("CUSTOMER_LOYALTY_POINTS")]
public partial class CustomerLoyaltyPoint : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("LOYALTY_PROGRAM_ID")]
	public int LoyaltyProgramId { get; set; }
	
	[Column("POINTS")]
	public int Points { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.CustomerLoyaltyPoints))]
	public virtual Customer Customer { get; set; } = null!;


	[ForeignKey("LoyaltyProgramId")]
	[InverseProperty(nameof(LoyaltyProgram.CustomerLoyaltyPoints))]
	public virtual LoyaltyProgram LoyaltyProgram { get; set; } = null!;

}

