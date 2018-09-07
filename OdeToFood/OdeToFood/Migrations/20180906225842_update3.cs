using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineType_CuisineType",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineType",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuisineType",
                table: "CuisineType");

            migrationBuilder.DropColumn(
                name: "CuisineType",
                table: "Restaurants");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "CuisineType",
                newName: "CuisineTypes",
                newSchema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "CuisineId",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuisineTypes",
                schema: "dbo",
                table: "CuisineTypes",
                column: "Id");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuisineTypes",
                schema: "dbo",
                table: "CuisineTypes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CuisineId",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "CuisineTypes",
                schema: "dbo",
                newName: "CuisineType");

            migrationBuilder.AddColumn<int>(
                name: "CuisineType",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuisineType",
                table: "CuisineType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineType",
                table: "Restaurants",
                column: "CuisineType");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineType_CuisineType",
                table: "Restaurants",
                column: "CuisineType",
                principalTable: "CuisineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
