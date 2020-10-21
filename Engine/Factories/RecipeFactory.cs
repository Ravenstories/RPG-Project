using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class RecipeFactory
    {
        private static readonly List<Recipe> _recipes = new List<Recipe>();

        static RecipeFactory()
        {
            Recipe strongPotion = new Recipe(1, "Strong Potion");
            strongPotion.AddIngredient(2001, 1);
            strongPotion.AddIngredient(3001, 1);
            strongPotion.AddIngredient(3002, 1);
            strongPotion.AddOutputItem(2002, 1);

            _recipes.Add(strongPotion);
        }
        public static Recipe RecipeByID(int id)
        {
            return _recipes.FirstOrDefault(x => x.ID == id);
        }
    }
}
