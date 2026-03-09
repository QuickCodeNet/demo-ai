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

[Table("WAITING_LISTS")]
public partial class WaitingList : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("SERVICE_ID")]
	public int ServiceId { get; set; }
	
	[Column("PREFERRED_DATE")]
	public DateTime PreferredDate { get; set; }
	
	[Column("NOTES")]
	[StringLength(250)]
	public string Notes { get; set; }
	}

