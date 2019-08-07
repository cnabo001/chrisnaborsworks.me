using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChrisNaborsWorks.Migrations
{
    public partial class AddingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MarketCap = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    Supply = table.Column<string>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCurrencies");
        }
    }
}
