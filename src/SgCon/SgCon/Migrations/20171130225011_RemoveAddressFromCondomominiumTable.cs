using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class RemoveAddressFromCondomominiumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Condominium");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Condominium",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Condominium",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Condominium",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Condominium",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Condominium",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Condominium",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Condominium",
                nullable: false,
                defaultValue: "");
        }
    }
}
