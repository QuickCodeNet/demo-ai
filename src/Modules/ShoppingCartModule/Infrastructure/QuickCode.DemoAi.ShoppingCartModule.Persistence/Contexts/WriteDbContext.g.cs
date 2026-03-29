using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.ShoppingCartModule.Domain.Entities;

namespace QuickCode.DemoAi.ShoppingCartModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

	public virtual DbSet<CartItem> CartItem { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ShoppingCart>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<ShoppingCart>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShoppingCart>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CartItem>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CartItem>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<ShoppingCart>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CartItem>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<ShoppingCart>()
			.HasOne(e => e.CartItem)
			.WithMany(p => p.ShoppingCarts)
			.HasForeignKey(e => e.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CartItem>()
			.HasOne(e => e.ShoppingCart)
			.WithMany(p => p.CartItems)
			.HasForeignKey(e => e.CartId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
