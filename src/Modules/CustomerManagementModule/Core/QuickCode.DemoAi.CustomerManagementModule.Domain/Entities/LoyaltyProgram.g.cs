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

[Table("LOYALTY_PROGRAMS")]
public partial class LoyaltyProgram : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("POINTS_PER_DOLLAR")]
	public decimal PointsPerDollar { get; set; }
	
	[InverseProperty(nameof(CustomerLoyaltyPoint.LoyaltyProgram))]
	public virtual ICollection<CustomerLoyaltyPoint> CustomerLoyaltyPoints { get; } = new List<CustomerLoyaltyPoint>();

}

