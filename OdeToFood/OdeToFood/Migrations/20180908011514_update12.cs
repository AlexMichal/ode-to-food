using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineTypeId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CuisineTypeId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "CuisineTypes",
                newName: "CuisineId");

            migrationBuilder.RenameColumn(
                name: "Cuisine",
                table: "Restaurants",
                newName: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants",
                column: "CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants",
                column: "CuisineId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "CuisineId",
                schema: "dbo",
                table: "CuisineTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CuisineId",
                table: "Restaurants",
                newName: "Cuisine");

            migrationBuilder.AddColumn<int>(
                name: "CuisineTypeId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineTypeId",
                table: "Restaurants",
                column: "CuisineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants",
                column: "CuisineTypeId",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
