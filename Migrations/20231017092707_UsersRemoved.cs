using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class UsersRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experiments_User_experimentLastModifiedByuserId",
                table: "experiments");

            migrationBuilder.DropForeignKey(
                name: "FK_experiments_User_experimentOwneruserId",
                table: "experiments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_experiments_experimentLastModifiedByuserId",
                table: "experiments");

            migrationBuilder.DropIndex(
                name: "IX_experiments_experimentOwneruserId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentLastModifiedByuserId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentOwneruserId",
                table: "experiments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "experimentLastModifiedByuserId",
                table: "experiments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "experimentOwneruserId",
                table: "experiments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userAchternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAdressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userGemeente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userIsAccountActive = table.Column<bool>(type: "bit", nullable: true),
                    userJoined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPostcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userVoornaam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiments_experimentLastModifiedByuserId",
                table: "experiments",
                column: "experimentLastModifiedByuserId");

            migrationBuilder.CreateIndex(
                name: "IX_experiments_experimentOwneruserId",
                table: "experiments",
                column: "experimentOwneruserId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiments_User_experimentLastModifiedByuserId",
                table: "experiments",
                column: "experimentLastModifiedByuserId",
                principalTable: "User",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiments_User_experimentOwneruserId",
                table: "experiments",
                column: "experimentOwneruserId",
                principalTable: "User",
                principalColumn: "userId");
        }
    }
}
