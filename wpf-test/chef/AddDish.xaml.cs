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
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int dishType_id, unit_id;
        public AddDish()
        {
            InitializeComponent();
            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            //filling types
            List<type_dish> types = _db.type_dish.ToList();
            typeDishComboBox.ItemsSource = types;

            //filling units of measurement
            List<units_of_measurement> units = _db.units_of_measurement.ToList();
            unitComboBox.ItemsSource = units;
        }
        private void UnitComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unit_id = Convert.ToInt32(unitComboBox.SelectedValue);
        }

        private void typeDishComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dishType_id = Convert.ToInt32(typeDishComboBox.SelectedValue);
        }

        private void addDishBtn_Click(object sender, RoutedEventArgs e)
        {
            menu newItem = new menu()
            {
                unit_of_measurement_id = unit_id,
                type_dish_id = dishType_id,
                dish_name = dishNameTextBox.Text,
                size = Convert.ToInt32(sizeDishTextBox.Text)
            };
            _db.menu.Add(newItem);
            _db.SaveChanges();
            this.Hide();
            EditRecipe editWindow = new EditRecipe(dishNameTextBox.Text);
            editWindow.ShowDialog();
        }
    }
}
