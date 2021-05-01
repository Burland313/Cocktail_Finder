using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail_Finder.Factory
{
    public class QueryGenerator
    {
        public static string GetIngredients_qry(List<string> ingredientList)
        {
            string queryString = $@"SELECT Cocktail_Name, Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7 FROM Cocktail_Ingredients";
            bool firstPass = true;
            foreach (string s in ingredientList)
            {
                if(firstPass)
                {
                    queryString += $@" WHERE '{s}' IN (Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7)";
                    firstPass = false;
                }
                else
                {
                    queryString += $@"AND '{s}' IN (Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7)";
                }
            }

            return queryString;
        }

        public static string AddCocktail_qry(List<string> ingredientList, string cocktailName)
        {
            string queryString = $@"INSERT INTO [CocktailProject].[dbo].[Cocktail_Ingredients] (";

            queryString += "Cocktail_Name";
            int index = 0;
            foreach (var i in ingredientList)
            {
                if (index <= ingredientList.Count())
                {
                    queryString += ", ";
                }

                queryString += $"Ingredient{index + 1}";
  
                if (index == ingredientList.Count() - 1)
                {
                    queryString += ") ";
                }

                index++;
            }

            queryString += "VALUES (";

            int index2 = 0;
            queryString = queryString + "'" + cocktailName + "'";
            foreach (var i in ingredientList)
            {
                if (index2 <= ingredientList.Count())
                {
                    queryString += ", ";
                }
    
                queryString = queryString + "'" + i + "'";

                if (index2 == ingredientList.Count() - 1)
                {
                    queryString += ")";
                }

                index2++;
            }

            return queryString;
        }
    }
}
