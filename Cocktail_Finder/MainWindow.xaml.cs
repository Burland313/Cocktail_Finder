using Cocktail_Finder.Database;
using Cocktail_Finder.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cocktail_Finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString = @"Server=DESKTOP-I8J758C\SQLEXPRESS;Database=CocktailProject;Trusted_Connection=True;";
        public IngredientList ingredientList = new IngredientList();
        public List<ComboBox> ingredientDropdowns = new List<ComboBox>();     

        public MainWindow()
        {
            InitializeComponent();
            Startup();
        }

        public void Startup()
        {
            
            ingredientList.Ingredients = StartupQueries.GetIngredientList(connectionString);

            ingredientDropdowns.Add(Ingredient1);
            ingredientDropdowns.Add(Ingredient2);
            ingredientDropdowns.Add(Ingredient3);
            ingredientDropdowns.Add(Ingredient4);
            ingredientDropdowns.Add(Ingredient5);
            ingredientDropdowns.Add(Ingredient6);
            ingredientDropdowns.Add(Ingredient7);
            InitializeIngredientsList();
        }

        private void InitializeIngredientsList()
        {
            foreach (var ingredientDropdown in ingredientDropdowns)
            {
                List<string> inList = new List<string>();

                foreach(var ingredient in ingredientList.Ingredients)
                {
                    inList.Add(ingredient.ingredientName);
                }

                ingredientDropdown.ItemsSource = inList;
            }
        }

        private void ResetSelectedIngredients()
        {
            foreach (var ingredient in ingredientDropdowns)
            {
                if (ingredient != Ingredient1)
                {
                    ResetIngredientSelection(ingredient);
                }
                else
                {
                    ingredient.SelectedValue = null;
                }
            }
        }

        private void ResetIngredientSelection(ComboBox ingredient)
        {
            ingredient.SelectedValue = null;
            ingredient.IsEnabled = false;
        }

        private void FindCocktail_Click(object sender, RoutedEventArgs e)
        {
            List<string> ingredientList = new List<string>();

            foreach (var i in ingredientDropdowns)
            {
                if(i.SelectedItem != null)
                {
                    ingredientList.Add(i.SelectedItem.ToString());
                }
            }

            CocktailResults.ItemsSource = Queries.FindCocktail(connectionString, ingredientList).DefaultView;

            ResetSelectedIngredients();
        }

        private void AddCocktail_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCocktailDialog();
            dialog.ShowDialog();
            InitializeIngredientsList();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddIngredient();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("You said: " + dialog.ResponseText);
            }
        }

        private void Ingredient1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient2.IsEnabled = true;
        }

        private void Ingredient2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient3.IsEnabled = true;
        }

        private void Ingredient3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient4.IsEnabled = true;
        }

        private void Ingredient4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient5.IsEnabled = true;
        }

        private void Ingredient5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient6.IsEnabled = true;
        }

        private void Ingredient6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient7.IsEnabled = true;
        }
    }
}
