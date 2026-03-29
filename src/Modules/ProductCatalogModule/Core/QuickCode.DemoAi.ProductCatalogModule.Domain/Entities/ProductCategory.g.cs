using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.ProductCatalogModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.ProductCatalogModule.Domain.Entities;

[PrimaryKey("ProductId", "CategoryId")]
[Table("PRODUCT_CATEGORIES")]
public partial class ProductCategory : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("CATEGORY_ID")]
	public int CategoryId { get; set; }
	
	[ForeignKey("ProductId")]
	[InverseProperty(nameof(Product.ProductCategories))]
	public virtual Product Product { get; set; } = null!;


	[ForeignKey("CategoryId")]
	[InverseProperty(nameof(Category.ProductCategories))]
	public virtual Category Category { get; set; } = null!;

}

