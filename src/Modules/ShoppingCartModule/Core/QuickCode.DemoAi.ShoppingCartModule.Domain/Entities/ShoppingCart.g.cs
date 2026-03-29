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

[Table("SHOPPING_CARTS")]
public partial class ShoppingCart : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("USER_ID")]
	public int UserId { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("MODIFIED_DATE")]
	public DateTime ModifiedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(CartItem.ShoppingCart))]
	public virtual ICollection<CartItem> CartItems { get; } = new List<CartItem>();


	[ForeignKey("UserId")]
	[InverseProperty(nameof(CartItem.ShoppingCarts))]
	public virtual CartItem CartItem { get; set; } = null!;

}

