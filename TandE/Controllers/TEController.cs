using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TandE.Data;
using TandE.Models;

namespace TandE.wwwroot.Controllers
{
    public class TEController : Controller
    {
        private readonly TrialEclairContext _context;

        public TEController(TrialEclairContext context)
        {
            _context = context;
        }

        // GET: TE
        public async Task<IActionResult> Index()
        {
            var trialEclairContext = _context.Recipes.Include(r => r.Idea);
            return View(await trialEclairContext.ToListAsync());
        }

        // GET: TE/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: TE/Create
        public IActionResult Create()
        {
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID");
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientName");
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeName");

            return View("RecipeCreatePage");
        }

        // POST: TE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaID"] = new SelectList(_context.Ideas, "IdeaID", "IdeaID", recipe.IdeaID);
            return View("RecipeCreatePage", recipe);
        }

        // GET: TE/Edit/5
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

        // POST: TE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,RecipeName,RefURL2,RefURL3,RefURL4,VersionNotes,IdeaID,Method,CreatedAt")] Recipe recipe)
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

        // GET: TE/Delete/5
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

        // POST: TE/Delete/5
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
