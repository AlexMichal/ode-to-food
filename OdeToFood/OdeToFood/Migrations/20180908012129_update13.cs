using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "CuisineId",
                table: "Restaurants",
                newName: "CuisineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants",
                column: "CuisineTypeId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "CuisineTypeId",
                table: "Restaurants",
                newName: "CuisineId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineTypeId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants",
                column: "CuisineId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
