using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.PaymentModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.PaymentModule.Domain.Enums;

namespace QuickCode.DemoAi.PaymentModule.Domain.Entities;

[Table("PAYMENT_TRANSACTIONS")]
public partial class PaymentTransaction : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ORDER_ID")]
	public int OrderId { get; set; }
	
	[Column("PAYMENT_METHOD_ID")]
	public int PaymentMethodId { get; set; }
	
	[Column("TRANSACTION_DATE")]
	public DateTime TransactionDate { get; set; }
	
	[Column("AMOUNT")]
	[Precision(18,2)]
	public decimal Amount { get; set; }
	
	[Column("PAYMENT_STATUS", TypeName = "nvarchar(250)")]
	public PaymentStatus PaymentStatus { get; set; }
	
	[Column("TRANSACTION_ID")]
	[StringLength(250)]
	public string TransactionId { get; set; }
	
	[ForeignKey("PaymentMethodId")]
	[InverseProperty(nameof(PaymentMethod.PaymentTransactions))]
	public virtual PaymentMethod PaymentMethod { get; set; } = null!;

}

