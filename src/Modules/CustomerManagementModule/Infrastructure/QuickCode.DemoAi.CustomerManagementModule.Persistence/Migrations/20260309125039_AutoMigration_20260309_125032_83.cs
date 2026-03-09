using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Migrations
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
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LOYALTY_TIER = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    NOTES = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOYALTY_PROGRAMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    POINTS_PER_DOLLAR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOYALTY_PROGRAMS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_LINE_1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ADDRESS_LINE_2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ZIP_CODE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    COUNTRY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ADDRESSES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_NOTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_NOTES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_PREFERENCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PREFERENCE_TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PREFERENCE_VALUE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_PREFERENCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_PREFERENCES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_LOYALTY_POINTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    LOYALTY_PROGRAM_ID = table.Column<int>(type: "int", nullable: false),
                    POINTS = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_LOYALTY_POINTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOYALTY_POINTS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOYALTY_POINTS_LOYALTY_PROGRAMS_LOYALTY_PROGRAM_ID",
                        column: x => x.LOYALTY_PROGRAM_ID,
                        principalTable: "LOYALTY_PROGRAMS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ADDRESSES_CUSTOMER_ID",
                table: "CUSTOMER_ADDRESSES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ADDRESSES_IsDeleted",
                table: "CUSTOMER_ADDRESSES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOYALTY_POINTS_CUSTOMER_ID",
                table: "CUSTOMER_LOYALTY_POINTS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOYALTY_POINTS_IsDeleted",
                table: "CUSTOMER_LOYALTY_POINTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOYALTY_POINTS_LOYALTY_PROGRAM_ID",
                table: "CUSTOMER_LOYALTY_POINTS",
                column: "LOYALTY_PROGRAM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_NOTES_CUSTOMER_ID",
                table: "CUSTOMER_NOTES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_NOTES_IsDeleted",
                table: "CUSTOMER_NOTES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_PREFERENCES_CUSTOMER_ID",
                table: "CUSTOMER_PREFERENCES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_PREFERENCES_IsDeleted",
                table: "CUSTOMER_PREFERENCES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_IsDeleted",
                table: "CUSTOMERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LOYALTY_PROGRAMS_IsDeleted",
                table: "LOYALTY_PROGRAMS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ADDRESSES");

            migrationBuilder.DropTable(
                name: "CUSTOMER_LOYALTY_POINTS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_NOTES");

            migrationBuilder.DropTable(
                name: "CUSTOMER_PREFERENCES");

            migrationBuilder.DropTable(
                name: "LOYALTY_PROGRAMS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");
        }
    }
}
