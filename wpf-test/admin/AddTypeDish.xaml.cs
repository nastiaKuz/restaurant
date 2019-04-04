﻿using System;
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

namespace Restaurant.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddTypeDish.xaml
    /// </summary>
    public partial class AddTypeDish : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        public AddTypeDish()
        {
            InitializeComponent();
        }

        private void AddTypeDishBtn_Click(object sender, RoutedEventArgs e)
        {
            type_dish newItem = new type_dish()
            {
                type = typeDishTextBox.Text
            };
            _db.type_dish.Add(newItem);
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
            string Help = "1. Для додавання нового типу страви, введіть тип страви у поле та натисніть кнопку \"Додати\".\n";
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