using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class CondomoniumInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Condominium");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Condominium",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ComercialPhone",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Condominium",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDDCellPhone",
                table: "Condominium",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDDComercialPhone",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Condominium",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Condominium",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Condominium",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "ComercialPhone",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "DDDCellPhone",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "DDDComercialPhone",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Name",
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Condominium",
                nullable: false,
                defaultValue: "");
        }
    }
}
