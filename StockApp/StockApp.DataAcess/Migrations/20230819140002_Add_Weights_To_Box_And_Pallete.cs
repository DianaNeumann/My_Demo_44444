using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.DataAcess.Migrations
{
    public partial class Add_Weights_To_Box_And_Pallete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Palletes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Boxes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Palletes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Boxes");
        }
    }
}
