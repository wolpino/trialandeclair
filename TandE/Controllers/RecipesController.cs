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

namespace TandE.Controllers
{
    public class RecipesController : Controller
    {
        private readonly TrialEclairContext _context;

        public RecipesController(TrialEclairContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var trialEclairContext = _context.Recipes.Include(r => r.Idea);
            return View(await trialEclairContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Idea)
                .SingleOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID", recipe.IdeaID);

            return View(recipe);
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
                    VersionNotes = ""
                };
                Recipe newR = _context.Add(recipe).Entity;
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("CreateRecipe", "Recipes", new { id = newR.RecipeId });
            }
            return RedirectToAction("Index", "Ideas");
        }


        public async Task<IActionResult> CreateRecipe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }
            RecipeViewModel newrecipe = new RecipeViewModel(recipe);
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientName");
            return View(newrecipe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRecipe(int id, [Bind("RecipeId,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
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
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CreateRecipe", "Recipes", new { id = id });
            }
            RecipeViewModel newrecipe = new RecipeViewModel(recipe);

            return View(newrecipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(RecipeIngredient recipe)
        {
            if (ModelState.IsValid)
            {
                RecipeIngredient recipeIngredient = new RecipeIngredient
                {
                    RecipeID = recipe.Recipe.RecipeId,
                    IngredientID = recipe.IngredientID,
                    Measurement = recipe.Measurement,
                    Unit = recipe.Unit
                };
                _context.Add(recipeIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateRecipe", "Recipes", new { id = recipeIngredient.RecipeID });
            }
            return RedirectToAction("CreateRecipe", "Recipes", new { id = recipe.Recipe.RecipeId });
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddIngredient([Bind("RecipeIngredientID,RecipeID,IngredientID,Measurement,Unit")] RecipeIngredient recipeIngredient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(recipeIngredient);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", recipeIngredient.IngredientID);
        //    ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeId", "RecipeName", recipeIngredient.RecipeID);
        //    return View(recipeIngredient);
        //}


        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeId == id);
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
            if (id != recipe.RecipeId)
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
                    if (!RecipeExists(recipe.RecipeId))
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
                .SingleOrDefaultAsync(m => m.RecipeId == id);
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
            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.RecipeId == id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
