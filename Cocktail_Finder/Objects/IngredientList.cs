using Cocktail_Finder.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cocktail_Finder.Objects
{
    public class IngredientList
    {
        public List<Ingredient> Ingredients { get; set; }

        public void GetIngredients (string connectionString)
        {
            Ingredients = StartupQueries.GetIngredientList(connectionString);
        }

        public void RefreshIngredients(List<ComboBox> ingredientList)
        {
            foreach (var ingredient in ingredientList)
            {
                ingredient.ItemsSource = Ingredients;
            }
        }

        public void RemoveIngredientByName(string ingredientToRemove)
        {
            foreach (var i in Ingredients)
            {
                if(i.ingredientName == ingredientToRemove)
                {
                    Ingredients.Remove(i);
                    break;
                }
            }
        }
    }
}
