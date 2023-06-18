using BioHimicHospital.Model;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    public partial class AnalysisReportPage : System.Windows.Controls.Page
    {
        Core db = new Core();
        public AnalysisReportPage()
        {
            InitializeComponent();
            AnalysisDataGrid.ItemsSource = db.context.AnalysisReport.ToList();

        }


        private void OnSearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            // 1 ВАРИАНТ (РАБОТАЕТ ПЛОХО)

            //string searchText = SearchTextBox.Text;
            //foreach (var item in AnalysisDataGrid.Items)
            //{
            //    // Получаем значение поля, по которому ищем (например, название товара)
            //    string searchField = ((AnalysisReport)item).CholesterolLevels;

            //    if (searchField.Contains(searchText))
            //    {
            //        // Если значение поля содержит поисковый запрос, показываем элемент
            //        AnalysisDataGrid.Items.Refresh();
            //        AnalysisDataGrid.SelectedItem = item;
            //        AnalysisDataGrid.ScrollIntoView(item);
            //        break;
            //    }
            //    else
            //    {
            //        // Если значение поля не содержит поисковый запрос, скрываем элемент
            //        AnalysisDataGrid.Items.Refresh();
            //    }
            //}

            // 2 ВАРИАНТ (Рабочий вариант)

            string searchText = SearchTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var anlysis = new ObservableCollection<AnalysisReport>(db.context.AnalysisReport.ToList());
                AnalysisDataGrid.ItemsSource = anlysis;
            }
            else
            {
                var result = db.context.AnalysisReport.Where(p => p.IdAnalysisReport.ToString().Contains(searchText)
                    || p.BiomaterialResearch.Patients.FirstName.ToString().Contains(searchText)
                    || p.BloodGlucoseLevel.ToString().Contains(searchText)
                    || p.CholesterolLevels.ToString().Contains(searchText)
                    || p.ThePresenceOfProteinsInTheUrine.ToString().Contains(searchText)).ToList();

                var analysis = new ObservableCollection<AnalysisReport>(result);
                AnalysisDataGrid.ItemsSource = analysis;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = AnalysisDataGrid.SelectedItem as AnalysisReport;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {

                    MessageBox.Show("Вы не выбрали ни одной строки");

                    return;

                }

                else
                {

                    //выполним удаление только в том случае, если пользователь даст согласие на удаление

                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {

                        //удаляем выбранную строку

                        db.context.AnalysisReport.Remove(item);

                        db.context.SaveChanges();

                        MessageBox.Show("Информация удалена");

                        //обновление DataGrid

                        AnalysisDataGrid.ItemsSource = db.context.AnalysisReport.ToList();

                    }

                }
            }

            catch (Exception)

            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AnalysisReport customerRow = AnalysisDataGrid.SelectedItem as AnalysisReport;
                AnalysisReport customer = (from p in db.context.AnalysisReport where p.IdAnalysisReport == customerRow.IdAnalysisReport select p).Single();
                customer.BloodGlucoseLevel = customerRow.BloodGlucoseLevel;
                customer.CholesterolLevels = customerRow.CholesterolLevels;
                customer.ThePresenceOfProteinsInTheUrine = customerRow.ThePresenceOfProteinsInTheUrine;
                db.context.SaveChanges();
                MessageBox.Show("Row Updated Successfully.");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void AddNewAnalyses_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAnalysisReportPage());
        }

        private void AnalysisDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                // Get the edited value from the EditingElement
                var textBox = e.EditingElement as TextBox;
                var newValue = textBox.Text;

                // Get the object being edited
                var item = e.Row.Item as AnalysisReport;

                // Update the corresponding property
                if (e.Column.Header.ToString() == "Глюкозы в крови")
                    item.BloodGlucoseLevel = newValue;
                else if (e.Column.Header.ToString() == "Уровень холестерина")
                    item.CholesterolLevels = newValue;
                else if (e.Column.Header.ToString() == "Наличие протеинов в моче")
                    item.ThePresenceOfProteinsInTheUrine = newValue;

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

            // 1 ВАРИАНТ ИЗ DataGrid В Excel 

            //// Создаем новый Excel пакет
            //ExcelPackage excelPackage = new ExcelPackage();

            //// Добавляем лист в пакет
            //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Analysis");

            //// Заполняем документ значениями из dataGrid
            //for (int i = 1; i <= AnalysisDataGrid.Items.Count; i++)
            //{
            //    for (int j = 1; j <= AnalysisDataGrid.Columns.Count; j++)
            //    {
            //        var cellValue = AnalysisDataGrid.Columns[j - 1].GetCellContent(AnalysisDataGrid.Items[i - 1]);
            //        worksheet.Cells[i, j].Value = cellValue?.ToString();
            //    }
            //}


            //// Сохраняем документ Excel
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            //if (saveFileDialog.ShowDialog() == true)
            //{
            //    // Сохраняем документ Excel в выбранное место
            //    File.WriteAllBytes(saveFileDialog.FileName, excelPackage.GetAsByteArray());
            //}

            //// Очищаем пакет Excel
            //excelPackage.Dispose();



            // 2 ВАРИАНТ ИЗ САМОЙ БД В Excel

            using (var excelPackage = new ExcelPackage())
            {
                var data = db.context.AnalysisReport.ToList();
                var worksheet = excelPackage.Workbook.Worksheets.Add("Название листа");

                // добавляем заголовки таблицы
                worksheet.Cells[1, 1].Value = "ID Анализа";
                worksheet.Cells[1, 2].Value = "Имя пациента";
                worksheet.Cells[1, 3].Value = "Глюкозы в крови";
                worksheet.Cells[1, 4].Value = "Уровень холестерина";
                worksheet.Cells[1, 5].Value = "Наличие протеинов в моче";
                worksheet.Cells[1, 6].Value = "ЕКГ";
                worksheet.Cells[1, 7].Value = "УЗИ";
                worksheet.Cells[1, 8].Value = "КТ-скан";
                // ...

                // заполняем таблицу данными
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.IdAnalysisReport;
                    worksheet.Cells[row, 2].Value = item.BiomaterialResearch.Patients.FirstName;
                    worksheet.Cells[row, 3].Value = item.BloodGlucoseLevel;
                    worksheet.Cells[row, 4].Value = item.CholesterolLevels;
                    worksheet.Cells[row, 5].Value = item.ThePresenceOfProteinsInTheUrine;
                    worksheet.Cells[row, 6].Value = item.Electrocardiography;
                    worksheet.Cells[row, 7].Value = item.UltrasoundExamination;
                    worksheet.Cells[row, 8].Value = item.ComputedTomography;
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
            //// Создаем объект приложения Word
            //Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            //wordApp.Visible = true;

            //// Создаем новый документ Word
            //Document wordDoc = wordApp.Documents.Add();

            //List<AnalysisReport> analysis = db.context.AnalysisReport.ToList();

            //// Заполняем документ Word данными
            //Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordDoc.Range(), analysis.Count, 8);

            //// Задаем ширину столбцов таблицы
            //table.Columns[1].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[2].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[3].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[4].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[5].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[6].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[7].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
            //table.Columns[8].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);

            //// Добавляем заголовки таблицы
            //table.Cell(1, 1).Range.Text = "Address";
            //table.Cell(1, 2).Range.Text = "Address";
            //table.Cell(1, 3).Range.Text = "Address";
            //table.Cell(1, 4).Range.Text = "Address";
            //table.Cell(1, 5).Range.Text = "Address";
            //table.Cell(1, 6).Range.Text = "Address";
            //table.Cell(1, 7).Range.Text = "Address";
            //table.Cell(1, 8).Range.Text = "Address";

            //// Добавляем данные в таблицу
            //for (int i = 0; i < analysis.Count; i++)
            //{
            //    table.Cell(i + 2, 1).Range.Text = analysis[i].IdAnalysisReport.ToString();
            //    table.Cell(i + 2, 2).Range.Text = analysis[i].IdBiomaterialResearch.ToString();
            //    table.Cell(i + 2, 3).Range.Text = analysis[i].BloodGlucoseLevel;
            //    table.Cell(i + 2, 4).Range.Text = analysis[i].CholesterolLevels;
            //    table.Cell(i + 2, 5).Range.Text = analysis[i].ThePresenceOfProteinsInTheUrine;
            //    table.Cell(i + 2, 6).Range.Text = "1";
            //    table.Cell(i + 2, 7).Range.Text = "1";
            //    table.Cell(i + 2, 8).Range.Text = "1";
            //}

            //// Сохраняем документ Word
            //wordDoc.SaveAs2(@"C:\Users\keler\OneDrive\Рабочий стол\sources\Customers.docx", WdSaveFormat.wdFormatDocumentDefault);

            //// Закрываем документ Word и приложение
            //wordDoc.Close();
            //wordApp.Quit();


            MessageBox.Show("Пока в разработке!");
        }
    }
}
