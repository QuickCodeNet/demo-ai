using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.OrderManagementModule.Domain.Enums;

public enum OrderStatus{
	[Description("Order is awaiting payment")]
	Pending,
	[Description("Order is being processed")]
	Processing,
	[Description("Order has been shipped")]
	Shipped,
	[Description("Order has been delivered")]
	Delivered,
	[Description("Order is completed")]
	Completed,
	[Description("Order has been cancelled")]
	Cancelled
}
