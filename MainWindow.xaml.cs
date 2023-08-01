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
using ProjectPaniukova.DB;
using ProjectPaniukova.Views;

namespace ProjectPaniukova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Views.Home form = new Views.Home();            
            if (UsernameTextBox.Text.Length == 0)
            { MessageBox.Show("Please enter username"); }
            else if (PasswordTextBox.Password.ToString().Length == 0)
            { MessageBox.Show("Please enter password"); }
            else
            {
                using (DadIraContext x = new DadIraContext())
                {
                    TruckEmployee login = x.TruckEmployees.Where(y => y.Username == UsernameTextBox.Text && y.Password == PasswordTextBox.Password.ToString() ).FirstOrDefault();
                    if (login != null)
                    {
                        form.Show();
                        this.Hide();
                        
                        form.getRole(login.Role);  //it will take Role to the Home page
                        form.getEmplId(login.EmployeeId);
                        

                    }
                    else { MessageBox.Show("Wrong password or username"); }
                }
            }
        }


       /* public string getRole() => login.Role      I made login a global var for this line*/
        /*
                public  string getRole()
                {
                    using (DadIraContext x = new DadIraContext())
                    {
                            TruckEmployee er = x.TruckEmployees.Where(y => y.Username == UsernameTextBox.Text && y.Password == PasswordTextBox.Password.ToString()).FirstOrDefault();
                        if (er != null)
                        {
                            return er.Role;
                        }
                        else { return "Wrong password or username"; }
                    }
                }
        */
    }
}
