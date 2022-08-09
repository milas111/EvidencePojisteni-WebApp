using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Remove_InsuranceRole_From_Insureds_To_AssignedInsurances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceRole",
                table: "Insured");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceRole",
                table: "AssignedInsurance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceRole",
                table: "AssignedInsurance");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceRole",
                table: "Insured",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
