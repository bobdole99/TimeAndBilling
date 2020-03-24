using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeAndBilling.Migrations
{
    public partial class columnnamechanhes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TimeEntries_TimeEntryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_TimeEntries_TimeEntryId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Employees_EmployeeIDId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Projects_ProjectIDId",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_EmployeeIDId",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_ProjectIDId",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TimeEntryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TimeEntryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeIDId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "ProjectIDId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "TimeEntryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimeEntryId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TimeEntries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TimeEntries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_EmployeeId",
                table: "TimeEntries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_ProjectId",
                table: "TimeEntries",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Employees_EmployeeId",
                table: "TimeEntries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Employees_EmployeeId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Projects_ProjectId",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_EmployeeId",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_ProjectId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TimeEntries");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIDId",
                table: "TimeEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectIDId",
                table: "TimeEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeEntryId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeEntryId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_EmployeeIDId",
                table: "TimeEntries",
                column: "EmployeeIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_ProjectIDId",
                table: "TimeEntries",
                column: "ProjectIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TimeEntryId",
                table: "Projects",
                column: "TimeEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TimeEntryId",
                table: "Employees",
                column: "TimeEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TimeEntries_TimeEntryId",
                table: "Employees",
                column: "TimeEntryId",
                principalTable: "TimeEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_TimeEntries_TimeEntryId",
                table: "Projects",
                column: "TimeEntryId",
                principalTable: "TimeEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Employees_EmployeeIDId",
                table: "TimeEntries",
                column: "EmployeeIDId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Projects_ProjectIDId",
                table: "TimeEntries",
                column: "ProjectIDId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
