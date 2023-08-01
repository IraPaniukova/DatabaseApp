using Microsoft.IdentityModel.Tokens;
using ProjectPaniukova.DB;
using System;
using System.Collections;
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
    /// Interaction logic for UC_UpdateEmployee.xaml
    /// </summary>
    public partial class UC_UpdateEmployee : UserControl
    {
        TruckEmployee n = null;

        TruckPerson p = null;
        public UC_UpdateEmployee()
        {
            InitializeComponent();
            EmployeeData.Visibility = Visibility.Hidden;
            readOnly(true);
            SaveButton.Visibility = Visibility.Hidden;

        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            readOnly(false);
            SaveButton.Visibility=Visibility.Visible;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeData.Visibility = Visibility.Hidden;
            SaveButton.Visibility= Visibility.Hidden;  
            readOnly(true);

            if (EmployeeIdTextBox.Text.Length == 0)
            { MessageBox.Show("Please enter ID first"); }
            else if (EmployeeIdTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Employeed ID can contain only digits"); }
            else
            {
                int id = int.Parse(EmployeeIdTextBox.Text);
                {
                    n = DAO.searchEmployee(id);
                    p = DAO.searchPerson(id);
                    if (n != null)
                    {
                        EmployeeData.Visibility = Visibility.Visible;
                        NameTextBox.Text = p.Name;
                        AddressTextBox.Text = p.Address;
                        TelephoneTextBox.Text = p.Telephone;
                        OfficeAddressTextBox.Text = n.OfficeAddress;
                        PhoneExtentionNumberTextBox.Text = n.PhoneExtensionNumber;
                        if (Home.adm == "Admin")
                        {
                            UsernameTextBox.Text = n.Username;
                            PasswordTextBox.Text = n.Password;
                        }
                        if (n.Role == "Admin")
                        { RoleComboBox.SelectedIndex = 1; }
                        else { RoleComboBox.SelectedIndex = 0; }

                    }
                    else { MessageBox.Show("There is no such employee ID"); }
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
                OfficeAddressTextBox.IsReadOnly = true;
                PhoneExtentionNumberTextBox.IsReadOnly = true;
                UsernameTextBox.IsReadOnly = true;
                PasswordTextBox.IsReadOnly = true;
                RoleComboBox.IsEnabled = false;

            }
            else
            {
                NameTextBox.IsReadOnly = false;
                AddressTextBox.IsReadOnly = false;
                TelephoneTextBox.IsReadOnly = false;
                OfficeAddressTextBox.IsReadOnly = false;
                PhoneExtentionNumberTextBox.IsReadOnly = false;
                UsernameTextBox.IsReadOnly = false;
                PasswordTextBox.IsReadOnly = false;
                RoleComboBox.IsEnabled = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            

            //VALIDATIONS----------  
            if (n.Username != UsernameTextBox.Text && DAO.searchUsername(UsernameTextBox.Text) != null)
            { MessageBox.Show("Such username already exists"); }            
        
            else if (NameTextBox.Text.IsNullOrEmpty() ||
                        AddressTextBox.Text.IsNullOrEmpty() ||
                        TelephoneTextBox.Text.IsNullOrEmpty() ||
                        OfficeAddressTextBox.Text.IsNullOrEmpty() ||
                        PhoneExtentionNumberTextBox.Text.IsNullOrEmpty() ||
                        UsernameTextBox.Text.IsNullOrEmpty() ||
                        PasswordTextBox.Text.IsNullOrEmpty() ||
                        RoleComboBox.Text.IsNullOrEmpty())
            { MessageBox.Show("Some of fields are empty"); }
            else if (TelephoneTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Phone number can contain only digits"); }
            else if (TelephoneTextBox.Text.Length < 8)
            { MessageBox.Show("Phone number should be longer then 7 digits"); }
           else if (PhoneExtentionNumberTextBox.Text.All(Char.IsDigit) == false)
           { MessageBox.Show("Phone extenshion can contain only digits"); }
            else if (PhoneExtentionNumberTextBox.Text.Length < 2 || PhoneExtentionNumberTextBox.Text.Length > 3)
            { MessageBox.Show("Phone number can have only 2 or 3 digits"); }
            //---------------------
            else
            {
                p.Name = NameTextBox.Text;
                p.Address = AddressTextBox.Text;
                p.Telephone = TelephoneTextBox.Text;
                n.OfficeAddress = OfficeAddressTextBox.Text;
                n.PhoneExtensionNumber = PhoneExtentionNumberTextBox.Text;
                n.Username = UsernameTextBox.Text;
                n.Password = PasswordTextBox.Text;
                n.Role = RoleComboBox.Text;

                DAO.saveChangesEmployees(n, p);
                MessageBox.Show("The data updated successfully");
                readOnly(true);
                SaveButton.Visibility = Visibility.Hidden;
            }

        }

        }
}
