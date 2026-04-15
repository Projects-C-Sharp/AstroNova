using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace astronova.Migrations
{
    /// <inheritdoc />
    public partial class AstronautUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HoursExperience",
                table: "Astronauts",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HoursExperience",
                table: "Astronauts",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
