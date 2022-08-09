using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Create_InsuranceEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceEvent",
                columns: table => new
                {
                    InsuranceEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    InsuredId = table.Column<int>(type: "int", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceRole = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceEvent", x => x.InsuranceEventId);
                    table.ForeignKey(
                        name: "FK_InsuranceEvent_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceEvent_Insured_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insured",
                        principalColumn: "InsuredId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEvent_InsuranceId",
                table: "InsuranceEvent",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEvent_InsuredId",
                table: "InsuranceEvent",
                column: "InsuredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceEvent");
        }
    }
}
