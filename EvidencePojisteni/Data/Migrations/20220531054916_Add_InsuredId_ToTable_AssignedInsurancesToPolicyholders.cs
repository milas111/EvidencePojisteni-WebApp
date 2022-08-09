using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Add_InsuredId_ToTable_AssignedInsurancesToPolicyholders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedInsurance_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance");

            migrationBuilder.DropColumn(
                name: "AssignedInsuranceId1",
                table: "AssignedInsurance");

            migrationBuilder.AddColumn<int>(
                name: "InsuredId",
                table: "AssignedInsurancesToPolicyholders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInsurancesToPolicyholders_InsuredId",
                table: "AssignedInsurancesToPolicyholders",
                column: "InsuredId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedInsurancesToPolicyholders_Insured_InsuredId",
                table: "AssignedInsurancesToPolicyholders",
                column: "InsuredId",
                principalTable: "Insured",
                principalColumn: "InsuredId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedInsurancesToPolicyholders_Insured_InsuredId",
                table: "AssignedInsurancesToPolicyholders");

            migrationBuilder.DropIndex(
                name: "IX_AssignedInsurancesToPolicyholders_InsuredId",
                table: "AssignedInsurancesToPolicyholders");

            migrationBuilder.DropColumn(
                name: "InsuredId",
                table: "AssignedInsurancesToPolicyholders");

            migrationBuilder.AddColumn<int>(
                name: "AssignedInsuranceId1",
                table: "AssignedInsurance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance",
                column: "AssignedInsuranceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedInsurance_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance",
                column: "AssignedInsuranceId1",
                principalTable: "AssignedInsurance",
                principalColumn: "AssignedInsuranceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
