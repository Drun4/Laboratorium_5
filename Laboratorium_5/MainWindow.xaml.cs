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
        const double addElementPrice = 2;

        double _helmetPrice;
        double _gogglesPrice;
        double _skiPolesPrice;

        DateTime orderDate;
        DateTime returnDate;

        List<double> sliderValues = new List<double>();
        List<int> kitAmount = new List<int>();

        List<int> firstComboboxIndexes = new List<int>();
        List<int> secondComboboxIndexes = new List<int>();
        List<int> thirdComboboxIndexes = new List<int>();

        List<DateTime> orderDates = new List<DateTime>();
        List<DateTime> returnDates = new List<DateTime>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ComboboxViewModel();
        }

        public int dateCompare(DateTime firstDate, DateTime secondDate)
        {
            if (orderDate > returnDate)
            {
                return 0;
            }
            else
            {
                return (returnDate - orderDate).Days;
            }
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
                if(dateCompare(orderDate, returnDate) == 0)
                {
                    MessageBox.Show("Error in dates!");
                }
                else
                {
                    try
                    {
                        if (cmbx_addHelmet.SelectedIndex == 0)
                        {
                            _helmetPrice = addElementPrice;
                        }
                        else
                        {
                            _helmetPrice = 0;
                        }
                        if (cmbx_addGoggle.SelectedIndex == 0)
                        {
                            _gogglesPrice = addElementPrice;
                        }
                        else
                        {
                            _gogglesPrice = 0;
                        }
                        if (cmbx_addSki.SelectedIndex == 0)
                        {
                            _skiPolesPrice = addElementPrice;
                        }
                        else
                        {
                            _skiPolesPrice = 0;
                        }
                        Order order = new Order(Math.Round(Convert.ToDouble(slider_kitPrice.Value), 1), Convert.ToInt32(txt_kitAmount.Text),
                                                    dateCompare(orderDate, returnDate), _helmetPrice, _gogglesPrice, _skiPolesPrice);
                        Person person = new Person(txt_name.Text, txt_surname.Text, order.getFinalPrice);

                        lstbx_people.Items.Add(person);

                        kitAmount.Add(order.kitAmount);
                        sliderValues.Add(order.kitPrice);

                        firstComboboxIndexes.Add(cmbx_addHelmet.SelectedIndex);
                        secondComboboxIndexes.Add(cmbx_addGoggle.SelectedIndex);
                        thirdComboboxIndexes.Add(cmbx_addSki.SelectedIndex);

                        orderDates.Add(orderDate);
                        returnDates.Add(returnDate);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Format error!");
                    }
                }
            }
        }
        //if(cal_orderDate.DisplayDate<DateTime.Today)
        //    {
        //        MessageBox.Show("Mistakes in the entered information!");
        //    }

        private void lstbx_people_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int personIndex = lstbx_people.SelectedIndex;

            if (lstbx_people.SelectedIndex >= 0)
            {
                Person tempPerson = (Person)lstbx_people.Items[personIndex];
                txt_name.Text = tempPerson.name;
                txt_surname.Text = tempPerson.surname;
                txt_kitAmount.Text = Convert.ToString(kitAmount[personIndex]);
                slider_kitPrice.Value = sliderValues[personIndex];

                cmbx_addHelmet.SelectedIndex = firstComboboxIndexes[personIndex];
                cmbx_addGoggle.SelectedIndex = secondComboboxIndexes[personIndex];
                cmbx_addSki.SelectedIndex = thirdComboboxIndexes[personIndex];

                cal_orderDate.SelectedDate = orderDates[personIndex];
                cal_returnDate.SelectedDate = returnDates[personIndex];
            }
        }

        private void cal_orderDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            orderDate = (DateTime)cal_orderDate.SelectedDate;
        }

        private void cal_returnDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            returnDate = (DateTime)cal_returnDate.SelectedDate;
        }

        private void btn_removeSelected_Click(object sender, RoutedEventArgs e)
        {
            int personIndex = lstbx_people.SelectedIndex;
            if (lstbx_people.SelectedIndex >= 0)
            {
                lstbx_people.Items.RemoveAt(personIndex);

                kitAmount.RemoveAt(personIndex);
                sliderValues.RemoveAt(personIndex);

                firstComboboxIndexes.RemoveAt(personIndex);
                secondComboboxIndexes.RemoveAt(personIndex);
                thirdComboboxIndexes.RemoveAt(personIndex);

                orderDates.RemoveAt(personIndex);
                returnDates.RemoveAt(personIndex);
            }
            else
            {
                MessageBox.Show("Choose a person!");
            }
        }
    }
}
