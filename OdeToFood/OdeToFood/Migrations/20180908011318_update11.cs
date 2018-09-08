using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_Cuisine",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_Cuisine",
                table: "Restaurants");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Cuisine",
                table: "Restaurants",
                column: "Cuisine");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_Cuisine",
                table: "Restaurants",
                column: "Cuisine",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
