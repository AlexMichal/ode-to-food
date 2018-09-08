using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_Id",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_Id",
                table: "Restaurants",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
