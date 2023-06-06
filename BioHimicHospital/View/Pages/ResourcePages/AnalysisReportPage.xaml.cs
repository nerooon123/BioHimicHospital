using BioHimicHospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BioHimicHospital.View.Pages.ResourcePages
{
    /// <summary>
    /// Логика взаимодействия для AnalysisReportPage.xaml
    /// </summary>
    public partial class AnalysisReportPage : Page
    {
        Core db = new Core();
        public AnalysisReportPage()
        {
            InitializeComponent();
            AnalysisDataGrid.ItemsSource = db.context.AnalysisReport.ToList();
        }

        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var filtered = db.context.AnalysisReport.Where(animal => animal.ToString().StartsWith(SearchTextBox.Text));
            AnalysisDataGrid.ItemsSource = filtered;
        }
    }
}
