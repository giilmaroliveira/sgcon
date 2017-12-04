using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class AddTelephoneToResident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Resident",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComercialPhone",
                table: "Resident",
                type: "longtext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DDDCellPhone",
                table: "Resident",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDDComercialPhone",
                table: "Resident",
                type: "longtext",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "ComercialPhone",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "DDDCellPhone",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "DDDComercialPhone",
                table: "Resident");
        }
    }
}
