using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Extensions_Insurance_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceDescription",
                table: "Insurance",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceImage",
                table: "Insurance",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceDescription",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "InsuranceImage",
                table: "Insurance");
        }
    }
}
