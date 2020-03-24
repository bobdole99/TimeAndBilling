using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeAndBilling.Migrations
{
    public partial class addedTimeEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeEntryId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeEntryId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeIDId = table.Column<int>(nullable: true),
                    ProjectIDId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Hours = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Employees_EmployeeIDId",
                        column: x => x.EmployeeIDId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Projects_ProjectIDId",
                        column: x => x.ProjectIDId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TimeEntryId",
                table: "Projects",
                column: "TimeEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TimeEntryId",
                table: "Employees",
                column: "TimeEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_EmployeeIDId",
                table: "TimeEntries",
                column: "EmployeeIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_ProjectIDId",
                table: "TimeEntries",
                column: "ProjectIDId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TimeEntries_TimeEntryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_TimeEntries_TimeEntryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TimeEntryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TimeEntryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TimeEntryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimeEntryId",
                table: "Employees");
        }
    }
}
