using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.OrderModule.Domain.Entities;
using QuickCode.DemoAi.OrderModule.Domain.Enums;

namespace QuickCode.DemoAi.OrderModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Order> Order { get; set; }

	public virtual DbSet<OrderItem> OrderItem { get; set; }

	public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

	public virtual DbSet<CartItem> CartItem { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Order>()
		.Property(b => b.OrderStatus)
		.IsRequired()
		.HasDefaultValueSql("'PENDING'");


		var converterOrderOrderStatus = new ValueConverter<OrderStatus, string>(
		v => v.ToString(),
		v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

		modelBuilder.Entity<Order>()
		.Property(b => b.OrderStatus)
		.HasConversion(converterOrderOrderStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Order>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Order>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<OrderItem>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<OrderItem>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ShoppingCart>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ShoppingCart>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CartItem>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CartItem>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Order>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<OrderItem>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ShoppingCart>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CartItem>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<OrderItem>()
			.HasOne(e => e.Order)
			.WithMany(p => p.OrderItems)
			.HasForeignKey(e => e.OrderId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
