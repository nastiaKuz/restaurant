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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        private int userId = 0;
        private users curUser;
        public EditUser(int id = 0)
        {
            InitializeComponent();
            userId = id;
            if (userId != 0) curUser = getUser();
        }
        private users getUser()
        {
            users user = _db.getUserInfo(userId).Single();
            nameTextBox.Text = user.login;
            passwordTextBox.Password = user.password;
            return user;
        }
        private void insertUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userId == 0)
            {
                users newItem = new users()
                {
                    login = nameTextBox.Text,
                    password = passwordTextBox.Password
                };
                _db.users.Add(newItem);
                _db.SaveChanges();
                this.Hide();
            }
            else
            {
                users thisUser = _db.getUserInfo(userId).Single();
                thisUser.password = passwordTextBox.Password;
                thisUser.login = nameTextBox.Text;
                _db.SaveChanges();
                this.Hide();
            }
        }
    }
}
