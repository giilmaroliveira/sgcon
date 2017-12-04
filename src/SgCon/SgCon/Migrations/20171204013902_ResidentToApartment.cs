using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class ResidentToApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Resident",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ApartmentId",
                table: "Resident",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Apartment_ApartmentId",
                table: "Resident",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Apartment_ApartmentId",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Resident_ApartmentId",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Resident");
        }
    }
}
