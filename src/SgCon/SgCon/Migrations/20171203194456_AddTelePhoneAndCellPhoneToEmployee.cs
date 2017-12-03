using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class AddTelePhoneAndCellPhoneToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Employee",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComercialPhone",
                table: "Employee",
                type: "longtext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DDDCellPhone",
                table: "Employee",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDDComercialPhone",
                table: "Employee",
                type: "longtext",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ComercialPhone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DDDCellPhone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DDDComercialPhone",
                table: "Employee");
        }
    }
}
