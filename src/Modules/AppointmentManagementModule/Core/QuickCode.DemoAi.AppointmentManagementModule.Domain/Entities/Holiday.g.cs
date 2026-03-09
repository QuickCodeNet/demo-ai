using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.AppointmentManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;

[Table("HOLIDAYS")]
public partial class Holiday : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("HOLIDAY_DATE")]
	public DateTime HolidayDate { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(250)]
	public string Description { get; set; }
	}

