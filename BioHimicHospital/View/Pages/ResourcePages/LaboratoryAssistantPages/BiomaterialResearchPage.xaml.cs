using BioHimicHospital.Model;
using BioHimicHospital.View.Pages.ResourcePages.LaboratoryAssistantPages;
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

namespace BioHimicHospital.View.Pages.ResourcePages
{
    /// <summary>
    /// Логика взаимодействия для BiomaterialResearchPage.xaml
    /// </summary>
    public partial class BiomaterialResearchPage : Page
    {
        Core db = new Core();
        public BiomaterialResearchPage()
        {
            InitializeComponent();
            BomaterialResearchGrid.ItemsSource = db.context.BiomaterialResearch.ToList();
        }

        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var biores = new ObservableCollection<BiomaterialResearch>(db.context.BiomaterialResearch.ToList());
                BomaterialResearchGrid.ItemsSource = biores;
            }
            else
            {
                var result = db.context.BiomaterialResearch.Where(p => p.IdBiomaterialResearch.ToString().Contains(searchText)
                    || p.Patients.FirstName.ToString().Contains(searchText)
                    || p.LaboratoryServices.NameLaboratoryService.ToString().Contains(searchText)
                    || p.Price.ToString().Contains(searchText)).ToList();

                var biores = new ObservableCollection<BiomaterialResearch>(result);
                BomaterialResearchGrid.ItemsSource = biores;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                var item = BomaterialResearchGrid.SelectedItem as BiomaterialResearch;
                //проверка того, что пользователь выбрал строки для удаления
                if (item == null) {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }

                else {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.BiomaterialResearch.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        BomaterialResearchGrid.ItemsSource = db.context.BiomaterialResearch.ToList();
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void AddNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddBiomaterialResearchPage());
        }

        private void BomaterialResearchGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                // Get the edited value from the EditingElement
                var textBox = e.EditingElement as TextBox;
                var newValue = textBox.Text;

                // Get the object being edited
                var item = e.Row.Item as BiomaterialResearch;

                // Update the corresponding property
                if (e.Column.Header.ToString() == "Стоимость")
                    item.Price = newValue;


                db.context.SaveChanges();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void excel_Click(object sender, RoutedEventArgs e)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var data = db.context.BiomaterialResearch.ToList();
                var worksheet = excelPackage.Workbook.Worksheets.Add("Название листа");

                // добавляем заголовки таблицы
                worksheet.Cells[1, 1].Value = "ID биохического иследование";
                worksheet.Cells[1, 2].Value = "Имя пациента";
                worksheet.Cells[1, 3].Value = "Название услуги";
                worksheet.Cells[1, 4].Value = "Стоимсочть";
                // ...

                // заполняем таблицу данными
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.IdBiomaterialResearch;
                    worksheet.Cells[row, 2].Value = item.Patients.FirstName;
                    worksheet.Cells[row, 3].Value = item.LaboratoryServices.NameLaboratoryService;
                    worksheet.Cells[row, 4].Value = item.Price;
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
            MessageBox.Show("Пока в разработке, но ничего страшного, скоро будет)");
        }
    }
}
