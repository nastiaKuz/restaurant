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

namespace wpf_test.chef
{
    /// <summary>
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : Window
    {
        Project_Restaurant1Entities _db = new Project_Restaurant1Entities();
        private class RecipeContent
        {
            public int id { get; set; }
            public string dish_name { get; set; }
            public string ingredient { get; set; }
            public int count { get; set; }
            public string unit { get; set; }
        }
        List<RecipeContent> GetItems(string name)
        {
            var result = (from menu_item in _db.menu.Where(m => m.dish_name == name)
                join recipe_item in _db.recipes on menu_item.id equals recipe_item.menu_id
                join ingredient_item in _db.ingredients on recipe_item.ingredient_id equals ingredient_item.id
                join unit_item in _db.units_of_measurement on recipe_item.unit_of_measurement_id equals unit_item.id
                select new RecipeContent
                {
                    id = recipe_item.id,
                    dish_name = menu_item.dish_name,
                    ingredient = ingredient_item.name,
                    count = recipe_item.count,
                    unit = unit_item.name
                }).ToList();
            return result;
        }

        private int ingredientId, unitId;
        private List<RecipeContent> content;

        public EditRecipe(string name)
        {
            InitializeComponent();
            fillComboBoxes();
            content = GetItems(name).ToList();
            IngredientsGrid.ItemsSource = content;
            nameTextBox.Text = content[0].dish_name;
        }
        void fillComboBoxes()
        {
            //filling ingredients
            List<ingredients> ingrs = _db.ingredients.ToList();
            ingredientComboBox.ItemsSource = ingrs;

            //filling units of measurement
            List<units_of_measurement> units = _db.units_of_measurement.ToList();
            unitComboBox.ItemsSource = units;
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addIngrBtn_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void IngredientComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ingredientId = Convert.ToInt32(ingredientComboBox.SelectedValue);
        }

        private void updateIngrBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteIngrBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UnitComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int unitId = Convert.ToInt32(unitComboBox.SelectedValue);
        }
    }
}
