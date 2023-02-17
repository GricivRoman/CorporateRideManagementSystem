using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СorporateRideManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemSettingForEmployeeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RideReport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportMonth = table.Column<int>(type: "int", nullable: false),
                    ReportYear = table.Column<int>(type: "int", nullable: false),
                    PassengerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideReport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeToLockPersonalDriveStatus = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportMonth = table.Column<int>(type: "int", nullable: false),
                    ReportYear = table.Column<int>(type: "int", nullable: false),
                    PassengerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RideTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RideStartPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideTimeFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RideFinishPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideAmount = table.Column<double>(type: "float", nullable: false),
                    RideAmountVAT = table.Column<double>(type: "float", nullable: false),
                    PersonalDriveStatus = table.Column<bool>(type: "bit", nullable: false),
                    RideReportID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ride_AspNetUsers_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ride_RideReport_RideReportID",
                        column: x => x.RideReportID,
                        principalTable: "RideReport",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SystemSettingForEmployeeId",
                table: "AspNetUsers",
                column: "SystemSettingForEmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ride_EmployeeId1",
                table: "Ride",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_RideReportID",
                table: "Ride",
                column: "RideReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SystemSetting_SystemSettingForEmployeeId",
                table: "AspNetUsers",
                column: "SystemSettingForEmployeeId",
                principalTable: "SystemSetting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SystemSetting_SystemSettingForEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropTable(
                name: "RideReport");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SystemSettingForEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemSettingForEmployeeId",
                table: "AspNetUsers");
        }
    }
}
