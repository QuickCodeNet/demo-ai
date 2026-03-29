using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.ShippingModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.ShippingModule.Domain.Enums;

namespace QuickCode.DemoAi.ShippingModule.Domain.Entities;

[Table("SHIPMENTS")]
public partial class Shipment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ORDER_ID")]
	public int OrderId { get; set; }
	
	[Column("SHIPPING_DATE")]
	public DateTime ShippingDate { get; set; }
	
	[Column("DELIVERY_DATE")]
	public DateTime DeliveryDate { get; set; }
	
	[Column("SHIPPING_ADDRESS")]
	[StringLength(1000)]
	public string ShippingAddress { get; set; }
	
	[Column("SHIPPING_METHOD")]
	[StringLength(250)]
	public string ShippingMethod { get; set; }
	
	[Column("TRACKING_NUMBER")]
	[StringLength(250)]
	public string TrackingNumber { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public ShippingStatus Status { get; set; }
	}

