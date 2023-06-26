using BioHimicHospital.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        private void excel_Click(object sender, RoutedEventArgs e)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var data = db.context.LaboratoryAssistants.ToList();
                var worksheet = excelPackage.Workbook.Worksheets.Add("Отчет о работниках");

                // добавляем заголовки таблицы
                worksheet.Cells[1, 1].Value = "Фамилия";
                worksheet.Cells[1, 2].Value = "Имя";
                worksheet.Cells[1, 3].Value = "Отчество";
                worksheet.Cells[1, 4].Value = "Зарплата";
                // ...

                // заполняем таблицу данными
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.LastName;
                    worksheet.Cells[row, 2].Value = item.FirstName;
                    worksheet.Cells[row, 3].Value = item.Patronymic;
                    worksheet.Cells[row, 4].Value = item.Salary;
                    // ...

                    row++;
                }

                // сохраняем файл на диск

                // Сохраняем документ Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Сохраняем документ Excel в выбранное место
                    File.WriteAllBytes(saveFileDialog.FileName, excelPackage.GetAsByteArray());
                }

                // Очищаем пакет Excel
                excelPackage.Dispose();
            }
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
