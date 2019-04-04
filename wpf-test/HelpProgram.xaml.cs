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
    /// Логика взаимодействия для HelpProgram.xaml
    /// </summary>
    public partial class HelpProgram : Window
    {
        public HelpProgram()
        {
            InitializeComponent();
        }
        public HelpProgram(string _str)
        {
            InitializeComponent();
            textbox.Document.Blocks.Clear();
            textbox.Document.Blocks.Add(new Paragraph(new Run(_str)));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
