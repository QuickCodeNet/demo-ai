using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.AppointmentManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;

[Table("APPOINTMENT_FEEDBACKS")]
public partial class AppointmentFeedback : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("APPOINTMENT_ID")]
	public int AppointmentId { get; set; }
	
	[Column("RATING")]
	public short Rating { get; set; }
	
	[Column("COMMENTS")]
	[StringLength(1000)]
	public string Comments { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("AppointmentId")]
	[InverseProperty(nameof(Appointment.AppointmentFeedbacks))]
	public virtual Appointment Appointment { get; set; } = null!;

}

