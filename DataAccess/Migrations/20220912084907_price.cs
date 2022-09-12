using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Discount",
                table: "LiveShows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LiveShows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "LiveShows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "LiveShows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "LiveShows");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LiveShows");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "LiveShows");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "LiveShows");
        }
    }
}
