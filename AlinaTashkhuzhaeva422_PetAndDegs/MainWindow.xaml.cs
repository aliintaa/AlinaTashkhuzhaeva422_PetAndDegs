using Microsoft.Win32;
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

namespace AlinaTashkhuzhaeva422_PetAndDegs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Pet> pets = new List<Pet>();
        private string currentUser;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoadPets()
        {
            // Загрузка данных о питомцах (можно заменить на загрузку из базы данных)
            pets.Add(new Pet { Name = "Ра", Description = "Котенок Ра вкусно покушал, он доволен.", PhotoPath = "path_to_ra_image.jpg" });
            pets.Add(new Pet { Name = "Нуби", Description = "Собачка Нуби играет с мячиком.", PhotoPath = "path_to_nubi_image.jpg" });
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            currentUser = UsernameTextBox.Text;

            if (currentUser == "Андрей")
            {
                PetInfoTextBlock.Text = pets[0].Description; // Информация о котенке Ра
            }
            else if (currentUser == "Деля")
            {
                PetInfoTextBlock.Text = pets[1].Description; // Информация о собачке Нуби
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя");
                return;
            }

            LoginPanel.Visibility = Visibility.Collapsed;
            InfoPanel.Visibility = Visibility.Visible;
            UpdatePetsList();
        }

        private void UpdatePetsList()
        {
            PetsListBox.Items.Clear();
            foreach (var pet in pets)
            {
               
                PetsListBox.Items.Add(pet.Name + ": " + pet.Description);
            }
        }

        private void AddPetButton_Click(object sender, RoutedEventArgs e)
        {
            InfoPanel.Visibility = Visibility.Collapsed;
            AddPetPanel.Visibility = Visibility.Visible;
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                PetImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                PetImage.Tag = openFileDialog.FileName; // Сохраняем путь к изображению
            }
        }

        private void SavePetButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedPet = (PetComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = DescriptionTextBox.Text;
            string photoPath = PetImage.Tag?.ToString();

            if (string.IsNullOrEmpty(selectedPet) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(photoPath))
            {
                MessageBox.Show("Пожалуйста заполните все поля.");
                return;
            }

            pets.Add(new Pet { Name = selectedPet, Description = description, PhotoPath = photoPath });
            MessageBox.Show("Питомец добавлен!");

            AddPetPanel.Visibility = Visibility.Collapsed;
            InfoPanel.Visibility = Visibility.Visible;
            UpdatePetsList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower();
            PetsListBox.Items.Clear();

            foreach (var pet in pets)
            {
                if (pet.Name.ToLower().Contains(searchTerm) || pet.Description.ToLower().Contains(searchTerm))
                {
                    PetsListBox.Items.Add(pet.Name + ": " + pet.Description);
                }
            }
        }
    }

    public class Pet
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}

