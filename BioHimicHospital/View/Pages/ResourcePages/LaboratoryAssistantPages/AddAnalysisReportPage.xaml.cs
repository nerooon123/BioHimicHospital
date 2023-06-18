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
using Microsoft.Win32;
using System.IO;
using BioHimicHospital.Model;

namespace BioHimicHospital.View.Pages.ResourcePages
{
    /// <summary>
    /// Логика взаимодействия для AddAnalysisReportPage.xaml
    /// </summary>
    public partial class AddAnalysisReportPage : Page
    {
        Core db = new Core();
        public AddAnalysisReportPage()
        {
            InitializeComponent();
            IdBiomaterialResearchComboBox.ItemsSource = db.context.BiomaterialResearch.ToList();
            IdBiomaterialResearchComboBox.DisplayMemberPath = "IdBiomaterialResearch";
        }
        private byte[] ekg_imageBytes = null;
        private byte[] uzi_imageBytes = null;
        private byte[] kt_imageBytes = null;
        private void EKGUploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(); // показываем
            byte[] ekg_image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла
            ekg_imageBytes = ekg_image_bytes;
        }

        private void UZIUploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(); // показываем
            byte[] uzi_image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла
            uzi_imageBytes = uzi_image_bytes;
        }

        private void KTScanUploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(); // показываем
            byte[] kt_image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла
            kt_imageBytes = kt_image_bytes;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (IdBiomaterialResearchComboBox.SelectedItem != null &&
                    BloodGlucoseLevel.Text != String.Empty &&
                    CholesterolLevels.Text != String.Empty &&
                    ThePresenceOfProteinsInTheUrine.Text != String.Empty &&
                    ekg_imageBytes != null && 
                    uzi_imageBytes != null &&
                    kt_imageBytes != null)
                {
                    AnalysisReport newAnalysisReport = new AnalysisReport()
                    {
                        IdBiomaterialResearch = 1 + IdBiomaterialResearchComboBox.SelectedIndex,
                        BloodGlucoseLevel = BloodGlucoseLevel.Text,
                        CholesterolLevels = CholesterolLevels.Text,
                        ThePresenceOfProteinsInTheUrine = ThePresenceOfProteinsInTheUrine.Text,
                        Electrocardiography = ekg_imageBytes,
                        UltrasoundExamination = uzi_imageBytes,
                        ComputedTomography = kt_imageBytes
                    };

                    db.context.AnalysisReport.Add(newAnalysisReport);
                    db.context.SaveChanges();

                    MessageBox.Show("Добавление выполнено успешно !",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    this.NavigationService.Navigate(new AnalysisReportPage());
                }
                else
                {
                    MessageBox.Show("Вы что то ввели некорректно!");
                }

            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
        }
    }
}
