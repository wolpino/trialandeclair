using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TandE.Migrations
{
    public partial class UserIdaddedtoIdeaSubCatgoryIngredientsandRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Idea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_ApplicationUserId",
                table: "SubCategory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ApplicationUserId",
                table: "Recipe",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_ApplicationUserId",
                table: "Ingredient",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_ApplicationUserId",
                table: "Idea",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Idea_ApplicationUser_ApplicationUserId",
                table: "Idea",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_ApplicationUser_ApplicationUserId",
                table: "Ingredient",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_ApplicationUser_ApplicationUserId",
                table: "Recipe",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_ApplicationUser_ApplicationUserId",
                table: "SubCategory",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idea_ApplicationUser_ApplicationUserId",
                table: "Idea");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_ApplicationUser_ApplicationUserId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_ApplicationUser_ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_ApplicationUser_ApplicationUserId",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_ApplicationUserId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_ApplicationUserId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Idea_ApplicationUserId",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Idea");
        }
    }
}
