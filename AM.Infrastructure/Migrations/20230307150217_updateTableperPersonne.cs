using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTableperPersonne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.DropColumn(
                name: "EmployementDate",
                table: "Traveller");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Traveller");

            migrationBuilder.RenameColumn(
                name: "Function",
                table: "Traveller",
                newName: "Nationality");

            migrationBuilder.AddColumn<string>(
                name: "HealthInformation",
                table: "Traveller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "date", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staff_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropColumn(
                name: "HealthInformation",
                table: "Traveller");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Traveller",
                newName: "Function");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployementDate",
                table: "Traveller",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Traveller",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Travellers_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
