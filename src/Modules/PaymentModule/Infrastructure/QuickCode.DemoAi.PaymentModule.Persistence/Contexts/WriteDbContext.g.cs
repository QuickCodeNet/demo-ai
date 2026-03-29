using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.PaymentModule.Domain.Entities;
using QuickCode.DemoAi.PaymentModule.Domain.Enums;

namespace QuickCode.DemoAi.PaymentModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }

	public virtual DbSet<PaymentTransaction> PaymentTransaction { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<PaymentMethod>()
		.Property(b => b.IsDefault)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<PaymentTransaction>()
		.Property(b => b.PaymentStatus)
		.IsRequired()
		.HasDefaultValueSql("'PENDING'");


		var converterPaymentTransactionPaymentStatus = new ValueConverter<PaymentStatus, string>(
		v => v.ToString(),
		v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v));

		modelBuilder.Entity<PaymentTransaction>()
		.Property(b => b.PaymentStatus)
		.HasConversion(converterPaymentTransactionPaymentStatus);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<PaymentMethod>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PaymentMethod>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PaymentTransaction>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PaymentTransaction>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<PaymentMethod>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PaymentTransaction>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<PaymentTransaction>()
			.HasOne(e => e.PaymentMethod)
			.WithMany(p => p.PaymentTransactions)
			.HasForeignKey(e => e.PaymentMethodId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
