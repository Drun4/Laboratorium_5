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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorium_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt_name.Text = null;
            txt_surname.Text = null;
            lstbx_people.Items.Add(new Person("Kate", "Smit" ));
            lstbx_people.Items.Add(new Person("John", "Boyka"));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = new Person(txt_name.Text, txt_surname.Text);
                lstbx_people.Items.Add(person);
            }
            catch (FormatException)
            {
                MessageBox.Show("Mistakes in the entered information!");
            }
        }
    }
}
