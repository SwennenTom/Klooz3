using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Data.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoriesId);
                });

            migrationBuilder.CreateTable(
                name: "partners",
                columns: table => new
                {
                    partnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    partnerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    partnerLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partners", x => x.partnerId);
                });

            migrationBuilder.CreateTable(
                name: "teamregies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emailadress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamregies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "experiments",
                columns: table => new
                {
                    experimentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    experimentImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentCardFrontText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentCardBackText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriesId = table.Column<int>(type: "int", nullable: true),
                    experimentShortText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentPartners = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentKickOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    experimentwickedProblemsToSmartSolutions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimenttargetAndImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentTouchstone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentPhotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experimentPublished = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiments", x => x.experimentId);
                    table.ForeignKey(
                        name: "FK_experiments_categories_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "categories",
                        principalColumn: "categoriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiments_categoriesId",
                table: "experiments",
                column: "categoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experiments");

            migrationBuilder.DropTable(
                name: "partners");

            migrationBuilder.DropTable(
                name: "teamregies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
