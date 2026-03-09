using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

public enum AppointmentStatus{
	[Description("Appointment is pending confirmation")]
	Pending,
	[Description("Appointment is confirmed")]
	Confirmed,
	[Description("Appointment is completed")]
	Completed,
	[Description("Appointment is cancelled")]
	Cancelled
}
