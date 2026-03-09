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

[Table("HAIRDRESSER_AVAILABILITIES")]
public partial class HairdresserAvailability : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("HAIRDRESSER_ID")]
	public int HairdresserId { get; set; }
	
	[Column("DAY_OF_WEEK")]
	public int DayOfWeek { get; set; }
	
	[Column("START_TIME")]
	public DateTime StartTime { get; set; }
	
	[Column("END_TIME")]
	public DateTime EndTime { get; set; }
	
	[ForeignKey("HairdresserId")]
	[InverseProperty(nameof(Hairdresser.HairdresserAvailabilities))]
	public virtual Hairdresser Hairdresser { get; set; } = null!;

}

