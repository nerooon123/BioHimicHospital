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

namespace BioHimicHospital.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindowPage.xaml
    /// </summary>
    public partial class MainWindowPage : Page
    {
        Core db = new Core();
        public MainWindowPage(Users auth)
        {
            InitializeComponent();
            Console.WriteLine(auth);



            var userLaborant = db.context.LaboratoryAssistants.Where(
            x => x.Login == auth.Login
            ).FirstOrDefault();

            var userAdmin = db.context.Adminstration.Where(
            x => x.Login == auth.Login
            ).FirstOrDefault();

            var userPatient = db.context.Patients.Where(
            x => x.Login == auth.Login
            ).FirstOrDefault();

            var userAccountant = db.context.Accountants.Where(
            x => x.Login == auth.Login
            ).FirstOrDefault();

            if (userLaborant != null)
            {
                Patients.Visibility = Visibility.Visible;
            }

            if (userAdmin != null)
            {
                Patients.Visibility = Visibility.Visible;
                Departments.Visibility = Visibility.Visible;
                Doctors.Visibility = Visibility.Visible;
                Specializations.Visibility = Visibility.Visible;
                Diseases.Visibility = Visibility.Visible;
                Users.Visibility = Visibility.Visible;
                Adminstrations.Visibility = Visibility.Visible;
                Offices.Visibility = Visibility.Visible;
                Genders.Visibility = Visibility.Visible;
                Wards.Visibility = Visibility.Visible;
            }

            if (userPatient != null)
            {
                Patients.Visibility = Visibility.Visible;

            }
        }
    }
}
