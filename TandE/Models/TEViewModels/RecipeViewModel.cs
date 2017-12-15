using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TandE.Models.TEViewModels
{
    public class RecipeViewModel
    {
        //public RecipeViewModel(Recipe recipe)
        //{
        //    this.Recipe = recipe;
        //}
        public Recipe Recipe { get; set; }

        //[HiddenInput]
        //public Recipe RecipeID { get; set; }
        public RecipeIngredient RecipeIngredient { get; set; }

        public int IngredientId { get; set; }
        public List<SelectListItem> IngredientIds { get; set; }




    }
}
