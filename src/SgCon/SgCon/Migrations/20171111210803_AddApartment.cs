using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class AddApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Condominium_CondominiumId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_CondominiumId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "CondominiumId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "House");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Condominium");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "House",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "House",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "House",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Condominium",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    Block = table.Column<string>(type: "longtext", nullable: false),
                    CondominiumId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Condominium_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_ApartmentId",
                table: "House",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_CondominiumId",
                table: "Apartment",
                column: "CondominiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Apartment_ApartmentId",
                table: "House",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Apartment_ApartmentId",
                table: "House");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_House_ApartmentId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "House");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "House");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Condominium");

            migrationBuilder.AddColumn<int>(
                name: "CondominiumId",
                table: "House",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "House",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Condominium",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_House_CondominiumId",
                table: "House",
                column: "CondominiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Condominium_CondominiumId",
                table: "House",
                column: "CondominiumId",
                principalTable: "Condominium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
