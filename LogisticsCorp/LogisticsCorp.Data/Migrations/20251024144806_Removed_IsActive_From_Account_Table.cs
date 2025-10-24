using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsCorp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Removed_IsActive_From_Account_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
