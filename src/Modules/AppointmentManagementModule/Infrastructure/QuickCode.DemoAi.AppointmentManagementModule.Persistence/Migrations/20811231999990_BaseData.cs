using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Linq;
using QuickCode.DemoAi.Common.Extensions;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;

namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fileList = typeof(BaseData).GetMigrationDataFiles();
            migrationBuilder.ParseJsonAsInitialData<BaseData>(fileList);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
