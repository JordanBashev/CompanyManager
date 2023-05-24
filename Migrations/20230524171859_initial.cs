using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManager.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    password = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    yearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    removedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    pointsPerPerson = table.Column<double>(type: "float", nullable: false),
                    name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    removedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    managerId = table.Column<int>(type: "int", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    removedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_Managers_managerId",
                        column: x => x.managerId,
                        principalTable: "Managers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    password = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    yearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    managerId = table.Column<int>(type: "int", nullable: true),
                    teamId = table.Column<int>(type: "int", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    removedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Managers_managerId",
                        column: x => x.managerId,
                        principalTable: "Managers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Employees_Teams_teamId",
                        column: x => x.teamId,
                        principalTable: "Teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TeamToProject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(type: "int", nullable: true),
                    teamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamToProject", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeamToProject_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeamToProject_Teams_teamId",
                        column: x => x.teamId,
                        principalTable: "Teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_managerId",
                table: "Employees",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_teamId",
                table: "Employees",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_username",
                table: "Employees",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_username",
                table: "Managers",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_managerId",
                table: "Projects",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamToProject_projectId",
                table: "TeamToProject",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamToProject_teamId",
                table: "TeamToProject",
                column: "teamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TeamToProject");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
