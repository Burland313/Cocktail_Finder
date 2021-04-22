using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail_Finder.Database
{
    public class Queries
    {
        public static DataTable FindCocktail(string connection, List<String> ingredientList)
        {
            DataTable CocktailResults = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = Factory.StringGenerator.GetIngredients(ingredientList);

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Cocktails");
                    sda.Fill(dt);
                    CocktailResults = dt;

                    conn.Close();
                }
            }
            return CocktailResults;
        }

        public static void AddCocktail(string connection, List<string> ingredientList, string cocktailName)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = Factory.StringGenerator.AddCocktailQuery(ingredientList, cocktailName);

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }

        }

        //This might be used later if the ingredients are stored in their on DB
        public static void AddIngredient(string connection, string ingredientName)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "INSERT INTO ";
            }
        }
    }
}
