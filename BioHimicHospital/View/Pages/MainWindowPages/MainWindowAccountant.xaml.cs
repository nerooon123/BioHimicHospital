﻿using BioHimicHospital.Model;
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
    /// Логика взаимодействия для MainWindowAccountant.xaml
    /// </summary>
    public partial class MainWindowAccountant : Page
    {
        Core db = new Core();
        public MainWindowAccountant()
        {
            InitializeComponent();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}