using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260309_125032_83 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "HAIRDRESSERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HAIRDRESSERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SALON_EQUIPMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    LAST_MAINTENANCE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALON_EQUIPMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HAIRDRESSER_AVAILABILITIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAIRDRESSER_ID = table.Column<int>(type: "int", nullable: false),
                    DAY_OF_WEEK = table.Column<int>(type: "int", nullable: false),
                    START_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HAIRDRESSER_AVAILABILITIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HAIRDRESSER_AVAILABILITIES_HAIRDRESSERS_HAIRDRESSER_ID",
                        column: x => x.HAIRDRESSER_ID,
                        principalTable: "HAIRDRESSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HAIRDRESSER_NOTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAIRDRESSER_ID = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HAIRDRESSER_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HAIRDRESSER_NOTES_HAIRDRESSERS_HAIRDRESSER_ID",
                        column: x => x.HAIRDRESSER_ID,
                        principalTable: "HAIRDRESSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SERVICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAIRDRESSER_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CATEGORY = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    DURATION_MINUTES = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SERVICES_HAIRDRESSERS_HAIRDRESSER_ID",
                        column: x => x.HAIRDRESSER_ID,
                        principalTable: "HAIRDRESSERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PRICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERVICE_ID = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VALID_FROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALID_TO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PRICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SERVICE_PRICES_SERVICES_SERVICE_ID",
                        column: x => x.SERVICE_ID,
                        principalTable: "SERVICES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HAIRDRESSER_AVAILABILITIES_HAIRDRESSER_ID",
                table: "HAIRDRESSER_AVAILABILITIES",
                column: "HAIRDRESSER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HAIRDRESSER_AVAILABILITIES_IsDeleted",
                table: "HAIRDRESSER_AVAILABILITIES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_HAIRDRESSER_NOTES_HAIRDRESSER_ID",
                table: "HAIRDRESSER_NOTES",
                column: "HAIRDRESSER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HAIRDRESSER_NOTES_IsDeleted",
                table: "HAIRDRESSER_NOTES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_HAIRDRESSERS_IsDeleted",
                table: "HAIRDRESSERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SALON_EQUIPMENTS_IsDeleted",
                table: "SALON_EQUIPMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICE_PRICES_IsDeleted",
                table: "SERVICE_PRICES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICE_PRICES_SERVICE_ID",
                table: "SERVICE_PRICES",
                column: "SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_HAIRDRESSER_ID",
                table: "SERVICES",
                column: "HAIRDRESSER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_IsDeleted",
                table: "SERVICES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "HAIRDRESSER_AVAILABILITIES");

            migrationBuilder.DropTable(
                name: "HAIRDRESSER_NOTES");

            migrationBuilder.DropTable(
                name: "SALON_EQUIPMENTS");

            migrationBuilder.DropTable(
                name: "SERVICE_PRICES");

            migrationBuilder.DropTable(
                name: "SERVICES");

            migrationBuilder.DropTable(
                name: "HAIRDRESSERS");
        }
    }
}
