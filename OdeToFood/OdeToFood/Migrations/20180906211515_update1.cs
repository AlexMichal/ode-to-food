using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuisine",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "CuisineType",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CuisineType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineType", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineType_CuisineType",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "CuisineType");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineType",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CuisineType",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "Cuisine",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);
        }
    }
}
