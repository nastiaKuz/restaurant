using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Restaurant.Provider;
using Restaurant.Waiter;
using wpf_test.accountant;
using wpf_test.admin;
using wpf_test.chef;
using wpf_test.Entity;

namespace wpf_test
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        ProjectRestaurantEntities _db;
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
                var user = _db.users.FirstOrDefault(x =>
                    x.login == txtUsername.Text && x.password == txtPassword.Password);
                if (user != null && user.login == "admin")
                {
                    AdminWindow dashboard = new AdminWindow();
                    dashboard.Show();
                    this.Close();
                }
                else if (user != null && user.login == "chef")
                {
                    ChefWindow forChef = new ChefWindow();
                    forChef.Show();
                    this.Close();
                }
                else if (user != null && user.login == "accountant")
                {
                    AccountantWindow forAccountant = new AccountantWindow();
                    forAccountant.Show();
                    this.Close();
                }
                else if (user != null && user.login == "manager")
                {
                    ProviderWindow forProvider = new ProviderWindow();
                    forProvider.Show();
                    this.Close();
                }
                else if (user != null && user.login == "waiter")
                {
                    WaiterWindow forWaiter = new WaiterWindow();
                    forWaiter.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The user doesn't exist");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
