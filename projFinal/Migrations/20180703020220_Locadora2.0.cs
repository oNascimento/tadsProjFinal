using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace projFinal.Migrations
{
    public partial class Locadora20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Borrows_Borrowid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Borrowid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Borrowid",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Borrows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "movieid",
                table: "Borrows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_movieid",
                table: "Borrows",
                column: "movieid");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Movies_movieid",
                table: "Borrows",
                column: "movieid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Movies_movieid",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_movieid",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "movieid",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "Borrowid",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Borrowid",
                table: "Movies",
                column: "Borrowid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Borrows_Borrowid",
                table: "Movies",
                column: "Borrowid",
                principalTable: "Borrows",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
