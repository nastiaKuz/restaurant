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
    /// Interaction logic for ShowRecipe.xaml
    /// </summary>
    public partial class ShowRecipe : Window
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
        public ShowRecipe(string name)
        {
            InitializeComponent();
            dishName = name;
            content = GetItems(name).ToList();
            var item = _db.menu.First(m => m.dish_name == name);
            menuId = item.id;
            IngredientsGrid.ItemsSource = content;
            nameTextBlock.Text = name;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            EditRecipe updRecipe = new EditRecipe(dishName);
            updRecipe.Show();
            this.Close();
        }
    }
}
