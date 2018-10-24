using Microsoft.EntityFrameworkCore.Migrations;

namespace PetPlayBackend.Domain.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Toys_ToyId",
                table: "Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Access",
                table: "Access");

            migrationBuilder.RenameTable(
                name: "Access",
                newName: "Accesses");

            migrationBuilder.RenameIndex(
                name: "IX_Access_ToyId",
                table: "Accesses",
                newName: "IX_Accesses_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses",
                columns: new[] { "UserId", "ToyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_Toys_ToyId",
                table: "Accesses",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_Users_UserId",
                table: "Accesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_Toys_ToyId",
                table: "Accesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_Users_UserId",
                table: "Accesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses");

            migrationBuilder.RenameTable(
                name: "Accesses",
                newName: "Access");

            migrationBuilder.RenameIndex(
                name: "IX_Accesses_ToyId",
                table: "Access",
                newName: "IX_Access_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Access",
                table: "Access",
                columns: new[] { "UserId", "ToyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Toys_ToyId",
                table: "Access",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
