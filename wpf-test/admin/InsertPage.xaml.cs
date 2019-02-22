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

namespace wpf_test
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    { 
        Project_Restaurant1Entities _db = new Project_Restaurant1Entities();
        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            users newItem = new users()
            {
                login = nametextBox1.Text,
                password = rolecomboBox.Text
            };
            //try
            //{
                _db.users.Add(newItem);
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.users.ToList();
                this.Hide();
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
        }
    }
}
