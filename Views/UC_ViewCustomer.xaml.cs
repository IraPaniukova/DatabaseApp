using ProjectPaniukova.DB;
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

namespace ProjectPaniukova.Views
{
    /// <summary>
    /// Interaction logic for UC_ViewCustomer.xaml
    /// </summary>
    public partial class UC_ViewCustomer : UserControl
    {
        public UC_ViewCustomer()
        {
            InitializeComponent();
            CustomerData.Visibility = Visibility.Hidden;
            CustomerData.IsEnabled = false;
          
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            {
                CustomerData.Visibility = Visibility.Hidden;
                if (CustomerIdTextBox.Text.Length == 0)
                { MessageBox.Show("Please enter ID first"); }
                else if (CustomerIdTextBox.Text.All(Char.IsDigit) == false)
                { MessageBox.Show("Customer ID can contain only digits"); }
                else
                {
                    int id = int.Parse(CustomerIdTextBox.Text);
                    {
                        TruckCustomer n = DAO.searchCustomer(id);
                        TruckPerson p = DAO.searchPerson(id);
                        if (n != null)
                        {
                            NameTextBox.Text = p.Name;
                            AddressTextBox.Text = p.Address;
                            TelephoneTextBox.Text = p.Telephone;
                            LicenseNoTextBox.Text = n.LicenseNumber;
                            AgeTextBox.Text=n.Age.ToString();
                            LicenseExpDateTextBox.Text=n.LicenseExpiryDate.ToString();
                            CustomerData.Visibility = Visibility.Visible;
                        }
                        else { MessageBox.Show("There is no such customer ID"); }
                    }
                }
            }
        }

    }
}
