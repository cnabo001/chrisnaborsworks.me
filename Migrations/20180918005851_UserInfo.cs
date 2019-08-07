using Microsoft.EntityFrameworkCore.Migrations;

namespace ChrisNaborsWorks.Migrations
{
    public partial class UserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassWord = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
