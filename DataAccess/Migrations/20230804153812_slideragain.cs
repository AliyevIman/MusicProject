using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class slideragain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture1",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Picture2",
                table: "Slider");

            migrationBuilder.RenameColumn(
                name: "Picture3",
                table: "Slider",
                newName: "Picture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Slider",
                newName: "Picture3");

            migrationBuilder.AddColumn<string>(
                name: "Picture1",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture2",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
