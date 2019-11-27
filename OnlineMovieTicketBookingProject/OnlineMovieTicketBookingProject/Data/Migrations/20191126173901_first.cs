using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieTicketBookingProject.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNo = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_Name = table.Column<string>(nullable: true),
                    Movie_Description = table.Column<string>(nullable: true),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    MoviePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookingTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNo = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateToPresent = table.Column<DateTime>(nullable: false),
                    MovieDetailsId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingTicket_MovieDetails_MovieDetailsId",
                        column: x => x.MovieDetailsId,
                        principalTable: "MovieDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_MovieDetailsId",
                table: "BookingTicket",
                column: "MovieDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTicket");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "MovieDetails");
        }
    }
}
