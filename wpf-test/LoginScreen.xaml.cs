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
using wpf_test.chef;

namespace wpf_test
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        Project_Restaurant1Entities _db = new Project_Restaurant1Entities();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // var user =_db.users.Where(x => x.login == txtUsername.Text && x.password == txtPassword.Password);
            var user = _db.users.FirstOrDefault(x => x.login == txtUsername.Text && x.password == txtPassword.Password);
            if (user != null && user.login == "admin")
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            } else if (user != null && user.login == "chef")
            {
                ChefWindow forChef = new ChefWindow();
                forChef.Show();
                this.Close();
            } else if (user != null && user.login == "accountant")
            {

            }
            else
            {
                MessageBox.Show("The user doesn't exist");
            }
        }
    }
}
