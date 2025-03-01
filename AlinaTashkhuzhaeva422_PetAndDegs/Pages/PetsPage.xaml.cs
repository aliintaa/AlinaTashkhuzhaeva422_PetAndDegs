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

namespace AlinaTashkhuzhaeva422_PetAndDegs.Pages
{
    /// <summary>
    /// Логика взаимодействия для PetsPage.xaml
    /// </summary>
    public partial class PetsPage : Page
    {
        public PetsPage()
        {
            InitializeComponent();
            Search();
        }
        public void Search()
        {
            if (SearchTextBox.Text.Length != 0)
            {
                PetsListView.ItemsSource = null;
                PetsListView.ItemsSource = App.db.Pets.Where(x => x.Description.ToLower().Contains(SearchTextBox.Text.ToLower()) && x.IdUsers == App.id_user).ToList();
            }
            else
            {
                PetsListView.ItemsSource = null;
                PetsListView.ItemsSource = App.db.Pets.Where(x => x.IdUsers == App.id_user).ToList();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.main.MyFrame.NavigationService.Navigate(new Pages.AddPetsPage());
        }
    }
}
