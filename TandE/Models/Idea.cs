using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TandE.Models
{
    public class Idea : BaseEntity
    {
        public int IdeaID { get; set; }
        public string IdeaName { get; set; }
        public string RefURL1 { get; set; }
        public int CategoryID { get; set; }
        public string InitialNotes { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Category Category { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        private ICollection<IdeaSubCategory> _subCategories;
        public ICollection<IdeaSubCategory> SubCategories
        {
            get
            {
                return _subCategories ?? (_subCategories = new List<IdeaSubCategory>());
            }
            set
            {
                _subCategories = value;
            }
        }


    }

}