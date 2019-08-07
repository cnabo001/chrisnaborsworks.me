using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChrisNaborsWorks.Migrations
{
    public partial class CryptoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Store",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "supply",
                table: "Store",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LikesId",
                table: "CryptoCurrencies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CryptoCurrencies_LikesId",
                table: "CryptoCurrencies",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CryptoCurrencies_Likes_LikesId",
                table: "CryptoCurrencies",
                column: "LikesId",
                principalTable: "Likes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CryptoCurrencies_Likes_LikesId",
                table: "CryptoCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_CryptoCurrencies_LikesId",
                table: "CryptoCurrencies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "supply",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "CryptoCurrencies");
        }
    }
}
