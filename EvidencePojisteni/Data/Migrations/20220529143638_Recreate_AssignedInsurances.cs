using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Recreate_AssignedInsurances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedInsuranceId1",
                table: "AssignedInsurance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedInsurancesToPolicyholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedInsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedInsurancesToPolicyholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedInsurancesToPolicyholders_AssignedInsurance_AssignedInsuranceId",
                        column: x => x.AssignedInsuranceId,
                        principalTable: "AssignedInsurance",
                        principalColumn: "AssignedInsuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance",
                column: "AssignedInsuranceId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInsurancesToPolicyholders_AssignedInsuranceId",
                table: "AssignedInsurancesToPolicyholders",
                column: "AssignedInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedInsurance_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance",
                column: "AssignedInsuranceId1",
                principalTable: "AssignedInsurance",
                principalColumn: "AssignedInsuranceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedInsurance_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance");

            migrationBuilder.DropTable(
                name: "AssignedInsurancesToPolicyholders");

            migrationBuilder.DropIndex(
                name: "IX_AssignedInsurance_AssignedInsuranceId1",
                table: "AssignedInsurance");

            migrationBuilder.DropColumn(
                name: "AssignedInsuranceId1",
                table: "AssignedInsurance");
        }
    }
}
