using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.ShippingModule.Domain.Entities;
using QuickCode.DemoAi.ShippingModule.Domain.Enums;

namespace QuickCode.DemoAi.ShippingModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Shipment> Shipment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterShipmentStatus = new ValueConverter<ShippingStatus, string>(
		v => v.ToString(),
		v => (ShippingStatus)Enum.Parse(typeof(ShippingStatus), v));

		modelBuilder.Entity<Shipment>()
		.Property(b => b.Status)
		.HasConversion(converterShipmentStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<Shipment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Shipment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Shipment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
