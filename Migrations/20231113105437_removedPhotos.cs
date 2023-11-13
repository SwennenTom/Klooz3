using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klooz3.Migrations
{
    public partial class removedPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "experimentPhotos",
                table: "experiments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "experimentPhotos",
                table: "experiments",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
