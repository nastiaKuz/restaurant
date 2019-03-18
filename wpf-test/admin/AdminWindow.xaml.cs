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
using wpf_test.Entity;
using wpf_test.chef;

namespace wpf_test.admin
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private class MenuTable
        {
            public int menu_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public int size { get; set; }
            public string units { get; set; }
            public int price { get; set; }
        }
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int typeId = 1;
        private List<type_dish> types;
        public AdminWindow()
        {
            InitializeComponent();
            fillComboBox();
            dishTypeComboBox.SelectedIndex = 0;
            List<MenuTable> menuList = GetItems(1);
            MenuGrid.ItemsSource = menuList;
            fillIngrGrid();
            UsersGrid.ItemsSource = _db.users.ToList();
        }
        void fillComboBox()
        {
            //filling dish_types
            types = _db.type_dish.ToList();
            dishTypeComboBox.ItemsSource = types;
        }
        private void fillIngrGrid()
        {
            IngredientsGrid.ItemsSource = _db.ingredients.ToList();
        }
        List<MenuTable> GetItems(int type_id)
        {
            var Items = (from menu_item in _db.menu
                join type_item in _db.type_dish
                    on menu_item.type_dish_id equals type_item.id
                join unit_item in _db.units_of_measurement
                    on menu_item.unit_of_measurement_id equals unit_item.id
                         where type_item.id == type_id
                         orderby menu_item.dish_name
                select new MenuTable
                {
                    menu_id = menu_item.id,
                    type = type_item.type,
                    name = menu_item.dish_name,
                    size = menu_item.size,
                    units = unit_item.name,
                    price = menu_item.price
                }).Distinct();
            return Items.ToList();
        }
        private void dishTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            typeId = Convert.ToInt32(dishTypeComboBox.SelectedValue);
            MenuGrid.ItemsSource = GetItems(typeId);
            dishTypeComboBox.SelectedIndex = typeId - 1;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuTable curDish = (MenuGrid.SelectedItem as MenuTable);
            Button btn = (Button)sender;
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте зміни?");
            if (confWindow.ShowDialog() == true && btn.IsEnabled)
            {
                menu curMenuItem = _db.getDishInfo(curDish.menu_id).Single();
                curMenuItem.price = curDish.price;
                curMenuItem.dish_name = curDish.name;
                curMenuItem.size = curDish.size;
                _db.SaveChanges();
                MenuGrid.ItemsSource = GetItems(typeId);
                MessageBox.Show("Зміни успішно збережено");
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void AddIngrBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddIngredient addIngrPage = new AddIngredient();
            addIngrPage.ShowDialog();
            IngredientsGrid.ItemsSource = _db.ingredients.ToList();
        }

        private void deleteIngrBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення інгредієнта?");
            if (confWindow.ShowDialog() == true)
            {
                int ingr_id = (IngredientsGrid.SelectedItem as ingredients).id;
                var deleteIngr = _db.ingredients.First(c => c.id == ingr_id);
                _db.ingredients.Remove(deleteIngr);
                _db.SaveChanges();
                IngredientsGrid.ItemsSource = _db.ingredients.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void AddUserBtn_OnClick(object sender, RoutedEventArgs e)
        {
            EditUser insPage = new EditUser();
            insPage.ShowDialog();
            UsersGrid.ItemsSource = _db.users.ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення користувача?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (UsersGrid.SelectedItem as users).id;
                var deleteUser = _db.users.Where(m => m.id == id).Single();
                _db.users.Remove(deleteUser);
                _db.SaveChanges();
                UsersGrid.ItemsSource = _db.users.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void updateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            users user = (UsersGrid.SelectedItem as users);
            users thisUser = _db.getUserInfo(user.id).Single();
            thisUser.password = user.password;
            thisUser.login = user.login;
            _db.SaveChanges();
            UsersGrid.ItemsSource = _db.users.ToList();
            MessageBox.Show("Зміни успішно збережено");
        }

        private void upd()
        {
            UsersGrid.ItemsSource = _db.users.ToList();
        }

        private void AddRecipeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddDish addRecipePage = new AddDish();
            addRecipePage.ShowDialog();
        }
    }
}
