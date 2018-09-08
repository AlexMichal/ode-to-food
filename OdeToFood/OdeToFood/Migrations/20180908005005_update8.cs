using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_Cuisine",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_Cuisine",
                table: "Restaurants");
        }
    }
}
