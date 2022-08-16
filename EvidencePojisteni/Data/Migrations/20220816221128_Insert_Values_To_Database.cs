using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class Insert_Values_To_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "InsuranceEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42", "03f8222e-627c-48e3-884c-0d90723544eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e2e36b69-61f7-4dae-bbe2-739e01adfda6", 0, "e5077a54-57fa-48c3-875b-43842b46062a", "soukup.miloslav1@seznam.cz", false, true, null, "SOUKUP.MILOSLAV1@SEZNAM.CZ", "SOUKUP.MILOSLAV1@SEZNAM.CZ", "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==", null, false, "8ebe85f4-58c5-4ff8-becd-ad4b12f5934d", false, "soukup.miloslav1@seznam.cz" },
                    { "5e9cc9b8-31e3-4f15-b7e6-9ffb79287f54", 0, "a0d66d01-7651-4613-8f4f-e076bc9e17f8", "zobakova.vlasta@seznam.cz", false, true, null, "ZOBAKOVA.VLASTA@SEZNAM.CZ", "ZOBAKOVA.VLASTA@SEZNAM.CZ", "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==", null, false, "7b4ea926-276c-47df-a788-bd8e96c7d982", false, "zobakova.vlasta@seznam.cz" }
                });

            migrationBuilder.InsertData(
                table: "Insurance",
                columns: new[] { "InsuranceId", "InsuranceDescription", "InsuranceImage", "InsuranceName" },
                values: new object[,]
                {
                    { 1, "Pojištění majetku, zahrnuje pojištění nemovitosti a domácnosti, vám bude krýt záda v případě škody způsobené přírodními živly nebo zlodějem. Co všechno lze pojistit? Domáctnost: Vztahuje se na vybavení domu nebo bytu.Nemovitost: Vztahuje se na stavbu a veškeré její pevné součásti. Odpovědnost za škodu: Pokryje škody na cizím majetku nebo újmu na zdraví.", "propertyInsurance.png", "Pojištění majetku" },
                    { 2, "Základní cestovní pojištění kryje veškeré léčebné výlohy. Z tohoto pojištění Vám bude proplacena případná zdravotní péče v zahraničí. Pojišťovna za vás uhradí: Náklady na ošetření, hospitalizaci,léky, nezbytné převozy a repatriaci, převoz tělesných ostatků.", "travel-insurance.jpg", "Cestovní pojištění" },
                    { 3, "Každý majitel vozidla musí mít sjednané povinné ručení. Povinné ručení vás chrání v případě, že způsobíte dopravní nehodu: vyrovná za vás škody na autě, majetku i zdraví poškozených osob.", "vehicle-insurance.png", "Pojištění vozidel" },
                    { 4, "Životní pojištění finančně podrží vás i vaše blízké v případě smrti, úrazu s trvalými následky nebo dlouhodobé nemoci. Krytí si můžete vybrat tak, aby vyhovovalo vašim potřebám.", "life-insurance.jpg", "Životní pojištění" }
                });

            migrationBuilder.InsertData(
                table: "Insured",
                columns: new[] { "InsuredId", "City", "Email", "FirstName", "Gender", "Phone", "Street", "SurName", "UserId", "Zip" },
                values: new object[,]
                {
                    { 3, "Plzeň", "david.uplakanek@seznam.cz", "David", 1, "606 459 789", "Rejskova 43", "Plaček", null, "321 00" },
                    { 4, "Pardubice", "sucho.jarin@seznam.cz", "Jaroslav", 1, "721 568 986", "Kosmonautů 98", "Suchý", null, "530 03" },
                    { 5, "Kroměříž", "renatka.naruzivka@seznam.cz", "Renata", 0, "798 251 368", "Zvonková 45", "Náruživá", null, "767 01" },
                    { 6, "Poděbrady", "horako.jana@seznam.cz", "Jana", 0, "607 899 456", "Sokolečská 93", "Horáková", null, "290 01" },
                    { 7, "Ostrava", "vlasta.otevrel@seznam.cz", "Vlastimil", 1, "732 564 789", "Horní 25", "Otevřel", null, "700 30" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42", "e2e36b69-61f7-4dae-bbe2-739e01adfda6" });

            migrationBuilder.InsertData(
                table: "AssignedInsurance",
                columns: new[] { "AssignedInsuranceId", "InsuranceId", "InsuranceRole", "InsuredId", "Issue", "Paid", "ValidFrom", "ValidTo", "Value" },
                values: new object[] { 4, 4, 0, 3, "Úraz", false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000 });

            migrationBuilder.InsertData(
                table: "Insured",
                columns: new[] { "InsuredId", "City", "Email", "FirstName", "Gender", "Phone", "Street", "SurName", "UserId", "Zip" },
                values: new object[,]
                {
                    { 1, "Brno", "soukup.miloslav1@seznam.cz", "Miloslav", 1, "neznámé číslo", "Nepovím", "Soukup", "e2e36b69-61f7-4dae-bbe2-739e01adfda6", "621 00" },
                    { 2, "Praha 1", "zobakova.vlasta@seznam.cz", "Vlastimila", 0, "731 567 957", "Karlova 73", "Zobáková", "5e9cc9b8-31e3-4f15-b7e6-9ffb79287f54", "110 00" }
                });

            migrationBuilder.InsertData(
                table: "AssignedInsurance",
                columns: new[] { "AssignedInsuranceId", "InsuranceId", "InsuranceRole", "InsuredId", "Issue", "Paid", "ValidFrom", "ValidTo", "Value" },
                values: new object[,]
                {
                    { 3, 3, 0, 1, "Povinné ručení", true, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 },
                    { 1, 1, 0, 2, "Byt", false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000 },
                    { 2, 2, 1, 2, "Do zahraničí", false, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000 }
                });

            migrationBuilder.InsertData(
                table: "AssignedInsurancesToPolicyholders",
                columns: new[] { "Id", "AssignedInsuranceId", "InsuredId" },
                values: new object[] { 2, 4, 2 });

            migrationBuilder.InsertData(
                table: "InsuranceEvent",
                columns: new[] { "InsuranceEventId", "AccountNumber", "BankCode", "City", "Email", "EventDate", "EventDescription", "FirstName", "Gender", "InsuranceId", "InsuredId", "Phone", "Street", "SurName", "Zip" },
                values: new object[] { 1, "1234567891234567", "0100", "Praha 1", "zobakova.vlasta@seznam.cz", new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Byl nám vytopen byt sousedy.", "Vlastimila", 0, 1, 2, "731 567 957", "Karlova 73", "Zobáková", "110 00" });

            migrationBuilder.InsertData(
                table: "AssignedInsurancesToPolicyholders",
                columns: new[] { "Id", "AssignedInsuranceId", "InsuredId" },
                values: new object[] { 1, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42", "e2e36b69-61f7-4dae-bbe2-739e01adfda6" });

            migrationBuilder.DeleteData(
                table: "AssignedInsurance",
                keyColumn: "AssignedInsuranceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssignedInsurance",
                keyColumn: "AssignedInsuranceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssignedInsurancesToPolicyholders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssignedInsurancesToPolicyholders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InsuranceEvent",
                keyColumn: "InsuranceEventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42");

            migrationBuilder.DeleteData(
                table: "AssignedInsurance",
                keyColumn: "AssignedInsuranceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssignedInsurance",
                keyColumn: "AssignedInsuranceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Insurance",
                keyColumn: "InsuranceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insurance",
                keyColumn: "InsuranceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e9cc9b8-31e3-4f15-b7e6-9ffb79287f54");

            migrationBuilder.DeleteData(
                table: "Insurance",
                keyColumn: "InsuranceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Insurance",
                keyColumn: "InsuranceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insured",
                keyColumn: "InsuredId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2e36b69-61f7-4dae-bbe2-739e01adfda6");

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                table: "InsuranceEvent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
