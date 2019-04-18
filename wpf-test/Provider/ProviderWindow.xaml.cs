using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core;
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
using wpf_test.chef;
using wpf_test;

namespace Restaurant.Provider
{
    /// <summary>
    /// Логика взаимодействия для ProviderWindow.xaml
    /// </summary>
    public partial class ProviderWindow : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public ProviderWindow()
        {
            InitializeComponent();
            DateTime date = DateTime.Now.ToLocalTime();
            var sql = "UPDATE order_ingredients SET status_id = 3 WHERE execute_time < {0}";
            _db.Database.ExecuteSqlCommand(sql, date);
            ProvidersGrid.ItemsSource = _db.providers.ToList();
            StorageGrid.ItemsSource = GetStorageItems();
            ordIngrGrid.ItemsSource = GetOrderIngredients();
        }
        public class StorageItem
        {
            public int id { get; set; }
            public string ingredient_name { get; set; }
            public int count { get; set; }
            public string unit_measurement { get; set; }
        }
        List<StorageItem> GetStorageItems()
        {
            var item = (from storage_item in _db.storage_ingredient
                        join ingredient_item in _db.ingredients on storage_item.ingredient_id equals ingredient_item.id
                        join unit_item in _db.units_of_measurement on storage_item.unit_of_measurement_id equals unit_item.id
                        select new StorageItem
                        {
                            id = storage_item.id,
                            ingredient_name = ingredient_item.name,
                            count = storage_item.count,
                            unit_measurement = "г"
                        }).Distinct();
            return item.ToList();
        }
        private class OrderIngredientTable
        {
            public int id { get; set; }
            public string provid_name { get; set; }
            public string ingr_name { get; set; }
            public int count { get; set; }
            public string units { get; set; }
            public int price { get; set; }
            public string status { get; set; }
            public DateTime d1 { get; set; }
            public DateTime d2 { get; set; }
        }
        List<OrderIngredientTable> GetOrderIngredients()
        {
            var Items = (from cont_item in _db.content_order_ingredients
                         join unit_item in _db.units_of_measurement on cont_item.unit_of_measurement_id equals unit_item.id
                         join ingr_item in _db.ingredients on cont_item.ingredient_id equals ingr_item.id
                         join ord_ing_item in _db.order_ingredients on cont_item.order_ingredients_id equals ord_ing_item.id
                         join status_item in _db.statuses on ord_ing_item.status_id equals status_item.id
                         join provider_item in _db.providers on ord_ing_item.provider_id equals provider_item.id
                         select new OrderIngredientTable
                         {
                             id = ord_ing_item.id,
                             provid_name = provider_item.name,
                             ingr_name = ingr_item.name,
                             count = cont_item.count,
                             units = unit_item.name,
                             price = cont_item.price,
                             status = status_item.name,
                             d1 = ord_ing_item.order_time,
                             d2 = ord_ing_item.execute_time
                         }).Distinct();
            return Items.ToList();
        }
        //orderIngredients add
        private void AddOrderIngr_Click(object sender, RoutedEventArgs e)
        {
            AddOrderIngredient orderIngreWindow = new AddOrderIngredient();
            orderIngreWindow.ShowDialog();
            ordIngrGrid.ItemsSource = GetOrderIngredients();
        }
        //orderIngredients delete
        private void deleteOrderIngredientsBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення замовлення?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (ordIngrGrid.SelectedItem as OrderIngredientTable).id;
                var deleteContent = _db.content_order_ingredients.Where(m => m.order_ingredients_id == id).Single();
                _db.content_order_ingredients.Remove(deleteContent);
                _db.SaveChanges();
                var deleteOrderIngredient = _db.order_ingredients.Where(m => m.id == id).Single();
                _db.order_ingredients.Remove(deleteOrderIngredient);
                _db.SaveChanges();
                ordIngrGrid.ItemsSource = GetOrderIngredients();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //orderIngredients update
        private void updateOrderIngredientsBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderIngredientTable item = (ordIngrGrid.SelectedItem as OrderIngredientTable);
            order_ingredients item1 = _db.order_ingredients.First(c => c.id == item.id);
            item1.provider_id = _db.providers.First(c => c.name == item.provid_name).id;
            item1.status_id = _db.statuses.First(c => c.name == item.status).id;
            item1.order_time = item.d1;
            item1.execute_time = item.d2;
            content_order_ingredients item2 = _db.content_order_ingredients.First(c => c.order_ingredients_id == item.id);
            item2.ingredient_id = _db.ingredients.First(c => c.name == item.ingr_name).id;
            _db.content_order_ingredients.First(c => c.ingredient_id == item2.ingredient_id).count = item.count;
            item2.unit_of_measurement_id = _db.units_of_measurement.First(c => c.name == item.units).id;
            item2.price = item.price;
            _db.SaveChanges();
            ordIngrGrid.ItemsSource = GetOrderIngredients();
            MessageBox.Show("Зміни успішно збережено");
        }

        //storage add
        private void AddStorageItemBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStorageItem storageWindow = new AddStorageItem();
            storageWindow.ShowDialog();
            StorageGrid.ItemsSource = GetStorageItems();
        }
        //storage delete
        private void deleteStorageBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення товару?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (StorageGrid.SelectedItem as StorageItem).id;
                var deleteStorage = _db.storage_ingredient.Where(m => m.id == id).Single();
                _db.storage_ingredient.Remove(deleteStorage);
                _db.SaveChanges();
                StorageGrid.ItemsSource = GetStorageItems();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //storage update
        private void updateStorageBtn_Click(object sender, RoutedEventArgs e)
        {
            StorageItem itemStorage = (StorageGrid.SelectedItem as StorageItem);
            storage_ingredient stItem = _db.storage_ingredient.First(c => c.id == itemStorage.id);
            stItem.ingredient_id = _db.ingredients.First(c => c.name == itemStorage.ingredient_name).id;
            stItem.unit_of_measurement_id = _db.units_of_measurement.First(c => c.name == itemStorage.unit_measurement).id;
            stItem.count = itemStorage.count;
            _db.SaveChanges();
            StorageGrid.ItemsSource = GetStorageItems();
            MessageBox.Show("Зміни успішно збережено");
        }

        //provider add
        private void AddProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProvider providerWindow = new AddProvider();
            providerWindow.ShowDialog();
            ProvidersGrid.ItemsSource = _db.providers.ToList();
        }
        //provider delete
        private void deleteProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmReadiness confWindow = new ConfirmReadiness("Ви підтверджуєте видалення постачальника?");
            if (confWindow.ShowDialog() == true)
            {
                int id = (ProvidersGrid.SelectedItem as providers).id;
                var deleteProvider = _db.providers.Where(m => m.id == id).Single();
                _db.providers.Remove(deleteProvider);
                _db.SaveChanges();
                ProvidersGrid.ItemsSource = _db.providers.ToList();
            }
            else
            {
                confWindow.Hide();
            }
        }
        //provider update
        private void updateProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            providers provider = (ProvidersGrid.SelectedItem as providers);
            providers thisProvider = _db.getProviderInfo(provider.id).Single();
            thisProvider.name = provider.name;
            _db.SaveChanges();
            ProvidersGrid.ItemsSource = _db.providers.ToList();
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
            string Help = "1. Для перегляду списку товарів на складі, перейдіть у вкладку \"Склад\".\n" +
              "2. Для додавання нового товару на склад, перейдіть у вкладку \"Склад\" та натисніть кнопку \"Додати новий товар на склад\".\n" +
              "3. Для перегляду списку постачальників, перейдіть у вкладку \"Постачальники\".\n" +
              "4. Для додавання нового постачальника, перейдіть у вкладку \"Постачальники\" та натисніть кнопку \"Додати постачальника\".\n" +
              "5. Для перегляду списку замовлень, перейдіть у вкладку \"Замовлення інгредієнтів\".\n" +
              "6. Для додавання нового замовлення, перейдіть у вкладку \"Замовлення інгредієнтів\" та натисніть кнопку \"Замовити\".\n" +
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
            {
                this.Close();
            }
            else
            {
                confWindow.Hide();
            }
        }
    }
}
