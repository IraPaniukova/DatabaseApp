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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPaniukova.Views
{
    /// <summary>
    /// Interaction logic for UC_ViewEmployee.xaml
    /// </summary>
    public partial class UC_ViewEmployee : UserControl
    {
        
        public UC_ViewEmployee()
        {
            InitializeComponent();
            EmployeeData.Visibility = Visibility.Hidden;
            EmployeeData.IsEnabled = false;
            OnlyAdminLabel.Visibility = Visibility.Hidden;

        }



        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeData.Visibility = Visibility.Hidden;
            if (EmployeeIdTextBox.Text.Length == 0)
            { MessageBox.Show("Please enter ID first"); }
            else if (EmployeeIdTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Employeed ID can contain only digits"); }
            else
            {
                int id = int.Parse(EmployeeIdTextBox.Text);
                {
                    TruckEmployee n = DAO.searchEmployee(id);
                    TruckPerson p = DAO.searchPerson(id);
                    if (n != null)
                    {
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
                        
                        RoleTextBox.Text = n.Role;
                        EmployeeData.Visibility = Visibility.Visible;

                        if (Home.adm != "Admin") { OnlyAdminLabel.Visibility = Visibility.Visible; }


                    }
                    else { MessageBox.Show("There is no such employee ID"); }
                }
            }
        }
    }
}
