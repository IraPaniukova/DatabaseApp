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
    /// Interaction logic for UC_AddCustomer.xaml
    /// </summary>
    public partial class UC_AddCustomer : UserControl
    {
        public UC_AddCustomer()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            TruckPerson p = new TruckPerson();
            p.Name = NameTextBox.Text;
            p.Address = AddressTextBox.Text;
            p.Telephone = TelephoneTextBox.Text;
            DAO.addPerson(p);
            using (DadIraContext x = new DadIraContext())
            {
                TruckPerson lastRow = x.TruckPeople.Skip(x.TruckPeople.Count() - 1).FirstOrDefault();
                id = lastRow.PersonId;
            }
            TruckCustomer c = new TruckCustomer();
            c.CustomerId = id;
            c.LicenseNumber = LicenseNoTextBox.Text;
            c.Age = int.Parse(AgeTextBox.Text);
            c.LicenseExpiryDate = LicenseExpiryDatePicker.SelectedDate.Value; 
            DAO.addCustomer(c);


            MessageBox.Show("added successfully");
            NameTextBox.Clear(); AddressTextBox.Clear(); TelephoneTextBox.Clear();
            LicenseNoTextBox.Clear(); AgeTextBox.Clear();
            LicenseExpiryDatePicker.SelectedDate = null;

        }
    }
}
