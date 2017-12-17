using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TandE.Migrations
{
    public partial class UserIDandManytoManyPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "IdeaSubCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "IdeaSubCategory");

            migrationBuilder.AddColumn<int>(
                name: "IdeaSubCategoryID",
                table: "IdeaSubCategory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdeaSubCategoryID",
                table: "IdeaSubCategory");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "IdeaSubCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "IdeaSubCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
