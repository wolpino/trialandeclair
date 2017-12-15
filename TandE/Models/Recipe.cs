﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TandE.Models
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            Ingredients = new List<RecipeIngredient>();
        }
        public int RecipeID { get; set; }
        [Required]
        public string RecipeName { get; set; }
        public string RefURL2 { get; set; }
        public string RefURL3 { get; set; }
        public string RefURL4 { get; set; }
        public string VersionNotes { get; set; }
        public int IdeaID { get; set; }
        public string Method { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //Nullable but needs to fill when next is created
        //public DateTime RevisedAt { get; set; }

        public Idea Idea { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }


    }
}
