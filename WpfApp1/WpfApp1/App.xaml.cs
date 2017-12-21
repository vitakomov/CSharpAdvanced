﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Создаем первое окно
            MainWindow wnd = new MainWindow();
            wnd.Title = "Hello, WPF!";
            // Отображаем окно
            wnd.Show();
        }
    }
}
