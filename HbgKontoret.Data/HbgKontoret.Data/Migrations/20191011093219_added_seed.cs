using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HbgKontoret.Data.Migrations
{
    public partial class AddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Competences",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DOTNET" },
                    { 2, "JS" },
                    { 3, "React" },
                    { 4, "EpiServer" },
                    { 5, "C#" },
                    { 6, "Angular" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "Manager", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Considvägen 1", "Christian", "Helsingborg", "042-123456" },
                    { 2, "Considvägen 2", "Peter", "Jönköping", "036-321654" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "AboutMe", "FirstName", "ImageUrl", "LastName", "LinkedInUrl", "Manager", "PhoneNo" },
                values: new object[,]
                {
                    { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), "Spielt Allan allein", "Ruler", null, "OfTheWorld", null, null, null },
                    { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), "Ich bin ein Dorftrottel", "Robin", null, "Robinovic", null, "Christian", null },
                    { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), "Lorem ipsum", "Salmin", null, "Salminovic", null, "Peter", null },
                    { new Guid("53019d21-e997-406d-bc36-6627c078e6a5"), "I'm awesome and you suck!", "Admin", null, "Administrator", null, "Mange", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Visitor" },
                    { 2, "Member" },
                    { 3, "Manager" },
                    { 4, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "ProfileCompetences",
                columns: new[] { "ProfileId", "CompetenceId" },
                values: new object[,]
                {
                    { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 3 },
                    { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 1 },
                    { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 2 },
                    { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 4 },
                    { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 2 },
                    { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 3 }
                });

            migrationBuilder.InsertData(
                table: "ProfileOffices",
                columns: new[] { "ProfileId", "OfficeId" },
                values: new object[,]
                {
                    { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 1 },
                    { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 2 },
                    { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 1 },
                    { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "ProfileId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("2d11321b-72a4-492e-a9cb-becb72164fa4"), "janedoe@nomail.com", "visitor01", null, 1 },
                    { new Guid("84a23a45-1dc8-471d-b0ae-c11b3c2b014b"), "salmin@consid.se", "consid02", new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 2 },
                    { new Guid("97de5fdb-e995-4289-a753-39657ee08a11"), "robin@consid.se", "consid01", new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 3 },
                    { new Guid("53019d21-e997-406d-bc36-6627c078e6a5"), "admin@consid.se", "secret123!", new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 2 });

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 3 });

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 2 });

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 4 });

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 1 });

            migrationBuilder.DeleteData(
                table: "ProfileCompetences",
                keyColumns: new[] { "ProfileId", "CompetenceId" },
                keyValues: new object[] { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 3 });

            migrationBuilder.DeleteData(
                table: "ProfileOffices",
                keyColumns: new[] { "ProfileId", "OfficeId" },
                keyValues: new object[] { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), 2 });

            migrationBuilder.DeleteData(
                table: "ProfileOffices",
                keyColumns: new[] { "ProfileId", "OfficeId" },
                keyValues: new object[] { new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"), 1 });

            migrationBuilder.DeleteData(
                table: "ProfileOffices",
                keyColumns: new[] { "ProfileId", "OfficeId" },
                keyValues: new object[] { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 1 });

            migrationBuilder.DeleteData(
                table: "ProfileOffices",
                keyColumns: new[] { "ProfileId", "OfficeId" },
                keyValues: new object[] { new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"), 2 });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("53019d21-e997-406d-bc36-6627c078e6a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d11321b-72a4-492e-a9cb-becb72164fa4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53019d21-e997-406d-bc36-6627c078e6a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84a23a45-1dc8-471d-b0ae-c11b3c2b014b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97de5fdb-e995-4289-a753-39657ee08a11"));

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2ed8c7ca-6061-4308-86cc-61d73119b431"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c3178cd5-3615-4ebe-97f6-88da54a2ce21"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
