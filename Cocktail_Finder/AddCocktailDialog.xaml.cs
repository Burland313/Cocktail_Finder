using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cocktail_Finder
{
    /// <summary>
    /// Interaction logic for AddCocktailDialog.xaml
    /// </summary>
    public partial class AddCocktailDialog : Window
    {
        public static string connectionString = @"Server=DESKTOP-I8J758C\SQLEXPRESS;Database=CocktailProject;Trusted_Connection=True;";
        public AddCocktailDialog()
        {
            InitializeComponent();
        }

        private void AddCocktailButton_Click(object sender, RoutedEventArgs e)
        {

            List<string> newCocktailIngredientList = new List<string>();

            if (NewIngredient1.Text != "") { newCocktailIngredientList.Add(NewIngredient1.Text); }
            if (NewIngredient2.Text != "") { newCocktailIngredientList.Add(NewIngredient2.Text); }
            if (NewIngredient3.Text != "") { newCocktailIngredientList.Add(NewIngredient3.Text); }
            if (NewIngredient4.Text != "") { newCocktailIngredientList.Add(NewIngredient4.Text); }
            if (NewIngredient5.Text != "") { newCocktailIngredientList.Add(NewIngredient5.Text); }
            if (NewIngredient6.Text != "") { newCocktailIngredientList.Add(NewIngredient6.Text); }
            if (NewIngredient7.Text != "") { newCocktailIngredientList.Add(NewIngredient7.Text); }

            Database.Queries.AddCocktail(connectionString, newCocktailIngredientList, NewCocktail_Name.Text);

            this.Close();
        }
    }
}
