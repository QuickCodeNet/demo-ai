using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.OrderModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.OrderModule.Domain.Enums;

namespace QuickCode.DemoAi.OrderModule.Domain.Entities;

[Table("ORDERS")]
public partial class Order : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("USER_ID")]
	public int UserId { get; set; }
	
	[Column("ORDER_NUMBER")]
	[StringLength(250)]
	public string OrderNumber { get; set; }
	
	[Column("ORDER_DATE")]
	public DateTime OrderDate { get; set; }
	
	[Column("TOTAL_AMOUNT")]
	[Precision(18,2)]
	public decimal TotalAmount { get; set; }
	
	[Column("ORDER_STATUS", TypeName = "nvarchar(250)")]
	public OrderStatus OrderStatus { get; set; }
	
	[Column("SHIPPING_ADDRESS")]
	[StringLength(1000)]
	public string ShippingAddress { get; set; }
	
	[Column("BILLING_ADDRESS")]
	[StringLength(1000)]
	public string BillingAddress { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(OrderItem.Order))]
	public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

}

