using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Appointment> Appointment { get; set; }

	public virtual DbSet<AppointmentFeedback> AppointmentFeedback { get; set; }

	public virtual DbSet<AppointmentReminder> AppointmentReminder { get; set; }

	public virtual DbSet<WaitingList> WaitingList { get; set; }

	public virtual DbSet<Holiday> Holiday { get; set; }

	public virtual DbSet<AppointmentCharge> AppointmentCharge { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterAppointmentStatus = new ValueConverter<AppointmentStatus, string>(
		v => v.ToString(),
		v => (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), v));

		modelBuilder.Entity<Appointment>()
		.Property(b => b.Status)
		.HasConversion(converterAppointmentStatus);

		modelBuilder.Entity<AppointmentReminder>()
		.Property(b => b.IsSent)
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

		modelBuilder.Entity<Appointment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Appointment>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AppointmentFeedback>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AppointmentFeedback>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AppointmentReminder>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AppointmentReminder>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<WaitingList>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<WaitingList>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Holiday>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Holiday>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AppointmentCharge>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AppointmentCharge>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Appointment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AppointmentFeedback>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AppointmentReminder>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<WaitingList>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Holiday>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AppointmentCharge>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<AppointmentFeedback>()
			.HasOne(e => e.Appointment)
			.WithMany(p => p.AppointmentFeedbacks)
			.HasForeignKey(e => e.AppointmentId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AppointmentReminder>()
			.HasOne(e => e.Appointment)
			.WithMany(p => p.AppointmentReminders)
			.HasForeignKey(e => e.AppointmentId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AppointmentCharge>()
			.HasOne(e => e.Appointment)
			.WithMany(p => p.AppointmentCharges)
			.HasForeignKey(e => e.AppointmentId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
