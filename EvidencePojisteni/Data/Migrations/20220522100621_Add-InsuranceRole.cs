using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class AddInsuranceRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceRole",
                table: "Insured",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceRole",
                table: "Insured");
        }
    }
}
