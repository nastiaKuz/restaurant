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

namespace wpf_test.accountant
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report(string waiter, int? table, string dish, int price)
        {
            InitializeComponent();
            waiterTextBox.Text = waiter;
            tableTextBox.Text = table.ToString();
            dishTextBox.Text = dish;
            priceTextBox.Text = price.ToString();
        }

        private void closeReportBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
