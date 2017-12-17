using TandE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TandE.Data
{
    public class TrialEclairContext : IdentityDbContext<ApplicationUser>
    {
        public TrialEclairContext(DbContextOptions<TrialEclairContext> options) : base(options)
        {
        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<IdeaSubCategory> IdeaSubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Idea>().ToTable("Idea");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategory");
            modelBuilder.Entity<RecipeIngredient>().ToTable("RecipeIngredient");
            modelBuilder.Entity<IdeaSubCategory>().ToTable("IdeaSubCategory");



            modelBuilder.Entity<IdeaSubCategory>()
                .HasKey(c => new { c.IdeaID, c.SubCategoryID });
        }

    }
}
