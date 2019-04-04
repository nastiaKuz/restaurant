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

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для AboutProgram.xaml
    /// </summary>
    public partial class AboutProgram : Window
    {
        public AboutProgram()
        {
            InitializeComponent();
            string myStr = "Програма для керування роботою ресторану\n" +
                           "Версія продукту 1.01\n\n" + 
                           "Ліцензія для:\n" + 
                           "Вонс Юрій\n" + 
                           "Кузнецова Анастасія\n\n\n" +
                           "Copyright © VonsYurii Restaurant 2019\n" +
                           "Всі права захищені.";
            textbox.Document.Blocks.Clear();
            textbox.Document.Blocks.Add(new Paragraph(new Run(myStr)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
