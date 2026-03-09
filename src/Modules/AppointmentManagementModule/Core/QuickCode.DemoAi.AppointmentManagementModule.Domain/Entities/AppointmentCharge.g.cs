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

[Table("APPOINTMENT_CHARGES")]
public partial class AppointmentCharge : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("APPOINTMENT_ID")]
	public int AppointmentId { get; set; }
	
	[Column("CHARGE_TYPE")]
	[StringLength(250)]
	public string ChargeType { get; set; }
	
	[Column("AMOUNT")]
	[Precision(18,2)]
	public decimal Amount { get; set; }
	
	[ForeignKey("AppointmentId")]
	[InverseProperty(nameof(Appointment.AppointmentCharges))]
	public virtual Appointment Appointment { get; set; } = null!;

}

