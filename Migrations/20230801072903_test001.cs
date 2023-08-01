using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class test001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "experimentPartners",
                table: "experiments");

            migrationBuilder.AddColumn<DateTime>(
                name: "experimentCreatedDate",
                table: "experiments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "experimentEndDate",
                table: "experiments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "experimentLastModified",
                table: "experiments",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "experimentPartnerspartnerId",
                table: "experiments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "experimentStatus",
                table: "experiments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userVoornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAchternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAdressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPostcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userGemeente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userJoined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userIsAccountActive = table.Column<bool>(type: "bit", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_experiments_experimentPartnerspartnerId",
                table: "experiments",
                column: "experimentPartnerspartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiments_partners_experimentPartnerspartnerId",
                table: "experiments",
                column: "experimentPartnerspartnerId",
                principalTable: "partners",
                principalColumn: "partnerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experiments_partners_experimentPartnerspartnerId",
                table: "experiments");

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

            migrationBuilder.DropIndex(
                name: "IX_experiments_experimentPartnerspartnerId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentCreatedDate",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentEndDate",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentLastModified",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentLastModifiedByuserId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentOwneruserId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentPartnerspartnerId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentStatus",
                table: "experiments");

            migrationBuilder.AddColumn<string>(
                name: "experimentPartners",
                table: "experiments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
