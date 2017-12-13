using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TandE.Migrations
{
    public partial class autodates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RecipeIngredient",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "RecipeIngredient",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "IdeaSubCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "IdeaSubCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "IdeaSubCategory");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "IdeaSubCategory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Category");
        }
    }
}
