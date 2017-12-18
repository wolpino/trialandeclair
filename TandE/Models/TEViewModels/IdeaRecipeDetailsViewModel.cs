using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandE.Models.TEViewModels
{
    public class IdeaRecipeDetailsViewModel
    {
        public IdeaRecipeDetailsViewModel()
        {
            RecipeVersions = new List<Recipe>();
        }
        public Recipe Recipe { get; set; }

        public Idea Idea { get; set; }

        public RecipeIngredient RecipeIngredient { get; set; }

        public List<RecipeIngredient> CurrentRecipeIngredients { get; set; }

        public List<Recipe> RecipeVersions { get; set; }





    }
}

