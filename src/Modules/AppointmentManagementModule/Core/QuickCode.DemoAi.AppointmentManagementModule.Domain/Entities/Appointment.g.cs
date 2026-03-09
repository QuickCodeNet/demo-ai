using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.AppointmentManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;

[Table("APPOINTMENTS")]
public partial class Appointment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("SERVICE_ID")]
	public int ServiceId { get; set; }
	
	[Column("APPOINTMENT_DATE")]
	public DateTime AppointmentDate { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public AppointmentStatus Status { get; set; }
	
	[Column("NOTES")]
	[StringLength(1000)]
	public string Notes { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(AppointmentFeedback.Appointment))]
	public virtual ICollection<AppointmentFeedback> AppointmentFeedbacks { get; } = new List<AppointmentFeedback>();


	[InverseProperty(nameof(AppointmentReminder.Appointment))]
	public virtual ICollection<AppointmentReminder> AppointmentReminders { get; } = new List<AppointmentReminder>();


	[InverseProperty(nameof(AppointmentCharge.Appointment))]
	public virtual ICollection<AppointmentCharge> AppointmentCharges { get; } = new List<AppointmentCharge>();

}

