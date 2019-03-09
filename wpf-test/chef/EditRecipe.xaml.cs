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
using wpf_test.Entity;

namespace wpf_test.chef
{
    /// <summary>
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int menuId;
        private string dishName;
        private class RecipeContent
        {
            public int menu_id { get; set; }
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
                    menu_id = menu_item.id,
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
            dishName = name;
            content = GetItems(name).ToList();
            var item = _db.menu.First(m => m.dish_name == name);
            menuId = item.id;
            IngredientsGrid.ItemsSource = content;
            nameTextBox.Text = name;
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
            this.Hide();
        }

        private void addIngrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ingrAmountTextBox.Text != "")
            {
                recipes newItem = new recipes()
                {
                    menu_id = menuId,
                    unit_of_measurement_id = unitId,
                    ingredient_id = ingredientId,
                    count = Convert.ToInt32(ingrAmountTextBox.Text)
                };
                _db.recipes.Add(newItem);
                _db.SaveChanges();
                IngredientsGrid.ItemsSource = GetItems(dishName).ToList();
                ingredientComboBox.SelectedIndex = -1;
                unitComboBox.SelectedIndex = -1;
                ingrAmountTextBox.Text = "";
            }
        }

        private void IngredientComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ingredientId = Convert.ToInt32(ingredientComboBox.SelectedValue);
        }

        private void deleteIngrBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення рецепту?");
            if (confWindow.ShowDialog() == true)
            {
                int recipe_id = (IngredientsGrid.SelectedItem as RecipeContent).id;
                var deleteIngr = _db.recipes.First(c => c.id == recipe_id);
                _db.recipes.Remove(deleteIngr);
                _db.SaveChanges();
                IngredientsGrid.ItemsSource = GetItems(dishName).ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void UnitComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitId = Convert.ToInt32(unitComboBox.SelectedValue);
        }
    }
}
