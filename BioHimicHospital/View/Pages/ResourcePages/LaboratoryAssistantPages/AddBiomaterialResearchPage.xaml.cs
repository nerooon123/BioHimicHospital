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

namespace BioHimicHospital.View.Pages.ResourcePages.LaboratoryAssistantPages
{
    /// <summary>
    /// Логика взаимодействия для AddBiomaterialResearchPage.xaml
    /// </summary>
    public partial class AddBiomaterialResearchPage : Page
    {
        Core db = new Core();
        public AddBiomaterialResearchPage()
        {
            InitializeComponent();

            // заполнение комбобокса пациента
            PatientComboBox.ItemsSource = db.context.Patients.ToList();
            PatientComboBox.DisplayMemberPath = "FirstName";

            LabServicesComboBox.ItemsSource = db.context.LaboratoryServices.ToList();
            LabServicesComboBox.DisplayMemberPath = "NameLaboratoryService";
        }

        // оформление заказа
        private void PlaceAnOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (PatientComboBox.SelectedItem != null && LabServicesComboBox.SelectedItem != null && CostTextBox.Text != String.Empty)
                {
                    BiomaterialResearch newBiomaterialResearch = new BiomaterialResearch()
                    {
                        IdPatient = 1 + PatientComboBox.SelectedIndex,
                        IdLaboraotryService = 1 + LabServicesComboBox.SelectedIndex,
                        Cost = Convert.ToInt32(CostTextBox.Text)
                    };

                    db.context.BiomaterialResearch.Add(newBiomaterialResearch);
                    db.context.SaveChanges();

                    MessageBox.Show("Добавление выполнено успешно !",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                    this.NavigationService.Navigate(new BiomaterialResearchPage());
                }
                else
                {
                    MessageBox.Show("Вы не заполнили поле, или не выбрали пациента/услугу!");
                }
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
