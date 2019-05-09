using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviegram.Persistence.Migrations
{
    public partial class _1init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celebrities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    ProfilePhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCelebrities",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(nullable: false),
                    CelebrityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCelebrities", x => new { x.CelebrityId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieCelebrities_Celebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "Celebrities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCelebrities_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false),
                    ShowTimeStart = table.Column<DateTime>(nullable: false),
                    ShowTimeEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShowTimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCelebrities_MovieId",
                table: "MovieCelebrities",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowTimes_MovieId",
                table: "MovieShowTimes",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCelebrities");

            migrationBuilder.DropTable(
                name: "MovieShowTimes");

            migrationBuilder.DropTable(
                name: "Celebrities");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
