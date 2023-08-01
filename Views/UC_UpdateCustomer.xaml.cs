using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for UC_UpdateCustomer.xaml
    /// </summary>
    public partial class UC_UpdateCustomer : UserControl
    {
        TruckCustomer n = null;
        TruckPerson p = null;
        public UC_UpdateCustomer()
        {
            InitializeComponent();
            CustomerData.Visibility = Visibility.Hidden;
            readOnly(true);
            SaveButton.Visibility = Visibility.Hidden;

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
                         n = DAO.searchCustomer(id);
                         p = DAO.searchPerson(id);
                        if (n != null)
                        {
                            NameTextBox.Text = p.Name;
                            AddressTextBox.Text = p.Address;
                            TelephoneTextBox.Text = p.Telephone;
                            LicenseNoTextBox.Text = n.LicenseNumber;
                            AgeTextBox.Text = n.Age.ToString();
                            LicenseExpiryDatePicker.Text = n.LicenseExpiryDate.ToString();
                            CustomerData.Visibility = Visibility.Visible;
                        }
                        else { MessageBox.Show("There is no such customer ID"); }
                    }
                }
            }
        }

        private void readOnly(bool yes)
        {
            if (yes)
            {
                NameTextBox.IsReadOnly = true;
                AddressTextBox.IsReadOnly = true;
                TelephoneTextBox.IsReadOnly = true;
                LicenseNoTextBox.IsReadOnly = true;
                AgeTextBox.IsReadOnly = true;
                LicenseExpiryDatePicker.IsEnabled = false;

            }
            else
            {
                NameTextBox.IsReadOnly = false;
                AddressTextBox.IsReadOnly = false;
                TelephoneTextBox.IsReadOnly = false;
                LicenseNoTextBox.IsReadOnly = false;
                AgeTextBox.IsReadOnly = false;
                LicenseExpiryDatePicker.IsEnabled = true;

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            //VALIDATIONS----------

            if (NameTextBox.Text.IsNullOrEmpty() ||
                        AddressTextBox.Text.IsNullOrEmpty() ||
                        TelephoneTextBox.Text.IsNullOrEmpty() ||
                        LicenseNoTextBox.Text.IsNullOrEmpty() ||
                        AgeTextBox.Text.IsNullOrEmpty())
            { MessageBox.Show("Some of fields are empty"); }
            else if (TelephoneTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Phone number can contain only digits"); }
            else if (TelephoneTextBox.Text.Length < 8)
            { MessageBox.Show("Phone number should be longer then 7 digits"); }
            else if (AgeTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Age field  can contain only digits"); }
            else if (int.Parse(AgeTextBox.Text) < 18 || int.Parse(AgeTextBox.Text) > 100)
            { MessageBox.Show("Age should be between 18 and 100"); }
            else if (LicenseExpiryDatePicker.SelectedDate.Value.CompareTo(DateTime.Now.AddMonths(1)) < 0)
            { MessageBox.Show("The license can not expire less than 1 month from today"); }
            //---------------------
            else
            {
                p.Name = NameTextBox.Text;
                p.Address = AddressTextBox.Text;
                p.Telephone = TelephoneTextBox.Text;
                n.LicenseNumber = LicenseNoTextBox.Text;
                n.Age = int.Parse(AgeTextBox.Text);
                n.LicenseExpiryDate = LicenseExpiryDatePicker.SelectedDate.Value; 

                DAO.saveChangesCustomer(n, p);
                MessageBox.Show("The data updated successfully");
                readOnly(true);
                SaveButton.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            readOnly(false);
            SaveButton.Visibility = Visibility.Visible;
        }
    }
}
