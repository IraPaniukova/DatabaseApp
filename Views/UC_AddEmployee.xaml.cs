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
    /// Interaction logic for UC_AddEmployee.xaml
    /// </summary>
    public partial class UC_AddEmployee : UserControl
    {
        public UC_AddEmployee()
        {
            InitializeComponent();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            //VALIDATIONS----------
            if (DAO.searchUsername(UsernameTextBox.Text) != null)
            { MessageBox.Show("Such username already exists"); }            
            else if(NameTextBox.Text.IsNullOrEmpty() ||
                        AddressTextBox.Text.IsNullOrEmpty() ||
                        TelephoneTextBox.Text.IsNullOrEmpty() ||
                        OfficeAddressTextBox.Text.IsNullOrEmpty() ||
                        PhoneExtentionNumberTextBox.Text.IsNullOrEmpty() ||
                        UsernameTextBox.Text.IsNullOrEmpty() ||
                        PasswordTextBox.Text.IsNullOrEmpty() ||
                        RoleComboBox.Text.IsNullOrEmpty())
                { MessageBox.Show("Some of fields are empty");  }
            else if (TelephoneTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Phone number can contain only digits"); }
            else if(TelephoneTextBox.Text.Length< 8 )
            { MessageBox.Show("Phone number should be longer then 7 digits"); }
      //      else if (PhoneExtentionNumberTextBox.Text.All(Char.IsDigit) == false )
       //     { MessageBox.Show("Phone extenshion can contain only digits"); }
       // I made this piece in try and catch P.s.: I still prefer if conditios .
            else if (PhoneExtentionNumberTextBox.Text.Length < 2 || PhoneExtentionNumberTextBox.Text.Length > 3)
            { MessageBox.Show("Phone number can have only 2 or 3 digits"); }
            //---------------------
            else
            {
                try
                {
                   
                    TruckPerson p = new TruckPerson();
                    p.Name = NameTextBox.Text;
                    p.Address = AddressTextBox.Text;
                    p.Telephone = TelephoneTextBox.Text;
                    
                    TruckEmployee em = new TruckEmployee();
                    
                    em.OfficeAddress = OfficeAddressTextBox.Text;
                    em.PhoneExtensionNumber = PhoneExtentionNumberTextBox.Text;
                    em.Username = UsernameTextBox.Text;
                    em.Password = PasswordTextBox.Text;
                    em.Role = RoleComboBox.Text;
                    em.Employee = p;
                    DAO.addEmployee(em);
                    MessageBox.Show("added successfully");

                    NameTextBox.Clear(); AddressTextBox.Clear(); TelephoneTextBox.Clear();
                    OfficeAddressTextBox.Clear(); PhoneExtentionNumberTextBox.Clear();
                    UsernameTextBox.Clear(); PasswordTextBox.Clear();
                    RoleComboBox.Text = null;
                }catch(Exception ex) { MessageBox.Show(ex.Message); }
            }






        }
    }
}
