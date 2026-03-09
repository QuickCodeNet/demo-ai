using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Hairdresser> Hairdresser { get; set; }

	public virtual DbSet<Service> Service { get; set; }

	public virtual DbSet<HairdresserAvailability> HairdresserAvailability { get; set; }

	public virtual DbSet<ServicePrice> ServicePrice { get; set; }

	public virtual DbSet<HairdresserNote> HairdresserNote { get; set; }

	public virtual DbSet<SalonEquipment> SalonEquipment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Hairdresser>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterServiceCategory = new ValueConverter<ServiceCategory, string>(
		v => v.ToString(),
		v => (ServiceCategory)Enum.Parse(typeof(ServiceCategory), v));

		modelBuilder.Entity<Service>()
		.Property(b => b.Category)
		.HasConversion(converterServiceCategory);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Hairdresser>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Hairdresser>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Service>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Service>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<HairdresserAvailability>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<HairdresserAvailability>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ServicePrice>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ServicePrice>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<HairdresserNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<HairdresserNote>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<SalonEquipment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<SalonEquipment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Hairdresser>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Service>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<HairdresserAvailability>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ServicePrice>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<HairdresserNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<SalonEquipment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Service>()
			.HasOne(e => e.Hairdresser)
			.WithMany(p => p.Services)
			.HasForeignKey(e => e.HairdresserId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<HairdresserAvailability>()
			.HasOne(e => e.Hairdresser)
			.WithMany(p => p.HairdresserAvailabilities)
			.HasForeignKey(e => e.HairdresserId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ServicePrice>()
			.HasOne(e => e.Service)
			.WithMany(p => p.ServicePrices)
			.HasForeignKey(e => e.ServiceId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<HairdresserNote>()
			.HasOne(e => e.Hairdresser)
			.WithMany(p => p.HairdresserNotes)
			.HasForeignKey(e => e.HairdresserId)
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
