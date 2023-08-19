using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.DataAcess.Migrations
{
    public partial class Add_PalleteId_To_Box : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "PalleteId",
                table: "Boxes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes",
                column: "PalleteId",
                principalTable: "Palletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "PalleteId",
                table: "Boxes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Palletes_PalleteId",
                table: "Boxes",
                column: "PalleteId",
                principalTable: "Palletes",
                principalColumn: "Id");
        }
    }
}
