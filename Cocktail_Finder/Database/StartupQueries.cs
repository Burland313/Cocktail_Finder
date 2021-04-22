using Cocktail_Finder.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Cocktail_Finder.Database
{
    public class StartupQueries
    {
        public static List<Ingredient> GetIngredientList(string connection)
        {
            List<Ingredient> ingredientList = new List<Ingredient>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = @"SELECT Ingredient1 FROM Cocktail_Ingredients WHERE Ingredient1 IS NOT NULL 
                                UNION SELECT Ingredient2 FROM Cocktail_Ingredients WHERE Ingredient2 IS NOT NULL 
                                UNION SELECT Ingredient3 FROM Cocktail_Ingredients WHERE Ingredient3 IS NOT NULL 
                                UNION SELECT Ingredient4 FROM Cocktail_Ingredients WHERE Ingredient4 IS NOT NULL 
                                UNION SELECT Ingredient5 FROM Cocktail_Ingredients WHERE Ingredient5 IS NOT NULL 
                                UNION SELECT Ingredient6 FROM Cocktail_Ingredients WHERE Ingredient6 IS NOT NULL 
                                UNION SELECT Ingredient7 FROM Cocktail_Ingredients WHERE Ingredient7 IS NOT NULL ORDER BY Ingredient1";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Ingredient ingredient = new Ingredient();
                        ingredient.ingredientName = reader[0].ToString();
                        ingredientList.Add(ingredient);
                    }
                    
                    conn.Close();
                }
            }
            return ingredientList;
        }
    }
}