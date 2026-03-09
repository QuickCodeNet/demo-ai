using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

public enum LoyaltyTier{
	[Description("Bronze loyalty tier")]
	Bronze,
	[Description("Silver loyalty tier")]
	Silver,
	[Description("Gold loyalty tier")]
	Gold
}
