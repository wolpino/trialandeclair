using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TandE.Models
{
    public class Recipe : BaseEntity
    {
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
        public ICollection<RecipeIngredient> Ingredients { get; set; }


    }
}
