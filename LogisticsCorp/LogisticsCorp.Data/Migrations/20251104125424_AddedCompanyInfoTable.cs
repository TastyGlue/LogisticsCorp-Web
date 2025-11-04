using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsCorp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    MondaySchedule = table.Column<string>(type: "text", nullable: false),
                    TuesdaySchedule = table.Column<string>(type: "text", nullable: false),
                    WednesdaySchedule = table.Column<string>(type: "text", nullable: false),
                    ThursdaySchedule = table.Column<string>(type: "text", nullable: false),
                    FridaySchedule = table.Column<string>(type: "text", nullable: false),
                    SaturdaySchedule = table.Column<string>(type: "text", nullable: false),
                    SundaySchedule = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");
        }
    }
}
