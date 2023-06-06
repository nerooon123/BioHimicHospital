using BioHimicHospital.View.Pages.RegistationPages;
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

namespace BioHimicHospital.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }


        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientRegistrationPage());
        }

        private void LabaratoryAssistantButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LabaratoryAssistantRegistrationPage());
        }

        private void AccountantButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AccountantRegistrationPage());
        }

        private void AdminstrationButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminstrationRegistrationPage());
        }
    }
}
