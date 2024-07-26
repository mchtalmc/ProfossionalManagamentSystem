using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagamentSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class migfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MilitaryStatuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HealthStatuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EducationStatuses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MilitaryStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HealthStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EducationStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
