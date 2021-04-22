using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cocktail_Finder.Objects
{
    public class Ingredient
    {
        public string ingredientName { get; set; }

        public void ResetIngredientSelection(ComboBox ingredient)
        {
            ingredient.SelectedValue = null;
            ingredient.IsEnabled = false;
        }
    }
}
