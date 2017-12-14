using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandE.Models.TEViewModels
{
    public class RecipeViewModel
    {
        public RecipeViewModel(Recipe recipe)
        {
            this.Recipe = recipe;
        }
        public Recipe Recipe { get; set; }
        public RecipeIngredient Ingredients { get; set; }
    }
}
