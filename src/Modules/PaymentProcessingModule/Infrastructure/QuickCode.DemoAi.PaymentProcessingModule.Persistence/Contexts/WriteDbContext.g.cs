using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.PaymentProcessingModule.Domain.Entities;
using QuickCode.DemoAi.PaymentProcessingModule.Domain.Enums;

namespace QuickCode.DemoAi.PaymentProcessingModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Payment> Payment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterPaymentStatus = new ValueConverter<PaymentStatus, string>(
		v => v.ToString(),
		v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v));

		modelBuilder.Entity<Payment>()
		.Property(b => b.Status)
		.HasConversion(converterPaymentStatus);


		var converterPaymentPaymentMethod = new ValueConverter<PaymentMethod, string>(
		v => v.ToString(),
		v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));

		modelBuilder.Entity<Payment>()
		.Property(b => b.PaymentMethod)
		.HasConversion(converterPaymentPaymentMethod);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<Payment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Payment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Payment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
