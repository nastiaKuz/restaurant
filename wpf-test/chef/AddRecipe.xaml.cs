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
    public partial class AddRecipe : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int ingredientId, unitId;
        public AddRecipe()
        {
            InitializeComponent();
            fillComboBoxes();
        }

        void fillComboBoxes()
        {
            //filling ingredients
            List<ingredients> ingrs = _db.ingredients.ToList();
            ingredientComboBox.ItemsSource = ingrs;

            //filling units of measurement
            List<units_of_measurement> units = _db.units_of_measurement.ToList();
            unitComboBox.ItemsSource = units;
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addIngrBtn_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void IngredientComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ingredientId = Convert.ToInt32(ingredientComboBox.SelectedValue);
        }

        private void UnitComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int unitId = Convert.ToInt32(unitComboBox.SelectedValue);
        }
    }
}
