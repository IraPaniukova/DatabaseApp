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
using System.Windows.Shapes;

namespace ProjectPaniukova.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        static public string adm = null;
        static public int emplId = 0;
        public Home()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
            
        }
        public void getRole(String role)   //---Hiding elements for not Admins here----- 
        {                       
             if (role !="Admin")
             { 
                UpdateEmployeeMenuItem.Visibility = Visibility.Hidden;
                AddEmployeeMenuItem.Visibility= Visibility.Hidden;
               
            }
            else { adm= role; }
        }

       public void getEmplId(int id)
             {
            emplId = id;
            
              }
                       
     

        private void AddEmployeeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_AddEmployee());
        }

        private void AddCustomerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_AddCustomer());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            this.Hide();
            form.Show();
            adm = null;
            emplId = 0;
        }

        private void UpdateEmployeeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_UpdateEmployee());
        }

        private void ViewEmployeeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_ViewEmployee());
            
        }

        private void ViewCustomerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_ViewCustomer());
        }

        private void UpdateCustomerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_UpdateCustomer());
        }

        private void UpdateMyInforMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_UpdateMyInfo());
        }

        private void ViewALLEmployeeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_ViewAllEmployees());
        }

        private void ViewPersonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            centralPanel.Children.Clear();
            centralPanel.Children.Add(new UC_ViewPerson());
        }
    }
}
