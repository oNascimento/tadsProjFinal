using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace projFinal.Migrations
{
    public partial class LocadoraAgrVai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Movies_movieid",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_userid",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_movieid",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_userid",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Borrows",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "movieid",
                table: "Borrows",
                newName: "movieId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Borrows",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Borrows",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Borrows",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "Borrows",
                newName: "movieid");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "Borrows",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "movieid",
                table: "Borrows",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_movieid",
                table: "Borrows",
                column: "movieid");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_userid",
                table: "Borrows",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Movies_movieid",
                table: "Borrows",
                column: "movieid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_userid",
                table: "Borrows",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
