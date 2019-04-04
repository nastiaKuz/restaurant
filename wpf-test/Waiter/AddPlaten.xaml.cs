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

namespace Restaurant.Waiter
{
    /// <summary>
    /// Логика взаимодействия для AddPlaten.xaml
    /// </summary>
    public partial class AddPlaten : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public AddPlaten()
        {
            InitializeComponent();
        }

        private void AddTableBtn_Click(object sender, RoutedEventArgs e)
        {
            platens newItem = new platens()
            {
                number = Convert.ToInt32(NumberTableTextBox.Text),
                people_amount = Convert.ToInt32(CountPersonsTextBox.Text)
            };
            _db.platens.Add(newItem);
            _db.SaveChanges();
            this.Hide();
        }
        private void Change_User(object sender, RoutedEventArgs e)
        {
            LoginScreen window = new LoginScreen();
            window.ShowDialog();
            this.Close();
        }
        private void Help_Item(object sender, RoutedEventArgs e)
        {
            string Help = "1. Для додавання нового столика, введіть номер столика і кількість персон та натисніть кнопку \"Додати\".\n";
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
