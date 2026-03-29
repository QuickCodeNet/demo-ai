using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.ShippingModule.Domain.Enums;

public enum ShippingStatus{
	[Description("Shipping is awaiting processing")]
	Pending,
	[Description("Shipping is being processed")]
	Processing,
	[Description("Shipping has been shipped")]
	Shipped,
	[Description("Shipping is in transit")]
	InTransit,
	[Description("Shipping has been delivered")]
	Delivered,
	[Description("Shipping is delayed")]
	Delayed
}
