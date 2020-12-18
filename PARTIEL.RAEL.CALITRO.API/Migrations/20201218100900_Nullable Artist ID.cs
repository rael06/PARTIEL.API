using Microsoft.EntityFrameworkCore.Migrations;

namespace PARTIEL.RAEL.CALITRO.API.Migrations
{
    public partial class NullableArtistID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Musics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Musics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
