using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HbgKontoret.Data.Migrations
{
    public partial class reviseentitiesanddtosforauthentication04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
