using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenresId",
                table: "movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenresId",
                table: "movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenresId",
                table: "movies",
                column: "GenresId",
                principalTable: "genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenresId",
                table: "movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenresId",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenresId",
                table: "movies",
                column: "GenresId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
