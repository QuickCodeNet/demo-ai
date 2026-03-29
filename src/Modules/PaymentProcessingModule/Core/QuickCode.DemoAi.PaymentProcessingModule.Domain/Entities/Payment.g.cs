using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.PaymentProcessingModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.PaymentProcessingModule.Domain.Enums;

namespace QuickCode.DemoAi.PaymentProcessingModule.Domain.Entities;

[Table("PAYMENTS")]
public partial class Payment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ORDER_ID")]
	public int OrderId { get; set; }
	
	[Column("PAYMENT_DATE")]
	public DateTime PaymentDate { get; set; }
	
	[Column("AMOUNT")]
	[Precision(18,2)]
	public decimal Amount { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public PaymentStatus Status { get; set; }
	
	[Column("PAYMENT_METHOD", TypeName = "nvarchar(250)")]
	public PaymentMethod PaymentMethod { get; set; }
	
	[Column("TRANSACTION_ID")]
	[StringLength(250)]
	public string TransactionId { get; set; }
	}

