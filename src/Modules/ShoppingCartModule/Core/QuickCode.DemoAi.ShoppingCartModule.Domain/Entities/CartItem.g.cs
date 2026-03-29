using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoAi.ShoppingCartModule.Domain;
using QuickCode.DemoAi.Common;
using QuickCode.DemoAi.Common.Auditing;

namespace QuickCode.DemoAi.ShoppingCartModule.Domain.Entities;

[Table("CART_ITEMS")]
public partial class CartItem : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CART_ID")]
	public int CartId { get; set; }
	
	[Column("PRODUCT_ID")]
	public int ProductId { get; set; }
	
	[Column("QUANTITY")]
	public int Quantity { get; set; }
	
	[Column("PRICE")]
	[Precision(18,2)]
	public decimal Price { get; set; }
	
	[InverseProperty(nameof(ShoppingCart.CartItem))]
	public virtual ICollection<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();


	[ForeignKey("CartId")]
	[InverseProperty(nameof(ShoppingCart.CartItems))]
	public virtual ShoppingCart ShoppingCart { get; set; } = null!;

}

