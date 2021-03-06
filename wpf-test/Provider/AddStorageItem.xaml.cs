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

namespace Restaurant.Provider
{
    /// <summary>
    /// Логика взаимодействия для AddStorageItem.xaml
    /// </summary>
    public partial class AddStorageItem : Window
    {
        ProjectRestaurantEntities _db = new ProjectRestaurantEntities();
        int unit_id;
        public AddStorageItem()
        {
            InitializeComponent();
            List<units_of_measurement> units = _db.units_of_measurement.ToList();
            unitComboBox.ItemsSource = units;
        }
        private void UnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unit_id = Convert.ToInt32(unitComboBox.SelectedValue);
        }

        private void AddStorageItemBtn_Click(object sender, RoutedEventArgs e)
        {
            ingredients newItem = new ingredients()
            {
                name = StorageItemNameTextBox.Text
            };
            _db.ingredients.Add(newItem);
            _db.SaveChanges();
            storage_ingredient newItem2 = new storage_ingredient()
            {
                count = 0,
                ingredient_id = (from m in _db.ingredients select m.id).ToList().Last(),
                unit_of_measurement_id = unit_id
            };
            _db.storage_ingredient.Add(newItem2);
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
            string Help = "1. Для додавання нового інгредієнту на склад, введіть назву у поле, виберіть одиницю вимірювання та натисніть кнопку \"Додати\".\n";
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
