using BioHimicHospital.Model;
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

namespace BioHimicHospital.View.Pages.RegistationPages
{
    /// <summary>
    /// Логика взаимодействия для LabaratoryAssistantRegistrationPage.xaml
    /// </summary>
    public partial class LabaratoryAssistantRegistrationPage : Page
    {
        Core db = new Core();
        public LabaratoryAssistantRegistrationPage()
        {
            InitializeComponent();

            LaboratoryServicesComboBox.ItemsSource = db.context.LaboratoryServices.ToList();
            LaboratoryServicesComboBox.DisplayMemberPath = "NameLaboratoryService";
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LaboratoryAssistants newLaboratoryAssistant = new LaboratoryAssistants() 
                {
                    FirstName = LastNameTextBox.Text,
                    LastName = FirstNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    IdLaboratoryService = 1 + LaboratoryServicesComboBox.SelectedIndex,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Password
                };

                db.context.Users.Add(newUser);
                db.context.LaboratoryAssistants.Add(newLaboratoryAssistant);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
