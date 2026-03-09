using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.CustomerManagementModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;

[Table("CUSTOMER_ADDRESSES")]
public partial class CustomerAddress : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ADDRESS_LINE_1")]
	[StringLength(250)]
	public string AddressLine1 { get; set; }
	
	[Column("ADDRESS_LINE_2")]
	[StringLength(250)]
	public string AddressLine2 { get; set; }
	
	[Column("CITY")]
	[StringLength(250)]
	public string City { get; set; }
	
	[Column("STATE")]
	[StringLength(250)]
	public string State { get; set; }
	
	[Column("ZIP_CODE")]
	[StringLength(250)]
	public string ZipCode { get; set; }
	
	[Column("COUNTRY")]
	[StringLength(250)]
	public string Country { get; set; }
	
	[Column("IS_DEFAULT")]
	public bool? IsDefault { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.CustomerAddresses))]
	public virtual Customer Customer { get; set; } = null!;

}

