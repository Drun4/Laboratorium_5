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
            lstbx_people.Items.Add(new Person("Kate", "Smit", 10));
            lstbx_people.Items.Add(new Person("John", "Boyka", 10));


            DataContext = new ComboboxViewModel();
        }



        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            int a = 0, b = 1;
            if(a < b){
                orderDate.DisplayDate = DateTime.Today.AddDays(-13);
            }
            if (txt_name.Text == "" || txt_surname.Text == "" || txt_kitAmount.Text == "")
            {
                MessageBox.Show("Missing data!");
            }
            else
            {
                Order order = new Order(Math.Round(Convert.ToDouble(priceSlider.Value), 1), Convert.ToInt32(txt_kitAmount.Text));
                Person person = new Person(txt_name.Text, txt_surname.Text, order.getFinalPrice);
                lstbx_people.Items.Add(person);
            }
        }

        private void orderDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if(orderDate.DisplayDate < DateTime.Today)
            {
                MessageBox.Show("Mistakes in the entered information!");
            }
        }
    }
}
