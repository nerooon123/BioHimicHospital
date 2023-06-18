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

namespace BioHimicHospital.View.Pages.ResourcePages.AdminstartionPages
{
    /// <summary>
    /// Логика взаимодействия для UsersControlPage.xaml
    /// </summary>
    public partial class UsersControlPage : Page
    {
        Core db = new Core();
        public UsersControlPage()
        {
            InitializeComponent();
            AdminstartionDataGrid.ItemsSource = db.context.Adminstrations.ToList();
            AccountantDataGrid.ItemsSource = db.context.Accountants.ToList();
            LaboratoryAssistantDataGrid.ItemsSource = db.context.LaboratoryAssistants.ToList();
            PatientDataGrid.ItemsSource = db.context.Patients.ToList();
        }


        // Удаление адмистратора
        private void AdminstartionDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = AdminstartionDataGrid.SelectedItem as Adminstrations;
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
                        db.context.Adminstrations.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        AdminstartionDataGrid.ItemsSource = db.context.Adminstrations.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void AccountantDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = AccountantDataGrid.SelectedItem as Accountants;
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
                        db.context.Accountants.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        AccountantDataGrid.ItemsSource = db.context.Accountants.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void LaboratoryAssistantButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = LaboratoryAssistantDataGrid.SelectedItem as LaboratoryAssistants;
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
                        db.context.LaboratoryAssistants.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        LaboratoryAssistantDataGrid.ItemsSource = db.context.LaboratoryAssistants.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        // Пациенты
        private void PatientDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = PatientDataGrid.SelectedItem as Patients;
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
                        db.context.Patients.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        PatientDataGrid.ItemsSource = db.context.Patients.ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }



        private void SearchAdminstartionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchAdminstartionTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var admin = new ObservableCollection<Adminstrations>(db.context.Adminstrations.ToList());
                AdminstartionDataGrid.ItemsSource = admin;
            }
            else
            {
                var result = db.context.Adminstrations.Where(p => p.IdAdminstration.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var admin = new ObservableCollection<Adminstrations>(result);
                AdminstartionDataGrid.ItemsSource = admin;
            }
        }

        private void SearchAccountantTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchAccountantTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var accountant = new ObservableCollection<Accountants>(db.context.Accountants.ToList());
                AccountantDataGrid.ItemsSource = accountant;
            }
            else
            {
                var result = db.context.Accountants.Where(p => p.IdAccountant.ToString().Contains(searchText)
                    || p.LastName.ToString().Contains(searchText)
                    || p.FirstName.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.AccountantServices.NameAccountantService.ToString().Contains(searchText)
                    || p.EntryDate.ToString().Contains(searchText)
                    || p.Salary.ToString().Contains(searchText)
                    || p.Ward.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var accountant = new ObservableCollection<Accountants>(result);
                AccountantDataGrid.ItemsSource = accountant;
            }
        }

        private void SearchLaboratoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchLaboratoryTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var laboratoryAssistant = new ObservableCollection<LaboratoryAssistants>(db.context.LaboratoryAssistants.ToList());
                LaboratoryAssistantDataGrid.ItemsSource = laboratoryAssistant;
            }
            else
            {
                var result = db.context.LaboratoryAssistants.Where(p => p.IdLaboratoryAssistant.ToString().Contains(searchText)
                    || p.LastName.ToString().Contains(searchText)
                    || p.FirstName.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.LaboratoryServices.NameLaboratoryService.ToString().Contains(searchText)
                    || p.EntryDate.ToString().Contains(searchText)
                    || p.Salary.ToString().Contains(searchText)
                    || p.Salary.ToString().Contains(searchText)
                    || p.Ward.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var laboratoryAssistant = new ObservableCollection<LaboratoryAssistants>(result);
                LaboratoryAssistantDataGrid.ItemsSource = laboratoryAssistant;
            }
        }

        private void SearchPatientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchPatientTextBox.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                var patient = new ObservableCollection<Patients>(db.context.Patients.ToList());
                PatientDataGrid.ItemsSource = patient;
            }
            else
            {
                var result = db.context.Patients.Where(p => p.IdPatient.ToString().Contains(searchText)
                    || p.LastName.ToString().Contains(searchText)
                    || p.FirstName.ToString().Contains(searchText)
                    || p.Patronymic.ToString().Contains(searchText)
                    || p.DateOfBirthday.ToString().Contains(searchText)
                    || p.SeriesAndNumberPassport.ToString().Contains(searchText)
                    || p.NumberPhone.ToString().Contains(searchText)
                    || p.Email.ToString().Contains(searchText)
                    || p.PolicyNumber.ToString().Contains(searchText)
                    || p.InsuranceCompany.NameInsuranceCompany.ToString().Contains(searchText)
                    || p.IdOrder.ToString().Contains(searchText)
                    || p.Login.ToString().Contains(searchText)
                    || p.Users.Password.ToString().Contains(searchText)).ToList();

                var patient = new ObservableCollection<Patients>(result);
                PatientDataGrid.ItemsSource = patient;
            }
        }
    }
}
