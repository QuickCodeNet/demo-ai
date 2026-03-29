using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.ProductCatalogModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoAi.ProductCatalogModule.Domain.Entities;

[Table("PRODUCTS")]
public partial class Product : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("SKU")]
	[StringLength(50)]
	public string Sku { get; set; }
	
	[Column("PRICE")]
	[Precision(18,2)]
	public decimal Price { get; set; }
	
	[Column("STOCK_QUANTITY")]
	public int StockQuantity { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public ProductStatus Status { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(ProductCategory.Product))]
	public virtual ICollection<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();

}

