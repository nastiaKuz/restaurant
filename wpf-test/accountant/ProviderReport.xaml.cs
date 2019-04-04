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
    /// Interaction logic for ProviderReport.xaml
    /// </summary>
    public partial class ProviderReport : Window
    {
        public ProviderReport(string provider, string ingr, int amount, string unit, int price)
        {
            InitializeComponent();
            providerTextBox.Text = provider;
            ingredientTextBox.Text = ingr;
            amountTextBox.Text = amount.ToString();
            unitsTextBlock.Text = unit;
            priceTextBox.Text = price.ToString();
        }
        private void closeReportBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
