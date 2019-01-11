using Microsoft.EntityFrameworkCore.Migrations;

namespace PetPlayBackend.Domain.Migrations
{
    public partial class addedqr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QRUrl",
                table: "Toys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRUrl",
                table: "Toys");
        }
    }
}
