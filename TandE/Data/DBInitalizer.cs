using TandE.Models;
using System;
using System.Linq;

namespace TandE.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TrialEclairContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Ideas.
            if (context.Ideas.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{CategoryName="Cookies",CategoryDesc="Crunchy or Chewy, or Cakey, but not bars",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Candy",CategoryDesc="Bonbons and truffles and anything hard",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Frozen Treats",CategoryDesc="Includes frozen yogurt, or sorbet, anything frozen.",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Cake",CategoryDesc="All the cakes",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Bars",CategoryDesc="Brownies, Blondies, Lemon, Granola, etc",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Breads",CategoryDesc="Rolls, Loaves, sticks, quick too.",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Pie",CategoryDesc="Ice cream, frozen yogurt, or sorbet, anything frozen.",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Category{CategoryName="Crackers",CategoryDesc="Crispy, or possibly chewy, but not bread.",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},

            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
            var ideas = new Idea[]
            {
            new Idea{IdeaName="QuadChocolate Cookie", CategoryID=categories.Single(i => i.CategoryName == "Cookies").CategoryID,RefURL1="https://www.averiecooks.com/2014/02/quadruple-chocolate-soft-fudgy-pudding-cookies.html",InitialNotes="Maybe add more chooclate",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Idea{IdeaName="Salted Honey Shortbread",CategoryID=categories.Single(i => i.CategoryName == "Cookies").CategoryID,RefURL1="http://evilshenanigans.com/2010/09/salted-honey-lavender-shortbread/",InitialNotes="How to make the honey flavor dominate?",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Idea{IdeaName="Rosemary Candy",CategoryID=categories.Single(i => i.CategoryName == "Candy").CategoryID,RefURL1="http://www.cooks.com/recipe/xw4ki856/rosemary-candy.html",InitialNotes="Make them like the Lavendar candies from France(Brittany?)",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Idea{IdeaName="Cinnamon Toast Crunch Ice Cream",CategoryID=categories.Single(i => i.CategoryName == "Ice Cream").CategoryID,RefURL1="https://food52.com/blog/11367-how-to-make-cereal-milk-ice-cream",InitialNotes="Will it have chuncks?",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")}
            };
            foreach (Idea s in ideas)
            {
                context.Ideas.Add(s);
            }
            context.SaveChanges();

            var recipes = new Recipe[]
            {
            new Recipe{IdeaID=ideas.Single( i => i.IdeaName == "QuadChocolate Cookie").IdeaID,RecipeName="QuadChocolate Cookie",RefURL2="https://",RefURL3="https://",RefURL4="https://",Method="1.make dough 2. bake cookies 3. eat",VersionNotes="None?", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Recipe{IdeaID=ideas.Single( i => i.IdeaName == "Salted Honey Shortbread").IdeaID,RecipeName="Salted Honey Shortbread",RefURL2="https://",RefURL3="https://",RefURL4="https://",Method="1.make dough 2. bake cookies 3. eat",VersionNotes="None?", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Recipe{IdeaID=ideas.Single( i => i.IdeaName == "Rosemary Candy").IdeaID,RecipeName="QuadChocolate Cookie",RefURL2="https://",RefURL3="https://",RefURL4="https://",Method="1.make dough 2. bake cookies 3. eat",VersionNotes="None?",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Recipe{IdeaID=ideas.Single( i => i.IdeaName == "Cinnamon Toast Crunch Ice Cream").IdeaID,RecipeName="QuadChocolate Cookie",RefURL2="https://",RefURL3="https://",RefURL4="https://",Method="1.make dough 2. bake cookies 3. eat",VersionNotes="None?",CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},


            };
            foreach (Recipe s in recipes)
            {
                context.Recipes.Add(s);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]
            {
            new Ingredient{IngredientName="Chocolate", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Flour", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Sugar", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new Ingredient{IngredientName="Butter", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Honey", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Milk", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Salt", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new Ingredient{IngredientName="Baking Soda", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },

            };
            foreach (Ingredient s in ingredients)
            {
                context.Ingredients.Add(s);
            }
            context.SaveChanges();

            var recipeingred = new RecipeIngredient[]
            {
            new RecipeIngredient{RecipeID=1,IngredientID=1,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=1,IngredientID=2,Measurement=3,Unit=Unit.cup, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=2,IngredientID=3,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=2,IngredientID=4,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=2,IngredientID=5,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=3,IngredientID=2,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=3,IngredientID=3,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=3,IngredientID=4,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=4,IngredientID=2,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=4,IngredientID=4,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=4,IngredientID=5,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new RecipeIngredient{RecipeID=4,IngredientID=6,Measurement=3,Unit=Unit.tablespoon, CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },

            };
            foreach (RecipeIngredient e in recipeingred)
            {
                context.RecipeIngredients.Add(e);
            }
            context.SaveChanges();

            var subcategories = new SubCategory[]
            {
            new SubCategory{SubCategoryName="Shortbread",SubCategoryDesc="Null", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new SubCategory{SubCategoryName="Dairy",SubCategoryDesc="Null", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01")},
            new SubCategory{SubCategoryName="Herb",SubCategoryDesc="Null.", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            new SubCategory{SubCategoryName="Chocolate",SubCategoryDesc="Null", CreatedAt=DateTime.Parse("2011-09-01"),UpdatedAt=DateTime.Parse("2011-09-01") },
            };
            foreach (SubCategory c in subcategories)
            {
                context.Subcategories.Add(c);
            }
            context.SaveChanges();

            var ideasub = new IdeaSubCategory[]
            {
            new IdeaSubCategory{IdeaID=ideas.Single(i => i.IdeaName == "QuadChocolate Cookie").IdeaID,
                SubCategoryID=subcategories.Single(s => s.SubCategoryName =="Chocolate").SubCategoryID},
            new IdeaSubCategory{IdeaID=ideas.Single(i => i.IdeaName == "Salted Honey Shortbread").IdeaID,
                SubCategoryID=subcategories.Single(s => s.SubCategoryName =="Shortbread").SubCategoryID },
            new IdeaSubCategory{IdeaID=ideas.Single(i => i.IdeaName == "Rosemary Candy").IdeaID,
                SubCategoryID=subcategories.Single(s => s.SubCategoryName =="Herb").SubCategoryID },
            new IdeaSubCategory{IdeaID=ideas.Single(i => i.IdeaName == "Cinnamon Toast Crunch Ice Cream").IdeaID,
                SubCategoryID=subcategories.Single(s => s.SubCategoryName =="Dairy").SubCategoryID },

            };
            foreach (IdeaSubCategory s in ideasub)
            {
                context.IdeaSubCategories.Add(s);
            }
            context.SaveChanges();

        }

    }
}