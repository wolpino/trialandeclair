﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TandE.Data;
using TandE.Models;

namespace TandE.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171217180531_Userids")]
    partial class Userids
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TandE.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TandE.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDesc");

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TandE.Models.Idea", b =>
                {
                    b.Property<int>("IdeaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdeaName");

                    b.Property<string>("InitialNotes");

                    b.Property<string>("RefURL1");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("IdeaID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Idea");
                });

            modelBuilder.Entity("TandE.Models.IdeaSubCategory", b =>
                {
                    b.Property<int>("IdeaSubCategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdeaID");

                    b.Property<int>("SubCategoryID");

                    b.HasKey("IdeaSubCategoryID");

                    b.HasIndex("IdeaID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("IdeaSubCategory");
                });

            modelBuilder.Entity("TandE.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredientName");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("IngredientID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("TandE.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdeaID");

                    b.Property<string>("Method");

                    b.Property<string>("RecipeName")
                        .IsRequired();

                    b.Property<string>("RefURL2");

                    b.Property<string>("RefURL3");

                    b.Property<string>("RefURL4");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VersionNotes");

                    b.HasKey("RecipeID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("IdeaID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("TandE.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredientID");

                    b.Property<int>("Measurement");

                    b.Property<int>("RecipeID");

                    b.Property<int>("Unit");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("RecipeIngredientID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("TandE.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubCategoryDesc");

                    b.Property<string>("SubCategoryName");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("SubCategoryID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TandE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TandE.Models.Idea", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser", "User")
                        .WithMany("UserIdeas")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TandE.Models.Category", "Category")
                        .WithMany("Ideas")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TandE.Models.IdeaSubCategory", b =>
                {
                    b.HasOne("TandE.Models.Idea", "Idea")
                        .WithMany("SubCategories")
                        .HasForeignKey("IdeaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TandE.Models.SubCategory", "SubCategory")
                        .WithMany("Ideas")
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TandE.Models.Ingredient", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("TandE.Models.Recipe", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser", "User")
                        .WithMany("UserRecipes")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TandE.Models.Idea", "Idea")
                        .WithMany("Recipes")
                        .HasForeignKey("IdeaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TandE.Models.RecipeIngredient", b =>
                {
                    b.HasOne("TandE.Models.Ingredient", "Ingredient")
                        .WithMany("Recipes")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TandE.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TandE.Models.SubCategory", b =>
                {
                    b.HasOne("TandE.Models.ApplicationUser", "User")
                        .WithMany("UserSubCategories")
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}