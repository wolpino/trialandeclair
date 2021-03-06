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

namespace TandE.Migrations
{
    [DbContext(typeof(TrialEclairContext))]
    [Migration("20171215235456_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TandE.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDesc");

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TandE.Models.Idea", b =>
                {
                    b.Property<int>("IdeaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdeaName");

                    b.Property<string>("InitialNotes");

                    b.Property<string>("RefURL1");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("IdeaID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Idea");
                });

            modelBuilder.Entity("TandE.Models.IdeaSubCategory", b =>
                {
                    b.Property<int>("IdeaID");

                    b.Property<int>("SubCategoryID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("IdeaID", "SubCategoryID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("IdeaSubCategory");
                });

            modelBuilder.Entity("TandE.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredientName");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("TandE.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("VersionNotes");

                    b.HasKey("RecipeID");

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
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("RecipeIngredientID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("TandE.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubCategoryDesc");

                    b.Property<string>("SubCategoryName");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("SubCategoryID");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("TandE.Models.Idea", b =>
                {
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

            modelBuilder.Entity("TandE.Models.Recipe", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
