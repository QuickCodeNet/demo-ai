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

[Table("HAIRDRESSER_NOTES")]
public partial class HairdresserNote : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("HAIRDRESSER_ID")]
	public int HairdresserId { get; set; }
	
	[Column("NOTE")]
	[StringLength(1000)]
	public string Note { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("HairdresserId")]
	[InverseProperty(nameof(Hairdresser.HairdresserNotes))]
	public virtual Hairdresser Hairdresser { get; set; } = null!;

}

