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
            Role user = App.db.Role.FirstOrDefault(x => x.IdRole.ToString() == UsernameTextBox.Text);
            if (user != null)
            {
                if (user.IdRole == 1)
                {
                    App.id_user = 1;
                    App.main.MyFrame.NavigationService.Navigate(new Pages.PetsPage());
                }
                else if (user.IdRole == 2)
                {
                    App.id_user = 2;
                    App.main.MyFrame.NavigationService.Navigate(new Pages.PetsPage());
                }
            }
            else
            {
                MessageBox.Show("такого хозяина нет!..");
            }
        }
    }
}

