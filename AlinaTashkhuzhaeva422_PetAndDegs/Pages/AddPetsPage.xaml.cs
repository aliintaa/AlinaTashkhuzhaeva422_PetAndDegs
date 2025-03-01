using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPetsPage.xaml
    /// </summary>
    public partial class AddPetsPage : Page
    {
        public byte[] bytes;
        public AddPetsPage()
        {
            InitializeComponent();
        }



        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    bytes = imageBytes;
                    BitmapImage bitmap = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                    }
                    PetImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.main.MyFrame.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (bytes != null && PetNameComboBox.SelectedIndex != -1)
            {
                App.db.Pets.Add(new Pets()
                {
                    Name = (PetNameComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                    Description = DescriptionTextBox.Text,
                    PhotoPath = bytes,
                    IdUsers = PetNameComboBox.SelectedIndex + 1

                });
                App.db.SaveChanges();
                App.main.MyFrame.NavigationService.Navigate(new Pages.PetsPage());
            }
            else
            {
                MessageBox.Show("Заполни инфу");
            }
        }
    }
}
