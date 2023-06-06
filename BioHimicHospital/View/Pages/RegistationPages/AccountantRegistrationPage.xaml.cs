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
    /// Логика взаимодействия для AccountantRegistrationPage.xaml
    /// </summary>
    public partial class AccountantRegistrationPage : Page
    {
        Core db = new Core();
        public AccountantRegistrationPage()
        {
            InitializeComponent();
            AccountantServicesComboBox.ItemsSource = db.context.AccountantServices.ToList();
            AccountantServicesComboBox.DisplayMemberPath = "NameAccountantService";
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                Accountants newAccountant = new Accountants()
                {
                    FirstName = LastNameTextBox.Text,
                    LastName = FirstNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    IdAccountantService = 1 + AccountantServicesComboBox.SelectedIndex,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Password
                };

                db.context.Users.Add(newUser);
                db.context.Accountants.Add(newAccountant);
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
