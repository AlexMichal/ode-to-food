using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineIdId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "CuisineIdId",
                table: "Restaurants",
                newName: "CuisineId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineIdId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants",
                column: "CuisineId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "CuisineId",
                table: "Restaurants",
                newName: "CuisineIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineIdId",
                table: "Restaurants",
                column: "CuisineIdId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
