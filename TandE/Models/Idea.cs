using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TandE.Models
{
    public class Idea
    {
        public int IdeaID { get; set; }
        public string IdeaName { get; set; }
        public string RefURL1 { get; set; }
        public int CategoryID { get; set; }
        public string InitialNotes { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<IdeaSubCategory> SubCategories { get; set; }


    }

}