using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.HairdresserManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;

[Table("SALON_EQUIPMENTS")]
public partial class SalonEquipment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("QUANTITY")]
	public int Quantity { get; set; }
	
	[Column("LAST_MAINTENANCE")]
	public DateTime LastMaintenance { get; set; }
	}

