using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HbgKontoret.Data.Migrations
{
    public partial class changedrolepropertyinuser01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileCompetences",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(nullable: false),
                    CompetenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileCompetences", x => new { x.ProfileId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_ProfileCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileCompetences_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileOffices",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileOffices", x => new { x.ProfileId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_ProfileOffices_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileOffices_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { new Guid("02a9ee1c-fa0d-4e61-82e3-78a592eff671"), "Lorem ipsum", "Salmin", null, "Salminovic", null, "Peter", null }
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
                    { new Guid("84a23a45-1dc8-471d-b0ae-c11b3c2b014b"), "salmin@consid.se", "consid02", null, 2 },
                    { new Guid("97de5fdb-e995-4289-a753-39657ee08a11"), "robin@consid.se", "consid01", null, 3 },
                    { new Guid("53019d21-e997-406d-bc36-6627c078e6a5"), "admin@consid.se", "secret123!", null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCompetences_CompetenceId",
                table: "ProfileCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOffices_OfficeId",
                table: "ProfileOffices",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileCompetences");

            migrationBuilder.DropTable(
                name: "ProfileOffices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
