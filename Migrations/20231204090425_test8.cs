using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_AspNetUsers_UserId",
                table: "userexperimenten");

            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "userexperimenten",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ExperimentId",
                table: "userexperimenten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_AspNetUsers_UserId",
                table: "userexperimenten",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten",
                column: "ExperimentId",
                principalTable: "experiments",
                principalColumn: "experimentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_AspNetUsers_UserId",
                table: "userexperimenten");

            migrationBuilder.DropForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "userexperimenten",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExperimentId",
                table: "userexperimenten",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_AspNetUsers_UserId",
                table: "userexperimenten",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userexperimenten_experiments_ExperimentId",
                table: "userexperimenten",
                column: "ExperimentId",
                principalTable: "experiments",
                principalColumn: "experimentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
