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

[Table("HAIRDRESSERS")]
public partial class Hairdresser : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("EMAIL")]
	[StringLength(500)]
	public string Email { get; set; }
	
	[Column("PHONE_NUMBER")]
	[StringLength(50)]
	public string PhoneNumber { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(Service.Hairdresser))]
	public virtual ICollection<Service> Services { get; } = new List<Service>();


	[InverseProperty(nameof(HairdresserAvailability.Hairdresser))]
	public virtual ICollection<HairdresserAvailability> HairdresserAvailabilities { get; } = new List<HairdresserAvailability>();


	[InverseProperty(nameof(HairdresserNote.Hairdresser))]
	public virtual ICollection<HairdresserNote> HairdresserNotes { get; } = new List<HairdresserNote>();

}

