using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

public enum ServiceCategory{
	[Description("Haircut services")]
	Haircut,
	[Description("Hair coloring services")]
	Coloring,
	[Description("Hair styling services")]
	Styling,
	[Description("Hair treatment services")]
	Treatment
}
