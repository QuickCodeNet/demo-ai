using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.HairdresserManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;

[Table("SERVICE_PRICES")]
public partial class ServicePrice : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SERVICE_ID")]
	public int ServiceId { get; set; }
	
	[Column("PRICE")]
	[Precision(18,2)]
	public decimal Price { get; set; }
	
	[Column("VALID_FROM")]
	public DateTime ValidFrom { get; set; }
	
	[Column("VALID_TO")]
	public DateTime ValidTo { get; set; }
	
	[ForeignKey("ServiceId")]
	[InverseProperty(nameof(Service.ServicePrices))]
	public virtual Service Service { get; set; } = null!;

}

