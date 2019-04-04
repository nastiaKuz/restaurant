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
//using Restaurant.Admin1;
using Restaurant.Provider;
using wpf_test.chef;
using wpf_test.Entity;
using wpf_test;

namespace Restaurant.Waiter
{
    /// <summary>
    /// Логика взаимодействия для WaiterWindow.xaml
    /// </summary>
    public partial class WaiterWindow : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int wait_id, tabl_id, status = 1, id_menu, myOrder_id;
        public WaiterWindow()
        {
            InitializeComponent();

            orderGrid.ItemsSource = GetMenu();
            tablesGrid.ItemsSource = _db.platens.ToList();

            List<waiters> LWaiters = _db.waiters.ToList();
            waiterComboBox.ItemsSource = LWaiters;

            List<int> persons = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            personComboBox.ItemsSource = persons;
        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
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
        private class MenuTable
        {
            public int id { get; set; }
            public string type_dish { get; set; }
            public string name { get; set; }
            public int size { get; set; }
            public string unit_measurement { get; set; }
            public int price { get; set; }
        }
        List<MenuTable> GetMenu()
        {
            var menu = (from menu_item in _db.menu
                        join type_item in _db.type_dish on menu_item.type_dish_id equals type_item.id
                        join unit_item in _db.units_of_measurement on menu_item.unit_of_measurement_id equals unit_item.id
                        select new MenuTable
                        {
                            id = menu_item.id,
                            size = menu_item.size,
                            name = menu_item.dish_name,
                            type_dish = type_item.type,
                            unit_measurement = unit_item.name,
                            price = menu_item.price
                        }).Distinct();
            return menu.OrderBy(x => x.type_dish).ToList();
        }
        private void ChooseDish_Click(object sender, RoutedEventArgs e)
        {
            id_menu = (orderGrid.SelectedItem as MenuTable).id;
            int myCount = 1;
            myOrder_id = (from m in _db.orders select m.id).ToList().Last();
            checks item = new checks()
            {
                order_id = myOrder_id,
                menu_id = id_menu,
                count = myCount
            };
            _db.checks.Add(item);
            _db.SaveChanges();

        }
        //update grid check
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            checksGrid.ItemsSource = GetCheck();
        }
        private void WaiterComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wait_id = Convert.ToInt32(waiterComboBox.SelectedValue);
        }
        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            DateTime myTime = DateTime.Now.ToLocalTime();
            orders item = new orders()
            {
                time = myTime,
                status_id = status,
                table_id = tabl_id,
                waiter_id = wait_id
            };
            _db.orders.Add(item);
            _db.SaveChanges();
        }
        private void PersonsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string table;
            int person = Convert.ToInt32(personComboBox.SelectedItem);
            if (person == 1)
                table = (_db.platens.
                    Where(x => x.people_amount >= 2).
                    Select(x => x.id).FirstOrDefault()).ToString();
            else
                table = (_db.platens.
                    Where(x => x.people_amount == person || x.people_amount == (person + 1)).
                    Select(x => x.id).FirstOrDefault()).ToString();
            tabl_id = Convert.ToInt32(table);
        }
        //tables add
        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            AddPlaten platenWindow = new AddPlaten();
            platenWindow.ShowDialog();
            tablesGrid.ItemsSource = _db.platens.ToList();
        }
        //tables delete
        private void deleteTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення столика?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (tablesGrid.SelectedItem as platens).id;
                var deleteTable = _db.platens.Where(m => m.id == id).Single();
                _db.platens.Remove(deleteTable);
                _db.SaveChanges();
                tablesGrid.ItemsSource = _db.platens.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //tables update
        private void updateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            platens table = (tablesGrid.SelectedItem as platens);
            platens thisTable = _db.getPlatenInfo(table.id).Single();
            thisTable.number = table.number;
            thisTable.people_amount = table.people_amount;
            _db.SaveChanges();
            tablesGrid.ItemsSource = _db.platens.ToList();
            MessageBox.Show("Зміни успішно збережено");
        }
        private class CheckTable
        {
            public int id { get; set; }
            public int id_table { get; set; }
            public string waiter_name { get; set; }
            public string dishname { get; set; }
            public int size { get; set; }
            public string unit_measurement { get; set; }
            public int price { get; set; }
            public int count { get; set; }
            public int ToPay { get; set; }
        }
        List<CheckTable> GetCheck()
        {
            var check = (from check_item in _db.checks
                         join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                         join order_item in _db.orders on check_item.order_id equals order_item.id
                         join waiter_item in _db.waiters on order_item.waiter_id equals waiter_item.id
                         join platen_item in _db.platens on order_item.table_id equals platen_item.id
                         join unit_item in _db.units_of_measurement on menu_item.unit_of_measurement_id equals unit_item.id
                         where check_item.order_id == myOrder_id
                         select new CheckTable
                         {
                             id = check_item.id,
                             id_table = platen_item.number,
                             waiter_name = waiter_item.name,
                             dishname = menu_item.dish_name,
                             size = menu_item.size,
                             unit_measurement = unit_item.name,
                             price = menu_item.price,
                             count = check_item.count,
                             ToPay = menu_item.price * check_item.count
                         }).Distinct();

            return check.ToList();
        }
        //check delete
        private void deleteCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення замовлення у чеку?");
            if (confWindow.ShowDialog() == true)
            {

                int id = (checksGrid.SelectedItem as CheckTable).id;
                var deleteCheck = _db.checks.Where(m => m.id == id).Single();
                _db.checks.Remove(deleteCheck);
                _db.SaveChanges();
                checksGrid.ItemsSource = GetCheck();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //check update
        private void updateCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckTable item = (checksGrid.SelectedItem as CheckTable);
            checks item1 = _db.checks.First(c => c.id == item.id);
            item1.count = item.count;
            menu item4 = _db.menu.First(c => c.id == item1.menu_id);
            item4.price = item.price;
            item4.size = item.size;
            item4.unit_of_measurement_id = _db.units_of_measurement.First(c => c.name == item.unit_measurement).id;
            item4.dish_name = item.dishname;
            orders item2 = _db.orders.First(c => c.id == item1.order_id);
            item2.waiter_id = _db.waiters.First(c => c.name == item.waiter_name).id;
            item2.table_id = _db.platens.First(c => c.number == item.id_table).id;
            _db.SaveChanges();
            checksGrid.ItemsSource = GetCheck();
            MessageBox.Show("Зміни успішно збережено");
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
            string Help = "1. Для створення замовлення, перейдіть у вкладку \"Замовлення\", оберіть офіціанта і кількість персон та натисніть кнопку \"Зробити замовлення\".\n" + 
                          "2. Для перегляду меню, перейдіть у вкладку \"Вибір страви\".\n" +
                          "3. Для вибору страв із меню, перейдіть у вкладку \"Вибір страви\" та натисність кнопку \"Обрати\", яка розташована у рядку відповідного елемента.\n" +
                          "4. Для перегляду поточного замовлення, перейдіть у вкладку \"Чеки\" та натисність кнопку \"Оновити\".\n" +
                          "5. Для перегляду списку столиків, перейдіть у вкладку \"Столики\".\n" +
                          "6. Для додавання нового столика, перейдіть у вкладку \"Столики\" та натисніть кнопку \"Додати столик\".\n" +
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
        private void Close_Program(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви впевнені, що хочете вийти?");
            if (confWindow.ShowDialog() == true)
                this.Close();
            else
                confWindow.Hide();
        }
    }
}
