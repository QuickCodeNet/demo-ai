using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.PaymentProcessingModule.Domain.Enums;

public enum PaymentMethod{
	[Description("Payment made via credit card")]
	CreditCard,
	[Description("Payment made via PayPal")]
	Paypal,
	[Description("Payment made via bank transfer")]
	BankTransfer
}
