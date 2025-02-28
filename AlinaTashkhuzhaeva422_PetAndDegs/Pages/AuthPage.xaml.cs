using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace AlinaTashkhuzhaeva422_PetAndDegs.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
     
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = App.db.User.FirstOrDefault(x => x.Login == LoginTbl.Text && x.Password == PasswordBox.Password);
            if (user != null)
            {
                if (user.FirstName == "Деля")
                {
                    App.id_user = 2;
                    App.main.myframe.NavigationService.Navigate(new Pages.PetList());
                }
                else if (user.FirstName == "Андрей")
                {
                    App.id_user = 1;
                    App.main.myframe.NavigationService.Navigate(new Pages.PetList());
                }
            }
            else
            {
                MessageBox.Show("нет");
            }
        }
    }
}

