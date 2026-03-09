using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Customer> Customer { get; set; }

	public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }

	public virtual DbSet<CustomerNote> CustomerNote { get; set; }

	public virtual DbSet<CustomerPreference> CustomerPreference { get; set; }

	public virtual DbSet<LoyaltyProgram> LoyaltyProgram { get; set; }

	public virtual DbSet<CustomerLoyaltyPoint> CustomerLoyaltyPoint { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterCustomerLoyaltyTier = new ValueConverter<LoyaltyTier, string>(
		v => v.ToString(),
		v => (LoyaltyTier)Enum.Parse(typeof(LoyaltyTier), v));

		modelBuilder.Entity<Customer>()
		.Property(b => b.LoyaltyTier)
		.HasConversion(converterCustomerLoyaltyTier);

		modelBuilder.Entity<CustomerAddress>()
		.Property(b => b.IsDefault)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Customer>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Customer>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerAddress>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerAddress>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerNote>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerPreference>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerPreference>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<LoyaltyProgram>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<LoyaltyProgram>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerLoyaltyPoint>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerLoyaltyPoint>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Customer>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerAddress>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerPreference>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<LoyaltyProgram>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerLoyaltyPoint>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<CustomerAddress>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.CustomerAddresses)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerNote>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.CustomerNotes)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerPreference>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.CustomerPreferences)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerLoyaltyPoint>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.CustomerLoyaltyPoints)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerLoyaltyPoint>()
			.HasOne(e => e.LoyaltyProgram)
			.WithMany(p => p.CustomerLoyaltyPoints)
			.HasForeignKey(e => e.LoyaltyProgramId)
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
