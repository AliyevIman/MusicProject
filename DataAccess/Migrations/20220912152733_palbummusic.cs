using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class palbummusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusiciansMusic_Musicians_MusicianId",
                table: "MusiciansMusic");

            migrationBuilder.DropForeignKey(
                name: "FK_MusiciansMusic_Musics_MusicId",
                table: "MusiciansMusic");

            migrationBuilder.AddColumn<int>(
                name: "AlbumsId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MusicianId",
                table: "MusiciansMusic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MusicId",
                table: "MusiciansMusic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_AlbumsId",
                table: "Musics",
                column: "AlbumsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciansMusic_Musicians_MusicianId",
                table: "MusiciansMusic",
                column: "MusicianId",
                principalTable: "Musicians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciansMusic_Musics_MusicId",
                table: "MusiciansMusic",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id");

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
                name: "FK_MusiciansMusic_Musicians_MusicianId",
                table: "MusiciansMusic");

            migrationBuilder.DropForeignKey(
                name: "FK_MusiciansMusic_Musics_MusicId",
                table: "MusiciansMusic");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Albums_AlbumsId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_AlbumsId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "AlbumsId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "MusicianId",
                table: "MusiciansMusic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MusicId",
                table: "MusiciansMusic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciansMusic_Musicians_MusicianId",
                table: "MusiciansMusic",
                column: "MusicianId",
                principalTable: "Musicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusiciansMusic_Musics_MusicId",
                table: "MusiciansMusic",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
