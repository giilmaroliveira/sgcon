using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class ChangeTower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Tower");

            migrationBuilder.AddColumn<int>(
                name: "FloorsNumber",
                table: "Tower",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorsNumber",
                table: "Tower");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Tower",
                nullable: false,
                defaultValue: 0);
        }
    }
}
