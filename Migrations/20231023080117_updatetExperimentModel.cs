using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class updatetExperimentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experiments_categories_categoriesId",
                table: "experiments");

            migrationBuilder.DropForeignKey(
                name: "FK_experiments_partners_experimentPartnerspartnerId",
                table: "experiments");

            migrationBuilder.DropIndex(
                name: "IX_experiments_categoriesId",
                table: "experiments");

            migrationBuilder.DropIndex(
                name: "IX_experiments_experimentPartnerspartnerId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "categoriesId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentCardFrontText",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentCreatedDate",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentEndDate",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentKickOffDate",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentLastModified",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentPartnerspartnerId",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentStatus",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentTouchstone",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimenttargetAndImpact",
                table: "experiments");

            migrationBuilder.DropColumn(
                name: "experimentwickedProblemsToSmartSolutions",
                table: "experiments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoriesId",
                table: "experiments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experimentCardFrontText",
                table: "experiments",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "experimentKickOffDate",
                table: "experiments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "experimentLastModified",
                table: "experiments",
                type: "datetime2",
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

            migrationBuilder.AddColumn<string>(
                name: "experimentTouchstone",
                table: "experiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experimenttargetAndImpact",
                table: "experiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experimentwickedProblemsToSmartSolutions",
                table: "experiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_experiments_categoriesId",
                table: "experiments",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_experiments_experimentPartnerspartnerId",
                table: "experiments",
                column: "experimentPartnerspartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiments_categories_categoriesId",
                table: "experiments",
                column: "categoriesId",
                principalTable: "categories",
                principalColumn: "categoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiments_partners_experimentPartnerspartnerId",
                table: "experiments",
                column: "experimentPartnerspartnerId",
                principalTable: "partners",
                principalColumn: "partnerId");
        }
    }
}
