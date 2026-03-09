using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.HairdresserManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;

[Table("SERVICES")]
public partial class Service : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("HAIRDRESSER_ID")]
	public int HairdresserId { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("PRICE")]
	[Precision(18,2)]
	public decimal Price { get; set; }
	
	[Column("CATEGORY", TypeName = "nvarchar(250)")]
	public ServiceCategory Category { get; set; }
	
	[Column("DURATION_MINUTES")]
	public int DurationMinutes { get; set; }
	
	[InverseProperty(nameof(ServicePrice.Service))]
	public virtual ICollection<ServicePrice> ServicePrices { get; } = new List<ServicePrice>();


	[ForeignKey("HairdresserId")]
	[InverseProperty(nameof(Hairdresser.Services))]
	public virtual Hairdresser Hairdresser { get; set; } = null!;

}

