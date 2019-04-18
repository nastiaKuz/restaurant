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
using Restaurant;

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

        private class cookingCheck
        {
            public int cook_id { get; set; }
            public int check_id { get; set; }
            public string dish_name { get; set; }
            public int dish_count { get; set; }
            public DateTime? receive_time { get; set; }
            public DateTime? execute_time { get; set; }
            public string status { get; set; }
        }

        private class MenuTable
        {
            public int recipe_id { get; set; }
            public int menu_id { get; set; }
            public string name { get; set; }
        }

        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public static DataGrid rDatagrid, cDataGrid;
        private List<orderCheck> curChecks;

        public ChefWindow()
        {
            InitializeComponent();
            RecipesGrid.ItemsSource = GetItems().ToList();
            LoadCurrentChecks();
            AllChecksGrid.ItemsSource = GetChecks(DateTime.Now);
        }

        List<cookingCheck> GetCookingChecks()
        {
            var result = (from cook_item in _db.cooking
                join check_item in _db.checks on cook_item.check_id equals check_item.id
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join status_item in _db.statuses on cook_item.status_id equals status_item.id
                where cook_item.status_id == 4
                select new cookingCheck
                {
                    cook_id = cook_item.id,
                    check_id = check_item.id,
                    dish_name = menu_item.dish_name,
                    dish_count = check_item.count,
                    receive_time = cook_item.receive_time,
                    execute_time = cook_item.execute_time,
                    status = status_item.name
                }).ToList();
            return result;
        }

        List<cookingCheck> GetChecks(DateTime date)
        {
            var result = (from cook_item in _db.cooking
                join check_item in _db.checks on cook_item.check_id equals check_item.id
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join status_item in _db.statuses on cook_item.status_id equals status_item.id
                join order_item in _db.orders on check_item.order_id equals order_item.id
                where order_item.time.ToString() == date.ToString().Substring(0, 10) && cook_item.status_id == 3
                orderby cook_item.receive_time descending
                select new cookingCheck
                {
                    cook_id = cook_item.id,
                    check_id = check_item.id,
                    dish_name = menu_item.dish_name,
                    dish_count = check_item.count,
                    receive_time = cook_item.receive_time,
                    execute_time = cook_item.execute_time,
                    status = status_item.name
                }).ToList();
            return result;
        }

        List<orderCheck> GetCurrentChecks()
        {
            var result = (from check_item in _db.checks
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join order_item in _db.orders on check_item.order_id equals order_item.id
                join status_item in _db.statuses on order_item.status_id equals status_item.id
                where order_item.status_id == 1
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

        List<MenuTable> GetItems()
        {
            var Items = (from recipe_item in _db.recipes
                join menu_item in _db.menu
                on recipe_item.menu_id equals menu_item.id
                orderby menu_item.dish_name
                select new MenuTable
                {
                    menu_id = menu_item.id,
                    recipe_id = recipe_item.menu_id,
                    name = menu_item.dish_name
                }).Distinct();
            return Items.ToList();
        }

        private void LoadCurrentChecks()
        {
            curChecks = GetCurrentChecks();
            CurrentChecksGrid.ItemsSource = curChecks.ToList();
            InProgressGrid.ItemsSource = GetCookingChecks();
        }

        private void AddRecipeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddDish addRecipePage = new AddDish();
            addRecipePage.ShowDialog();
            RecipesGrid.ItemsSource = GetItems().ToList();
        }
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(datePicker.SelectedDate);
            List<cookingCheck> dateChecks = GetChecks(date);
            AllChecksGrid.ItemsSource = dateChecks.ToList();
        }

        private void cookBtn_Click(object sender, RoutedEventArgs e)
        {
            orderCheck curCheck = (CurrentChecksGrid.SelectedItem as orderCheck);
            string dish_name = curCheck.dish_name;
            int dish_count = curCheck.dish_count;
            int checkId = curCheck.id;
            Button btn = (Button) sender;
            if (btn.Content.ToString() == "Розпочати виконання" && btn.IsEnabled)
            {
                IngredientsList listWindow = new IngredientsList(dish_name, dish_count);
                if (listWindow.ShowDialog() == true)
                {
                    cooking newItem = new cooking()
                    {
                        check_id = checkId,
                        status_id = 4,
                        receive_time = DateTime.Now,
                        execute_time = DateTime.Now
                    };
                    _db.cooking.Add(newItem);
                    _db.SaveChanges();
                    if (CurrentChecksGrid.SelectedItem != null)
                    {
                        var row =
                            CurrentChecksGrid.ItemContainerGenerator.ContainerFromItem(CurrentChecksGrid.CurrentItem) as
                                DataGridRow;
                        row.IsEnabled = false;
                        row.Background = Brushes.LightGray;
                    }

                    CurrentChecksGrid.UnselectAll();
                    btn.IsEnabled = false;
                    InProgressGrid.ItemsSource = GetCookingChecks();
                }
                else
                {
                    listWindow.Hide();
                    CurrentChecksGrid.UnselectAll();
                }
            }
        }
        private void readyBtn_Click(object sender, RoutedEventArgs e)
        {
            cookingCheck cookCheck = (InProgressGrid.SelectedItem as cookingCheck);
            int check_id = cookCheck.check_id;
            Button btn = (Button) sender;
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте готовність замовлення?");
            if (confWindow.ShowDialog() == true && btn.IsEnabled)
            {
                cooking curCooking = _db.getCurrentCooking(check_id).Single();
                curCooking.status_id = 3;
                curCooking.execute_time = DateTime.Now;
                _db.SaveChanges();
                btn.Content = "Виконано";
                CurrentChecksGrid.UnselectAll();
                btn.IsEnabled = false;
                InProgressGrid.ItemsSource = GetCookingChecks();
                AllChecksGrid.ItemsSource = GetChecks(DateTime.Now);
            }
            else
            {
                confWindow.Hide();
            }
        }


        private void updBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentChecksGrid.ItemsSource = GetCurrentChecks();
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = (RecipesGrid.SelectedItem as MenuTable).name;
            ShowRecipe details = new ShowRecipe(name);
            details.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення рецепту?");
            if (confWindow.ShowDialog() == true)
            {
                int menu_id = (RecipesGrid.SelectedItem as MenuTable).menu_id;
                var deleteDish = _db.menu.First(c => c.id == menu_id);
                _db.menu.Remove(deleteDish);
                _db.SaveChanges();
                RecipesGrid.ItemsSource = GetItems().ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        private void Close_Program(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви впевнені, що хочете вийти?");
            if (confWindow.ShowDialog() == true)
            {
                this.Close();
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void Change_User(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви впевнені, що хочете вийти?");
            if (confWindow.ShowDialog() == true)
            {
                LoginScreen login = new LoginScreen();
                login.Show();
                this.Close();
            }
            else
            {
                confWindow.Hide();
            }
        }

        private void Help_Item(object sender, RoutedEventArgs e)
        {
            string Help =
                "1. Для перегляду списку поточних замовлень та замовлень у процесі виконання, перейдіть у вкладку \"Поточні замовленя\".\n" +
                "2. Для перегляду списку виконаних замовлень, перейдіть у вкладку \"Виконані замовленя\".\n" +
                "3. Для перегляду списку рецептів, перейдіть у вкладку \"Рецепти\".\n" +
                "4. Для додавання нового рецепту, перейдіть у вкладку \"Рецепти\" та натисніть кнопку \"Створити рецепт\".\n" +
                "5. Для видалення елементів із таблиці, натисніть кнопку \"Видалити\", яка розташована у відповідному рядку.\n";
            HelpProgram helpWindow = new HelpProgram(Help);
            helpWindow.ShowDialog();
        }
        private void About_Item(object sender, RoutedEventArgs e)
        {
            AboutProgram window = new AboutProgram();
            window.ShowDialog();
        }
    }
}
