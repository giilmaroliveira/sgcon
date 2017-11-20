using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class ChangeApartmentAndHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Condominium_CondominiumId",
                table: "Apartment");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_CondominiumId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Block",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "CondominiumId",
                table: "Apartment");

            migrationBuilder.AddColumn<int>(
                name: "TowerNumber",
                table: "Condominium",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Apartment",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TowerId",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    Block = table.Column<string>(type: "longtext", nullable: false),
                    CondominiumId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tower_Condominium_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_TowerId",
                table: "Apartment",
                column: "TowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tower_CondominiumId",
                table: "Tower",
                column: "CondominiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Tower_TowerId",
                table: "Apartment",
                column: "TowerId",
                principalTable: "Tower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Tower_TowerId",
                table: "Apartment");

            migrationBuilder.DropTable(
                name: "Tower");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_TowerId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "TowerNumber",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "TowerId",
                table: "Apartment");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Condominium",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Block",
                table: "Apartment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CondominiumId",
                table: "Apartment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    ApartmentId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Floor = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                    table.ForeignKey(
                        name: "FK_House_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_CondominiumId",
                table: "Apartment",
                column: "CondominiumId");

            migrationBuilder.CreateIndex(
                name: "IX_House_ApartmentId",
                table: "House",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Condominium_CondominiumId",
                table: "Apartment",
                column: "CondominiumId",
                principalTable: "Condominium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
