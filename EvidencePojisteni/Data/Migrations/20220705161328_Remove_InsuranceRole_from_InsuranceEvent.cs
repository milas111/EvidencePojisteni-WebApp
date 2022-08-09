using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Remove_InsuranceRole_from_InsuranceEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceRole",
                table: "InsuranceEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceRole",
                table: "InsuranceEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
