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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_test.Entity;

namespace wpf_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = _db.users.ToList();
            datagrid = myDataGrid;
        }
        private void PnlMainGrid_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage insPage = new InsertPage();
            insPage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as users).id;
            var deleteUser = _db.users.Where(m => m.id == id).Single();
            _db.users.Remove(deleteUser);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.users.ToList();
        }
    }
}
