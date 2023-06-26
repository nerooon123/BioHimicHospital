using BioHimicHospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BioHimicHospital.View.Pages.ResourcePages.AccountantPages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        Core db = new Core();
        public WorkersPage()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = db.context.Accountants.ToList();
        }

        private void AnalysisDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                // Get the edited value from the EditingElement
                var textBox = e.EditingElement as TextBox;
                var newValue = textBox.Text;

                // Get the object being edited
                var item = e.Row.Item as LaboratoryAssistants;

                // Update the corresponding property
                if (e.Column.Header.ToString() == "Фамилия")
                    item.FirstName = newValue;
                else if (e.Column.Header.ToString() == "Имя")
                    item.LastName = newValue;
                else if (e.Column.Header.ToString() == "Отчество")
                    item.Patronymic = newValue;
                else if (e.Column.Header.ToString() == "Зарплата")
                    item.Salary = Convert.ToInt32(newValue);

                db.context.SaveChanges();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void excel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void word_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var anlysis = new ObservableCollection<LaboratoryAssistants>(db.context.LaboratoryAssistants.ToList());
                UsersDataGrid.ItemsSource = anlysis;
            }
            else
            {
                var result = db.context.LaboratoryAssistants.Where(p => p.IdLaboratoryAssistant.ToString().Contains(searchText)
                    || p.LastName.ToString().Contains(searchText)
                    || p.FirstName.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.Salary.ToString().Contains(searchText)).ToList();

                var analysis = new ObservableCollection<LaboratoryAssistants>(result);
                UsersDataGrid.ItemsSource = analysis;
            }
        }
    }
}
