using BioHimicHospital.Model;
using BioHimicHospital.View.Pages.ResourcePages.PatientPages;
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


namespace BioHimicHospital.View.Pages.MainWindowPages
{
    /// <summary>
    /// Логика взаимодействия для MainWindowPatient.xaml
    /// </summary>
    public partial class MainWindowPatient : Page
    {
        public MainWindowPatient(Patients userPatient)
        {
            InitializeComponent();

            FirstName.Text = userPatient.FirstName;
            LastName.Text = userPatient.LastName;
            Patronymic.Text = userPatient.Patronymic;
            DateOfBirthday.Text = userPatient.DateOfBirthday.ToString();
            SeriesAndNumberPassport.Text = userPatient.SeriesAndNumberPassport;
            NumberPhone.Text = userPatient.NumberPhone;
            Email.Text = userPatient.Email;
            PolicyNumber.Text = userPatient.PolicyNumber;
            IdInsuranceCompany.Text = userPatient.InsuranceCompany.NameInsuranceCompany;
            IdOrder.Text = userPatient.IdOrder.ToString();
            Login.Text = userPatient.Login;
            Password.Text = userPatient.Users.Password;

        }

        private void NewAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            // идея в том что пациент может сделать reques запрос на анализы, дальше после разрешение лаборанта, начнут иследовать анализ 

            MessageBox.Show("Пока в разработке. Ну а так вкладка пациента вообше не требовалось в тз )))");
        }

        private void OnlineChatButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientChatPage());
        }
    }
}
