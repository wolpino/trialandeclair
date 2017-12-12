using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandE.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDesc { get; set; }

        public ICollection<IdeaSubCategory> Ideas { get; set; }
    }
}
