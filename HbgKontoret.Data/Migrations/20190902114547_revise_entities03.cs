using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HbgKontoret.Data.Migrations
{
    public partial class revise_entities03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Profiles_ProfileId",
                table: "Competences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileOffices",
                table: "ProfileOffices");

            migrationBuilder.DropIndex(
                name: "IX_ProfileOffices_ProfileId",
                table: "ProfileOffices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileCompetences",
                table: "ProfileCompetences");

            migrationBuilder.DropIndex(
                name: "IX_ProfileCompetences_ProfileId",
                table: "ProfileCompetences");

            migrationBuilder.DropIndex(
                name: "IX_Competences_ProfileId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Competences");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProfileOffices",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProfileCompetences",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileOffices",
                table: "ProfileOffices",
                columns: new[] { "ProfileId", "OfficeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileCompetences",
                table: "ProfileCompetences",
                columns: new[] { "ProfileId", "CompetenceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileOffices",
                table: "ProfileOffices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileCompetences",
                table: "ProfileCompetences");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProfileOffices",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProfileCompetences",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Competences",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileOffices",
                table: "ProfileOffices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileCompetences",
                table: "ProfileCompetences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOffices_ProfileId",
                table: "ProfileOffices",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCompetences_ProfileId",
                table: "ProfileCompetences",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_ProfileId",
                table: "Competences",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Profiles_ProfileId",
                table: "Competences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
