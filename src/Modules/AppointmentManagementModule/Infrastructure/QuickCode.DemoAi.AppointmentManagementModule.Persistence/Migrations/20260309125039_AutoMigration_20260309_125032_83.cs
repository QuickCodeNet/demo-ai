using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260309_125032_83 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPOINTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_ID = table.Column<int>(type: "int", nullable: false),
                    APPOINTMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    NOTES = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ENTITY_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_GROUP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CHANGED_COLUMNS = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_CHANGED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CHANGE_SUMMARY = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CORRELATION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_SUCCESS = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    HASH = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOLIDAYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HOLIDAY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOLIDAYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WAITING_LISTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_ID = table.Column<int>(type: "int", nullable: false),
                    PREFERRED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOTES = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAITING_LISTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "APPOINTMENT_CHARGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPOINTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    CHARGE_TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENT_CHARGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_CHARGES_APPOINTMENTS_APPOINTMENT_ID",
                        column: x => x.APPOINTMENT_ID,
                        principalTable: "APPOINTMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPOINTMENT_FEEDBACKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPOINTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    RATING = table.Column<short>(type: "smallint", nullable: false),
                    COMMENTS = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENT_FEEDBACKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_FEEDBACKS_APPOINTMENTS_APPOINTMENT_ID",
                        column: x => x.APPOINTMENT_ID,
                        principalTable: "APPOINTMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPOINTMENT_REMINDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPOINTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    REMINDER_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_SENT = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENT_REMINDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_REMINDERS_APPOINTMENTS_APPOINTMENT_ID",
                        column: x => x.APPOINTMENT_ID,
                        principalTable: "APPOINTMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_CHARGES_APPOINTMENT_ID",
                table: "APPOINTMENT_CHARGES",
                column: "APPOINTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_CHARGES_IsDeleted",
                table: "APPOINTMENT_CHARGES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_FEEDBACKS_APPOINTMENT_ID",
                table: "APPOINTMENT_FEEDBACKS",
                column: "APPOINTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_FEEDBACKS_IsDeleted",
                table: "APPOINTMENT_FEEDBACKS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_REMINDERS_APPOINTMENT_ID",
                table: "APPOINTMENT_REMINDERS",
                column: "APPOINTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_REMINDERS_IsDeleted",
                table: "APPOINTMENT_REMINDERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_IsDeleted",
                table: "APPOINTMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_HOLIDAYS_IsDeleted",
                table: "HOLIDAYS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_WAITING_LISTS_IsDeleted",
                table: "WAITING_LISTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPOINTMENT_CHARGES");

            migrationBuilder.DropTable(
                name: "APPOINTMENT_FEEDBACKS");

            migrationBuilder.DropTable(
                name: "APPOINTMENT_REMINDERS");

            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "HOLIDAYS");

            migrationBuilder.DropTable(
                name: "WAITING_LISTS");

            migrationBuilder.DropTable(
                name: "APPOINTMENTS");
        }
    }
}
