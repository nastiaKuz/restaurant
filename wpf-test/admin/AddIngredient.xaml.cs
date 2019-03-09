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

namespace wpf_test.admin
{
    /// <summary>
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public AddIngredient()
        {
            InitializeComponent();
        }
        private void addIngrBtn_Click(object sender, RoutedEventArgs e)
        {
            ingredients newItem = new ingredients()
            {
                name = IngrNameTextBox.Text
            };
            _db.ingredients.Add(newItem);
            _db.SaveChanges();
            this.Hide();
        }
    }
}
