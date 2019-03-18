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

namespace wpf_test.accountant
{
    /// <summary>
    /// Interaction logic for AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        private class orderCheck
        {
            public DateTime time { get; set; }
            public string waiter { get; set; }
            public string dish_name { get; set; }
            public int dish_count { get; set; }
            public int price { get; set; }
            public int check_id { get; set; }
        }
        private class providersOrder
        {
            public int content_id { get; set; }
            public DateTime time { get; set; }
            public string ingredient { get; set; }
            public int ingr_count { get; set; }
            public string units { get; set; }
            public string provider { get; set; }
            public string status { get; set; }
            public int price { get; set; }
        }
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private List<orderCheck> curChecks;
        private int waiterId, providerId, totalDayIncome=0;
        public AccountantWindow()
        {
            InitializeComponent();
            curChecks = GetChecksByDate(DateTime.Now);
            orderChecksGrid.ItemsSource = curChecks;
            updProvidersOrderGrid(DateTime.Now);
            foreach (var check in curChecks)
            {
                totalDayIncome += check.price * check.dish_count;
            }
            fillComboBox();
        }
        private void updProvidersOrderGrid(DateTime date)
        {
            providersOrderGrid.ItemsSource = GetProvidersOrder(date);
        }
        private void updOrderChecksGrid(DateTime date)
        {
            orderChecksGrid.ItemsSource = GetChecksByDate(date);
        }
        List<orderCheck> GetChecksByDate(DateTime date)
        {
            var result = (from check_item in _db.checks
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join order_item in _db.orders on check_item.order_id equals order_item.id
                join waiter_item in _db.waiters on order_item.waiter_id equals waiter_item.id
                //where order_item.time.ToString() == date.ToString().Substring(0, 10)
                select new orderCheck
                {
                    time = order_item.time,
                    waiter = waiter_item.name,
                    dish_name = menu_item.dish_name,
                    dish_count = check_item.count,
                    price = menu_item.price,
                    check_id = check_item.id,
                }).ToList();
            return result;
        }
        List<providersOrder> GetProvidersOrder(DateTime date)
        {
            var result = (from content_item in _db.content_order_ingredients
                join ingr_item in _db.ingredients on content_item.ingredient_id equals ingr_item.id
                join unit_item in _db.units_of_measurement on content_item.unit_of_measurement_id equals unit_item.id
                join order_ingr_item in _db.order_ingredients on content_item.order_ingredients_id equals order_ingr_item.id
                join provider_item in _db.providers on order_ingr_item.provider_id equals provider_item.id
                join status_item in _db.statuses on order_ingr_item.status_id equals status_item.id
                          where order_ingr_item.order_time.ToString().Substring(3, 2) == date.ToString().Substring(3, 2)
                          select new providersOrder()
                {
                    content_id = content_item.id,
                    time = order_ingr_item.order_time,
                    ingredient = ingr_item.name,
                    ingr_count = content_item.count,
                    units = unit_item.name,
                    provider = provider_item.name,
                    status = status_item.name,
                    price = content_item.price,
                }).ToList();
            return result;
        }
        List<providersOrder> GetProvidersOrderByProvider(int provider)
        {
            var result = (from content_item in _db.content_order_ingredients
                join ingr_item in _db.ingredients on content_item.ingredient_id equals ingr_item.id
                join unit_item in _db.units_of_measurement on content_item.unit_of_measurement_id equals unit_item.id
                join order_ingr_item in _db.order_ingredients on content_item.order_ingredients_id equals order_ingr_item.id
                join provider_item in _db.providers on order_ingr_item.provider_id equals provider_item.id
                join status_item in _db.statuses on order_ingr_item.status_id equals status_item.id
                where provider_item.id == provider
                select new providersOrder()
                {
                    content_id = content_item.id,
                    time = order_ingr_item.order_time,
                    ingredient = ingr_item.name,
                    ingr_count = content_item.count,
                    units = unit_item.name,
                    provider = provider_item.name,
                    status = status_item.name,
                    price = content_item.price,
                }).ToList();
            return result;
        }
        List<orderCheck> GetChecksByWaiter(int id)
        {
            var result = (from check_item in _db.checks
                join menu_item in _db.menu on check_item.menu_id equals menu_item.id
                join order_item in _db.orders on check_item.order_id equals order_item.id
                join waiter_item in _db.waiters on order_item.waiter_id equals waiter_item.id
                where waiter_item.id == id
                select new orderCheck
                {
                    time = order_item.time,
                    waiter = waiter_item.name,
                    dish_name = menu_item.dish_name,
                    dish_count = check_item.count,
                    price = menu_item.price,
                    check_id = check_item.id,
                }).ToList();
            return result;
        }
        void fillComboBox()
        {
            //filling waiters
            waiterComboBox.ItemsSource = _db.waiters.ToList().OrderBy((w) => w.name);
            //filling providers
            providerComboBox.ItemsSource = _db.providers.ToList().OrderBy((pr) => pr.name);
        }
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(datePicker.SelectedDate);
            updOrderChecksGrid(date);
            List<orderCheck> curDay = GetChecksByDate(date);
            totalDayIncome = 0;
            incomeTextBox.Text = "";
            foreach (var check in curDay)
            {
                totalDayIncome += check.price;
            }
        }

        private void waiterComboBoxComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            waiterId = Convert.ToInt32(waiterComboBox.SelectedValue);
            orderChecksGrid.ItemsSource = GetChecksByWaiter(waiterId);
        }

        private void showIncome_Click(object sender, RoutedEventArgs e)
        {
            incomeTextBox.Text = totalDayIncome.ToString() + " грн";
        }

        private void deleteProviderOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення замовлення інгредієнтів?");
            if (confWindow.ShowDialog() == true)
            {
                int content_id = (providersOrderGrid.SelectedItem as providersOrder).content_id;
                var deleteContent = _db.content_order_ingredients.First(c => c.id == content_id);
                _db.content_order_ingredients.Remove(deleteContent);
                _db.SaveChanges();
                providersOrderGrid.ItemsSource = GetProvidersOrderByProvider(providerId).ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        private void providerComboBoxComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            providerId = Convert.ToInt32(providerComboBox.SelectedValue);
            providersOrderGrid.ItemsSource = GetProvidersOrderByProvider(providerId);
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення чеку?");
            if (confWindow.ShowDialog() == true)
            {
                int check_id = (orderChecksGrid.SelectedItem as orderCheck).check_id;
                var deleteCheck = _db.checks.First(c => c.id == check_id);
                _db.checks.Remove(deleteCheck);
                _db.SaveChanges();
                orderChecksGrid.ItemsSource = GetChecksByDate(DateTime.Now).ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
    }
}
