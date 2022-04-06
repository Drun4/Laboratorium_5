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
        List<double> sliderValues = new List<double>();
        List<int> kitValues = new List<int>();

        List<int> firstComboboxIndexes = new List<int>();
        List<int> secondComboboxIndexes = new List<int>();
        List<int> thirdComboboxIndexes = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ComboboxViewModel();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //int a = 0, b = 1;
            //if(a < b){
            //    orderDate.DisplayDate = DateTime.Today.AddDays(-13);
            //}
            if (txt_name.Text == "" || txt_surname.Text == "" || txt_kitAmount.Text == "")
            {
                MessageBox.Show("Missing data!");
            }
            else
            {
                try
                {
                    Order order = new Order(Math.Round(Convert.ToDouble(slider_kitPrice.Value), 1), Convert.ToInt32(txt_kitAmount.Text));
                    Person person = new Person(txt_name.Text, txt_surname.Text, order.getFinalPrice);

                    lstbx_people.Items.Add(person);
                    kitValues.Add(order.kitAmount);
                    sliderValues.Add(order.kitPrice);

                    firstComboboxIndexes.Add(cmbx_addHelmet.SelectedIndex);
                    secondComboboxIndexes.Add(cmbx_addGoggle.SelectedIndex);
                    thirdComboboxIndexes.Add(cmbx_addSki.SelectedIndex);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Format error!");
                }
            }
        }

        private void orderDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if(orderDate.DisplayDate < DateTime.Today)
            {
                MessageBox.Show("Mistakes in the entered information!");
            }
        }

        private void lstbx_people_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int personIndex = lstbx_people.SelectedIndex;

            Person tempPerson = (Person)lstbx_people.Items[personIndex];
            txt_name.Text = tempPerson.name;
            txt_surname.Text = tempPerson.surname;
            txt_kitAmount.Text = Convert.ToString(kitValues[personIndex]);
            slider_kitPrice.Value = sliderValues[personIndex];

            cmbx_addHelmet.SelectedIndex = firstComboboxIndexes[personIndex];
            cmbx_addGoggle.SelectedIndex = secondComboboxIndexes[personIndex];
            cmbx_addSki.SelectedIndex = thirdComboboxIndexes[personIndex];
        }

        //private void cmbx_addHelmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    txt_addHelmet.Text += ;
        //}
    }
}
