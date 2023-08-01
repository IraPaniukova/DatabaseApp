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
    /// Interaction logic for UC_ViewPerson.xaml
    /// </summary>
    public partial class UC_ViewPerson : UserControl
    {
        public UC_ViewPerson()
        {
            InitializeComponent();
            PersonData.Visibility = Visibility.Hidden;
            PersonData.IsEnabled = false;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            PersonData.Visibility = Visibility.Hidden;
            if (PersonIdTextBox.Text.Length == 0)
            { MessageBox.Show("Please enter ID first"); }
            else if (PersonIdTextBox.Text.All(Char.IsDigit) == false)
            { MessageBox.Show("Person ID can contain only digits"); }
            else
            {
                int id = int.Parse(PersonIdTextBox.Text);
                {
                    
                    TruckPerson p = DAO.searchPerson(id);
                    if (p != null)
                    {
                        NameTextBox.Text = p.Name;
                        AddressTextBox.Text = p.Address;
                        TelephoneTextBox.Text = p.Telephone;
                       
                        PersonData.Visibility = Visibility.Visible;
                    }
                    else { MessageBox.Show("There is no such person ID"); }
                }
            }
        }
    }
}
