using Microsoft.EntityFrameworkCore.Migrations;

namespace HbgKontoret.Data.Migrations
{
    public partial class revise_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Users_UserId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Competences",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Competences_UserId",
                table: "Competences",
                newName: "IX_Competences_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Profiles_ProfileId",
                table: "Competences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Profiles_ProfileId",
                table: "Competences");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Competences",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Competences_ProfileId",
                table: "Competences",
                newName: "IX_Competences_UserId");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Users_UserId",
                table: "Competences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
