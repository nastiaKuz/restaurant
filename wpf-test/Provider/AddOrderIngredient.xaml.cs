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
using wpf_test;
using wpf_test.chef;
using wpf_test.Entity;

namespace Restaurant.Provider
{
    /// <summary>
    /// Логика взаимодействия для AddOrderIngredient.xaml
    /// </summary>
    public partial class AddOrderIngredient : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int pr_id, ing_id, unit_id; 

        public AddOrderIngredient()
        {
            InitializeComponent();
            List<units_of_measurement> units = _db.units_of_measurement.ToList();
            unitComboBox.ItemsSource = units;

            List<providers> lProviders = _db.providers.ToList();
            providerComboBox.ItemsSource = lProviders;

            List<ingredients> lIngredients = _db.ingredients.ToList();
            ingredientComboBox.ItemsSource = lIngredients;
        }

        private void UnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unit_id = Convert.ToInt32(unitComboBox.SelectedValue);
        }

        private void IngredientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ing_id = Convert.ToInt32(ingredientComboBox.SelectedValue);
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now.ToLocalTime();
            order_ingredients oItem = new order_ingredients()
            {
                order_time = date,
                execute_time = date.AddDays(2),
                provider_id = pr_id,
                status_id = 4
            };
            _db.order_ingredients.Add(oItem);
            _db.SaveChanges();
            
            content_order_ingredients item = new content_order_ingredients()
            {
                count = Convert.ToInt32(countTextBox.Text),
                ingredient_id = ing_id,
                unit_of_measurement_id = unit_id,
                price = Convert.ToInt32(priceTextBox.Text),
                order_ingredients_id = (from m in _db.order_ingredients select m.id).ToList().Last()
            };
            _db.content_order_ingredients.Add(item);
            _db.SaveChanges();
            this.Hide();
        }

        private void ProviderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pr_id = Convert.ToInt32(providerComboBox.SelectedValue);
        }
        private void Change_User(object sender, RoutedEventArgs e)
        {
            LoginScreen window = new LoginScreen();
            window.ShowDialog();
            this.Close();
        }
        private void Help_Item(object sender, RoutedEventArgs e)
        {
            string Help = "1. Для додавання нового замовлення інгредієнтів, виберіть постачальника, інгредієнт, одиницю вимірювання, введіть ціну та кількість даного інгредієнту " +
                "та натисніть кнопку \"Додати\".\n";
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
