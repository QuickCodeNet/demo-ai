using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.PaymentModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.PaymentModule.Domain.Entities;

[Table("PAYMENT_METHODS")]
public partial class PaymentMethod : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("USER_ID")]
	public int UserId { get; set; }
	
	[Column("PAYMENT_METHOD_TYPE")]
	[StringLength(250)]
	public string PaymentMethodType { get; set; }
	
	[Column("ACCOUNT_NUMBER")]
	[StringLength(250)]
	public string AccountNumber { get; set; }
	
	[Column("EXPIRY_DATE")]
	public DateTime ExpiryDate { get; set; }
	
	[Column("CVV")]
	[StringLength(250)]
	public string Cvv { get; set; }
	
	[Column("IS_DEFAULT")]
	public bool IsDefault { get; set; }
	
	[InverseProperty(nameof(PaymentTransaction.PaymentMethod))]
	public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

}

