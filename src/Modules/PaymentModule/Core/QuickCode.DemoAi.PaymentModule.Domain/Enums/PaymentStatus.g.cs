using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.PaymentModule.Domain.Enums;

public enum PaymentStatus{
	[Description("Payment is awaiting processing")]
	Pending,
	[Description("Payment is currently being processed")]
	Processing,
	[Description("Payment has been successfully completed")]
	Completed,
	[Description("Payment has failed")]
	Failed,
	[Description("Payment has been refunded")]
	Refunded
}
