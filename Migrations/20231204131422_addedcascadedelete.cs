using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class addedcascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten");

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten",
                column: "ExperimentId",
                principalTable: "experiments",
                principalColumn: "experimentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten");

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten",
                column: "ExperimentId",
                principalTable: "experiments",
                principalColumn: "experimentId");
        }
    }
}
