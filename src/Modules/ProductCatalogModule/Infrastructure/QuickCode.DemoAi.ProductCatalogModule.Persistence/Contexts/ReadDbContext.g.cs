using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoAi.ProductCatalogModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Product> Product { get; set; }

	public virtual DbSet<Category> Category { get; set; }

	public virtual DbSet<ProductCategory> ProductCategory { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterProductStatus = new ValueConverter<ProductStatus, string>(
		v => v.ToString(),
		v => (ProductStatus)Enum.Parse(typeof(ProductStatus), v));

		modelBuilder.Entity<Product>()
		.Property(b => b.Status)
		.HasConversion(converterProductStatus);

		modelBuilder.Entity<Category>()
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

		modelBuilder.Entity<Product>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Product>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Category>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Category>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Product>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Category>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<ProductCategory>()
			.HasOne(e => e.Product)
			.WithMany(p => p.ProductCategories)
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ProductCategory>()
			.HasOne(e => e.Category)
			.WithMany(p => p.ProductCategories)
			.HasForeignKey(e => e.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override int SaveChanges()
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

}
