using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SgConAPI.Migrations
{
    public partial class CondominiumAddressRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Condominium",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Condominium_AddressId",
                table: "Condominium",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condominium_Address_AddressId",
                table: "Condominium",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominium_Address_AddressId",
                table: "Condominium");

            migrationBuilder.DropIndex(
                name: "IX_Condominium_AddressId",
                table: "Condominium");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Condominium");
        }
    }
}
