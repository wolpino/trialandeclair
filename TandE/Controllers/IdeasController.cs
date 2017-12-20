using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TandE.Data;
using TandE.Models;
using TandE.Models.TEViewModels;
using Microsoft.AspNetCore.Identity;

namespace TandE.Controllers
{
    public class IdeasController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly TrialEclairContext _context;

        public IdeasController(TrialEclairContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            IdeaViewModel ideas = new IdeaViewModel()
            {
                ListofCategories = _context
                                   .Categories
                                   .OrderBy(c =>c.CategoryName)
                                   .ToList()
            };
            ideas.ListofIdeas = _context.Ideas.Include(i => i.Category).Where(item => user.Id == item.ApplicationUserId).OrderBy(i => i.IdeaName).ToList();
            return View(ideas);
        }

        // GET: Ideas
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var trialEclairContext = _context.Ideas.Include(i => i.Category).Where(item => user.Id == item.ApplicationUserId);
            return View(await trialEclairContext.ToListAsync());
        }

        // GET: Ideas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Ideas
                .Include(i => i.Category)
                .SingleOrDefaultAsync(m => m.IdeaID == id);
            if (idea == null)
            {
                return NotFound();
            }
            IdeaRecipeDetailsViewModel ideaRecipe = new IdeaRecipeDetailsViewModel()
            {
                //order by revision at
                RecipeVersions = _context.Recipes
                                 .Where(r => r.IdeaID == id)
                                 .ToList(),

                ListofSubs = _context.IdeaSubCategories.Include(r =>r.SubCategory).Where(s => s.IdeaID == id).ToList()
            };

            ideaRecipe.Idea = idea;
            foreach(var recipe in ideaRecipe.RecipeVersions)
            {
                recipe.Ingredients = _context
                     .RecipeIngredients
                     .Include(r => r.Ingredient)
                     .Where(item => recipe.RecipeID == item.RecipeID)
                     .ToList();
            }
            return View(ideaRecipe);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            var idea = new Idea();
            idea.SubCategories = new List<IdeaSubCategory>();
            PopulateSubCategoryData(idea);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeaID,IdeaName,RefURL1,CategoryID,InitialNotes,CreatedAt")] Idea idea, string[] selectedSubCategories)
        {
            var user = await _userManager.GetUserAsync(User);


            if (selectedSubCategories != null)
            {
                foreach (var subcategory in selectedSubCategories)
                {
                    var subToAdd = new IdeaSubCategory { IdeaID = idea.IdeaID, SubCategoryID = int.Parse(subcategory) };
                    idea.SubCategories.Add(subToAdd);
                }
            }
            if(ModelState.IsValid)
            {
                idea.ApplicationUserId = user.Id;
                _context.Add(idea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }
            PopulateSubCategoryData(idea);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", idea.CategoryID);
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Ideas
                .Include(i => i.SubCategories).ThenInclude(i => i.SubCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.IdeaID == id);
            if (idea == null)
            {
                return NotFound();
            }
            PopulateSubCategoryData(idea);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", idea.CategoryID);
            return View(idea);
        }

        private void PopulateSubCategoryData(Idea idea)
        {
            var allSubCategories = _context.Subcategories;
            var ideaSubCategories = new HashSet<int>(idea.SubCategories.Select(s => s.SubCategoryID));
            var viewModel = new List<SubCategoryData>();
            foreach(var subcategory in allSubCategories)
            {
                viewModel.Add(new SubCategoryData
                {
                    SubCategoryID = subcategory.SubCategoryID,
                    SubCategoryName = subcategory.SubCategoryName,
                    Assigned = ideaSubCategories.Contains(subcategory.SubCategoryID)
                });
            }
            ViewData["SubCategories"] = viewModel;
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedSubCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaToUpdate = await _context.Ideas
                        .Include(i => i.SubCategories)
                            .ThenInclude(i => i.SubCategory)
                        .SingleOrDefaultAsync(m => m.IdeaID == id);
            
            if(await TryUpdateModelAsync<Idea>(
                ideaToUpdate,
                "",
                i => i.IdeaName, i => i.RefURL1, i => i.CategoryID, i => i.InitialNotes))
            {

            UpdateIdeaSubCategories(selectedSubCategories, ideaToUpdate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return RedirectToAction(nameof(Dashboard));
        }
            UpdateIdeaSubCategories(selectedSubCategories, ideaToUpdate);
            PopulateSubCategoryData(ideaToUpdate);
        return View(ideaToUpdate);
        }

        private void UpdateIdeaSubCategories(string[] selectedSubCategories, Idea ideaToUpdate)
        {
            if(selectedSubCategories == null)
            {
                ideaToUpdate.SubCategories = new List<IdeaSubCategory>();
                return;
            }

            var selectedSubCategoriesHS = new HashSet<string>(selectedSubCategories);
            var ideaSubCategories = new HashSet<int>
                (ideaToUpdate.SubCategories.Select(s => s.SubCategory.SubCategoryID));
            foreach (var subcategory in _context.Subcategories)
            {
                if (selectedSubCategoriesHS.Contains(subcategory.SubCategoryID.ToString()))
                {
                    if (!ideaSubCategories.Contains(subcategory.SubCategoryID))
                    {
                        ideaToUpdate.SubCategories.Add(new IdeaSubCategory { IdeaID = ideaToUpdate.IdeaID, SubCategoryID = subcategory.SubCategoryID });
                    }
                }
                else
                {
                    if (ideaSubCategories.Contains(subcategory.SubCategoryID))
                    {
                        IdeaSubCategory subToRemove = ideaToUpdate.SubCategories.SingleOrDefault(s => s.SubCategoryID == subcategory.SubCategoryID);
                        _context.Remove(subToRemove);
                    }

                }


            }
        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Ideas
                .Include(i => i.Category)
                .SingleOrDefaultAsync(m => m.IdeaID == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Idea idea = await _context.Ideas
                .Include(i =>i.SubCategories)
                .SingleAsync(m => m.IdeaID == id);

            _context.Ideas.Remove(idea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaExists(int id)
        {
            return _context.Ideas.Any(e => e.IdeaID == id);
        }
    }
}
