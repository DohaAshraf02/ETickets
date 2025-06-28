using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageURLAndAddMovieStatusToMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Movies",
                newName: "ImgUrl");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Movies",
                newName: "ImageUrl");
        }
    }
}
