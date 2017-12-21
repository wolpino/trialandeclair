using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TandE.Data;
using TandE.Models;

namespace TandE.Controllers
{
    [Produces("application/json")]
    [Route("api/APIRecipeIngredients")]
    public class APIRecipeIngredientsController : Controller
    {
        private readonly TrialEclairContext _context;

        public APIRecipeIngredientsController(TrialEclairContext context)
        {
            _context = context;
        }

        // GET: api/APIRecipeIngredients
        [HttpGet]
        public string GetRecipeIngredients()
        {
            int last = _context.RecipeIngredients.Last().IngredientID;
            string ingred = _context.Ingredients.SingleOrDefault(i => i.IngredientID == last).IngredientName;
            int measure = _context.RecipeIngredients.Last().Measurement;
            string unit = _context.RecipeIngredients.Last().Unit.ToString();
            int riID = _context.RecipeIngredients.Last().RecipeIngredientID;
            string result = "<p>" + measure + " " + unit + " - " + ingred + " <a asp-controller='RecipeIngredients' asp-action='Edit' asp-route-id=" + riID + ">Edit</a> | <a asp-controller='RecipeIngredients' asp-action='Delete' asp-route-id=" + riID + "> Delete </a></p>";
            return result;
        }

        //// GET: api/APIRecipeIngredients
        //[HttpGet("{id}")]
        //public IEnumerable<RecipeIngredient> GetRecipeIngredients([FromRoute] int id)
        //{
        //    return _context.RecipeIngredients.Where(item => item.RecipeID == id).Include("Ingredients");
        //}

        // GET: api/APIRecipeIngredients
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRecipeIngredientsForRecipe([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _context
        //                .RecipeIngredients
        //                .Where(item => item.RecipeID == id)
        //                .Include("Ingredients")
        //                .ToList();
        //    Console.WriteLine(result);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return OK(result);
        //}

        //GET: api/APIRecipeIngredients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipeIngredient = await _context.RecipeIngredients.SingleOrDefaultAsync(m => m.RecipeIngredientID == id);

            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return Ok(recipeIngredient);
        }

        // PUT: api/APIRecipeIngredients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeIngredient([FromRoute] int id, [FromBody] RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeIngredient.RecipeIngredientID)
            {
                return BadRequest();
            }

            _context.Entry(recipeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIRecipeIngredients
        [HttpPost]
        public async Task<IActionResult> PostRecipeIngredient([FromBody] RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeIngredient", new { id = recipeIngredient.RecipeIngredientID }, recipeIngredient);
        }

        // DELETE: api/APIRecipeIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipeIngredient = await _context.RecipeIngredients.SingleOrDefaultAsync(m => m.RecipeIngredientID == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            _context.RecipeIngredients.Remove(recipeIngredient);
            await _context.SaveChangesAsync();

            return Ok(recipeIngredient);
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.RecipeIngredientID == id);
        }
    }
}