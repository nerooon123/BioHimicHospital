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
    /// Логика взаимодействия для PatientRegistrationPage.xaml
    /// </summary>
    public partial class PatientRegistrationPage : Page
    {
        Core db = new Core();
        public PatientRegistrationPage()
        {
            InitializeComponent();
            InsuranceCompanyComboBox.ItemsSource = db.context.InsuranceCompany.ToList();
            InsuranceCompanyComboBox.DisplayMemberPath = "NameInsuranceCompany";
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patients newPatient = new Patients()
                {
                    FirstName = LastNameTextBox.Text,
                    LastName = FirstNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    DateOfBirthday = Convert.ToDateTime(DateOfBirthdayPicker.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    SeriesAndNumberPassport = SeriesAndNumberPassportTextBox.Text,
                    NumberPhone = NumberPhoneTextBox.Text,
                    Email = EmailTextBox.Text,
                    PolicyNumber = PolicyNumberTextBox.Text,
                    IdInsuranceCompany = 1 + InsuranceCompanyComboBox.SelectedIndex,
                    Login = LoginTextBox.Text,
                };
                Users newUser = new Users()
                {
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Password
                };

                db.context.Users.Add(newUser);
                db.context.Patients.Add(newPatient);
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
