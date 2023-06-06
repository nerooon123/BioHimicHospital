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
        public MainWindowLaboratoryAssistant()
        {
            InitializeComponent();
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
