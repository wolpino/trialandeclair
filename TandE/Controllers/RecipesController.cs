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
    public class RecipesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TrialEclairContext _context;

        public RecipesController(TrialEclairContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }
            var trialEclairContext = _context.Recipes.Include(r => r.Idea).Where(item => user.Id == item.ApplicationUserId);
            return View(await trialEclairContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Idea)
                .Include(r => r.Ingredients)
                .SingleOrDefaultAsync(m => m.RecipeID == id);

            recipe.Ingredients = _context
                                 .RecipeIngredients
                                 .Include(r => r.Ingredient)
                                 .Where(item => recipe.RecipeID == item.RecipeID)
                                 .ToList();
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        ///will be removed
        public IActionResult Create()
        {
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID");
            return View();
        }

        ///will be removed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID", recipe.IdeaID);

            return RedirectToAction("RecipeCreatePage", "TE", recipe);
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromIdea(int? id)
        {
            var idea = await _context.Ideas.SingleOrDefaultAsync(m => m.IdeaID == id);
 
            if (ModelState.IsValid)
            {
                Recipe recipe = new Recipe
                {
                    RecipeName = idea.IdeaName,
                    IdeaID = idea.IdeaID,
                    RefURL2 = "",
                    RefURL3 = "",
                    RefURL4 = "",
                    VersionNotes = "",
                    ApplicationUserId = idea.ApplicationUserId
                };
                Recipe newR = _context.Add(recipe).Entity;
                await _context.SaveChangesAsync();
                return RedirectToAction("EditCreatedRecipe", "Recipes", new { id = newR.RecipeID });
            }
            return RedirectToAction("Index", "Ideas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewVersion(int? id)
        {
            var previousversion = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeID == id);
            previousversion.Ingredients = _context
                                            .RecipeIngredients
                                            .Where(item => previousversion.RecipeID == item.RecipeID)
                                            .ToList();
            previousversion.NextVersionCreated = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                Recipe recipe = new Recipe
                {
                    RecipeName = previousversion.RecipeName,
                    IdeaID = previousversion.IdeaID,
                    RefURL2 = previousversion.RefURL2,
                    RefURL3 = previousversion.RefURL3,
                    RefURL4 = previousversion.RefURL4,
                    VersionNotes = "",
                    ApplicationUserId = previousversion.ApplicationUserId,
                };
                Recipe newR = _context.Add(recipe).Entity;
                foreach(var ingred in previousversion.Ingredients)
                {
                    RecipeIngredient recipeIngredient = new RecipeIngredient
                    {
                        RecipeID = recipe.RecipeID,
                        IngredientID = ingred.IngredientID,
                        Measurement = ingred.Measurement,
                        Unit = ingred.Unit
                    };
                    _context.Add(recipeIngredient);
                    _context.SaveChanges();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("EditCreatedRecipe", "Recipes", new { id = newR.RecipeID });
            }
            return RedirectToAction("Index", "Ideas");
        }

       
        public async Task<IActionResult> EditCreatedRecipe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }


            RecipeViewModel newrecipe = new RecipeViewModel()
            {
                CurrentRecipeIngredients = _context
                                            .RecipeIngredients
                                            .Where(item => recipe.RecipeID == item.RecipeID)
                                            .ToList()
                
            };

            newrecipe.ListOfIngredients = PopulateIngredients();
            newrecipe.Recipe = recipe;
            return View(newrecipe);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCreatedRecipe(int id, [Bind("RecipeID,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditCreatedRecipe", "Recipes", new { id = id });
            }
            RecipeViewModel newrecipe = new RecipeViewModel();
            newrecipe.Recipe = recipe;
            newrecipe.ListOfIngredients = PopulateIngredients();
            return View(newrecipe);
        }

        public List<SelectListItem> PopulateIngredients()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var ingredients = _context.Ingredients.ToList();
            foreach (var ingredient in ingredients)
            {
                items.Add(new SelectListItem
                {
                    Text = ingredient.IngredientName.ToString(),
                    Value = ingredient.IngredientID.ToString(),
                    
                });
            }
            return items;
        }

        //GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID", recipe.IdeaID);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID", recipe.IdeaID);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Idea)
                .SingleOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeID == id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }

    }
}
