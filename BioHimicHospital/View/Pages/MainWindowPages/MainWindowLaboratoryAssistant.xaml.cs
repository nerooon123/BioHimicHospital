using BioHimicHospital.Model;
using BioHimicHospital.View.Pages.ResourcePages;
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
    /// Логика взаимодействия для MainWindowLaboratoryAssistant.xaml
    /// </summary>
    public partial class MainWindowLaboratoryAssistant : Page
    {
        Core db = new Core();
        public MainWindowLaboratoryAssistant(LaboratoryAssistants userLaborant)
        {
            InitializeComponent();

            FirstNameTextBlock.Text = userLaborant.FirstName;
            LastNameTextBlock.Text = userLaborant.LastName;
            PatronymicTextBlock.Text = userLaborant.Patronymic;

            //try
            //{
            //    // Создаем новую запись в таблице
            //    var newItem = new LaboratoryAssistants
            //    {
            //        EntryData = Convert.ToString(DateTime.Now) // Записываем текущее время
            //    };
            //    // Добавляем запись в таблицу и сохраняем изменения в базе данных
            //    db.context.LaboratoryAssistants.Add(newItem);
            //    db.context.SaveChanges();

            //}
            //catch
            //{
            //    MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void AnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnalysisReportPage());
        }

        private void BiomaterialResearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BiomaterialResearchPage());
        }
    }
}
