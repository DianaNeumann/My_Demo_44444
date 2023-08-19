using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.DataAcess.Migrations
{
    public partial class Add_Boxes_To_Pallete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PalleteId",
                table: "Boxes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalleteId",
                table: "Boxes",
                column: "PalleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes",
                column: "PalleteId",
                principalTable: "Palletes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_PalleteId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PalleteId",
                table: "Boxes");
        }
    }
}
