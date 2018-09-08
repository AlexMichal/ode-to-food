using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OdeToFood.Migrations
{
    public partial class update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuisineId",
                schema: "dbo",
                table: "CuisineTypes",
                newName: "CuisineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuisineTypeId",
                schema: "dbo",
                table: "CuisineTypes",
                newName: "CuisineId");
        }
    }
}
