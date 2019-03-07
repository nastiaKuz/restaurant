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
    /// Interaction logic for IngredientsList.xaml
    /// </summary>
    public partial class IngredientsList : Window
    {
        private class IngrList
        {
            public int id { get; set; }
            public string ingr { get; set; }
            public int count { get; set; }
            public string unit { get; set; }
        }
        List<IngrList> GetItems(string dish_name, int dish_count)
        {
            var Items = (from recipe in _db.recipes
                join ingr in _db.ingredients on recipe.ingredient_id equals ingr.id
                join dish in _db.menu on recipe.menu_id equals dish.id
                         join unit in _db.units_of_measurement on recipe.unit_of_measurement_id equals unit.id
                         where dish.dish_name == dish_name
                select new IngrList
                {
                    id = ingr.id,
                    ingr = ingr.name,
                    count = recipe.count*dish_count,
                    unit = unit.name
                }).Distinct();
            return Items.ToList();
        }

        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private List<IngrList> newList;
        public IngredientsList(string dish_name, int dish_count)
        {
            InitializeComponent();
            newList = GetItems(dish_name, dish_count);
            IngredientsGrid.ItemsSource = newList;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            foreach (var ingredient in newList)
            {
                storage_ingredient upd = _db.getStorageState(ingredient.id).Single();
                if (upd.count < ingredient.count)
                {
                    MessageBox.Show("Недостатня кількість інгредієнтів.");
                    this.DialogResult = false;
                    return;
                }
                else
                {
                    upd.count = upd.count - ingredient.count;
                    _db.SaveChanges();
                }
            }
            this.DialogResult = true;
        }
    }
}
