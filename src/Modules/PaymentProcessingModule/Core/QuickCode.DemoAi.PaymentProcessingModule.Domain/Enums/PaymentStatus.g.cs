using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.PaymentProcessingModule.Domain.Enums;

public enum PaymentStatus{
	[Description("Payment is awaiting processing")]
	Pending,
	[Description("Payment has been approved")]
	Approved,
	[Description("Payment has been rejected")]
	Rejected,
	[Description("Payment has been completed")]
	Completed,
	[Description("Payment has been refunded")]
	Refunded
}
