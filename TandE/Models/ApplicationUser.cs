using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TandE.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Idea> UserIdeas { get; set; }
        public List<Recipe> UserRecipes { get; set; }
        public List<SubCategory> UserSubCategories { get; set; }
        public List<Ingredient> UserIngredients { get; set; }

        public ApplicationUser()
        {
            UserIdeas = new List<Idea>();
            UserRecipes = new List<Recipe>();
            UserSubCategories = new List<SubCategory>();
            UserIngredients = new List<Ingredient>();
        }


    }
}
