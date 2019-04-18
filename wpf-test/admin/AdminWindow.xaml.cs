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
using Restaurant;
using Restaurant.Admin;

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
            typesDishesGrid.ItemsSource = _db.type_dish.ToList();
            statusesGrid.ItemsSource = _db.statuses.ToList();
            waitersGrid.ItemsSource = _db.waiters.ToList();
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
            } else
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
            MenuGrid.ItemsSource = GetItems(1).ToList();
        }
        private void deleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення рецепту?");
            if (confWindow.ShowDialog() == true)
            {
                int menu_id = (MenuGrid.SelectedItem as MenuTable).menu_id;
                var deleteDish = _db.menu.First(c => c.id == menu_id);
                _db.menu.Remove(deleteDish);
                _db.SaveChanges();
                MenuGrid.ItemsSource = GetItems(typeId).ToList();
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
            string Help = "1. Для перегляду списку типів страв, перейдіть у вкладку \"Тип страви\".\n" +
                          "1. Для перегляду списку типів страв, перейдіть у вкладку \"Тип страви\".\n" +
                          "2. Для додавання нового типу страви, перейдіть у вкладку \"Тип страви\" та натисніть кнопку \"Додати тип страви\".\n" +
                          "3. Для перегляду списку статусів, перейдіть у вкладку \"Статус\".\n" +
                          "4. Для додавання нового статусу, перейдіть у вкладку \"Статус\" та натисніть кнопку \"Додати статус\".\n" +
                          "5. Для перегляду списку офіціантів, перейдіть у вкладку \"Офіціанти\".\n" +
                          "6. Для додавання нового офіціанта, перейдіть у вкладку \"Офіціанти\" та натисніть кнопку \"Додати офіціанта\".\n" +
                          "7. Для видалення елементів із таблиці, натисніть кнопку \"Видалити\", яка розташована у рядку відповідного елемента.\n" +
                          "8. Для редагування елементу, двічі натисніть на поле та після введення нового елементу, натисніть клавішу ENTER та " +
                          "кнопку \"Зберегти\", яка розташована у рядку відповідного елемента.\n";
            HelpProgram helpWindow = new HelpProgram(Help);
            helpWindow.ShowDialog();
        }
        private void About_Item(object sender, RoutedEventArgs e)
        {
            AboutProgram window = new AboutProgram();
            window.ShowDialog();
        }
        //type_dish add
        private void AddTypeDish_Click(object sender, RoutedEventArgs e)
        {
            AddTypeDish dishWindow = new AddTypeDish();
            dishWindow.ShowDialog();
            typesDishesGrid.ItemsSource = _db.type_dish.ToList();
        }
        //type_dish delete
        private void deleteTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення типу страви?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (typesDishesGrid.SelectedItem as type_dish).id;
                var deleteTypeDish = _db.type_dish.Where(m => m.id == id).Single();
                _db.type_dish.Remove(deleteTypeDish);
                _db.SaveChanges();
                typesDishesGrid.ItemsSource = _db.type_dish.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //type_dish update
        private void updateTypeDishBtn_Click(object sender, RoutedEventArgs e)
        {
            type_dish type_dish = (typesDishesGrid.SelectedItem as type_dish);
            type_dish thisTypeDish = _db.getTypeDishInfo(type_dish.id).Single();
            thisTypeDish.type = type_dish.type;
            _db.SaveChanges();
            typesDishesGrid.ItemsSource = _db.type_dish.ToList();
            MessageBox.Show("Зміни успішно збережено");
        }

        //status add
        private void AddStatus_Click(object sender, RoutedEventArgs e)
        {
            AddStatus statusWindow = new AddStatus();
            statusWindow.ShowDialog();
            statusesGrid.ItemsSource = _db.statuses.ToList();
        }
        //status delete
        private void deleteStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення статусу?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (statusesGrid.SelectedItem as statuses).id;
                var deleteStatus = _db.statuses.Where(m => m.id == id).Single();
                _db.statuses.Remove(deleteStatus);
                _db.SaveChanges();
                statusesGrid.ItemsSource = _db.statuses.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //status update
        private void updateStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            statuses status = (statusesGrid.SelectedItem as statuses);
            statuses thisStatus = _db.getStatusInfo(status.id).Single();
            thisStatus.name = status.name;
            _db.SaveChanges();
            statusesGrid.ItemsSource = _db.statuses.ToList();
            MessageBox.Show("Зміни успішно збережено");
        }

        //Waiter add
        private void AddWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWaiter waiterWindow = new AddWaiter();
            waiterWindow.ShowDialog();
            waitersGrid.ItemsSource = _db.waiters.ToList();
        }
        //Waiter delete
        private void deleteWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення офіціанта?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (waitersGrid.SelectedItem as waiters).id;
                var deleteWaiter = _db.waiters.Where(m => m.id == id).Single();
                _db.waiters.Remove(deleteWaiter);
                _db.SaveChanges();
                waitersGrid.ItemsSource = _db.waiters.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //Waiter update
        private void updateWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            waiters waiter = (waitersGrid.SelectedItem as waiters);
            waiters thisWaiter = _db.getWaiterInfo(waiter.id).Single();
            thisWaiter.name = waiter.name;
            _db.SaveChanges();
            waitersGrid.ItemsSource = _db.waiters.ToList();
            MessageBox.Show("Зміни успішно збережено");
        }
    }

}
