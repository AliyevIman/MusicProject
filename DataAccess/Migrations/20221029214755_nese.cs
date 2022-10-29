using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class nese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianShows_User_UserId",
                table: "MusicianShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Albums_AlbumsId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumsId",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MusicianShows",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianShows_User_UserId",
                table: "MusicianShows",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Albums_AlbumsId",
                table: "Musics",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianShows_User_UserId",
                table: "MusicianShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Albums_AlbumsId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumsId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MusicianShows",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianShows_User_UserId",
                table: "MusicianShows",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Albums_AlbumsId",
                table: "Musics",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
