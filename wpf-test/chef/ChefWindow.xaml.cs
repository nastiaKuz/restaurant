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
using System.Data.Entity.Core;

namespace wpf_test.chef
{
    /// <summary>
    /// Interaction logic for ChefWindow.xaml
    /// </summary>
    public partial class ChefWindow : Window
    {
        private class orderCheck
        {
            public int id { get; set; }
            public string dish_name { get; set; }
            public int dish_count { get; set; }
            public DateTime time { get; set; }
            public string status { get; set; }
        }
        List<orderCheck> GetChecks(DateTime date)
        {
            var result = (from check_item in _db.checks
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join order_item in _db.orders on check_item.order_id equals order_item.id
                join status_item in _db.statuses on order_item.status_id equals status_item.id
                where order_item.time.ToString() == date.ToString().Substring(0,10)
                select new orderCheck
                {
                    id = check_item.id,
                    dish_name = menu_item.dish_name,
                    dish_count = check_item.count,
                    time = order_item.time,
                    status = status_item.name
                }).ToList();
            return result;
        }
        private class MenuTable
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        List<MenuTable> GetItems()
        {
            var Items = (from recipe_item in _db.recipes
                join menu_item in _db.menu
                    on recipe_item.menu_id equals menu_item.id
                select new MenuTable
                {
                    name = menu_item.dish_name
                }).Distinct();
            return Items.ToList();
        }

        Project_Restaurant1Entities _db = new Project_Restaurant1Entities();
        public static DataGrid rDatagrid, cDataGrid;
        private List<orderCheck> checks;

        public ChefWindow()
        {
            InitializeComponent();
            RecipesGrid.ItemsSource = GetItems().ToList();
            rDatagrid = RecipesGrid;
            // LoadRecipes();
            LoadCurrentChecks();
        }

        private void LoadCurrentChecks()
        {
            
        }
        private void AddRecipeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipePage = new AddRecipe();
            addRecipePage.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = (rDatagrid.SelectedItem as MenuTable).name;
            EditRecipe updRecipe = new EditRecipe(name);
            updRecipe.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(datePicker.SelectedDate);
            List<orderCheck> curChecks = GetChecks(date);
            AllChecksGrid.ItemsSource = curChecks.ToList();
        }

        private void updateStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
