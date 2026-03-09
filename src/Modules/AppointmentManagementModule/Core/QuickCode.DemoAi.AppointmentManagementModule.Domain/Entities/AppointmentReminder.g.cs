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

[Table("APPOINTMENT_REMINDERS")]
public partial class AppointmentReminder : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("APPOINTMENT_ID")]
	public int AppointmentId { get; set; }
	
	[Column("REMINDER_TIME")]
	public DateTime ReminderTime { get; set; }
	
	[Column("IS_SENT")]
	public bool? IsSent { get; set; }
	
	[ForeignKey("AppointmentId")]
	[InverseProperty(nameof(Appointment.AppointmentReminders))]
	public virtual Appointment Appointment { get; set; } = null!;

}

