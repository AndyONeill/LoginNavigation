﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mw = new LoginNavigationWindow();
            mw.Show();
            mw.SetValue(LoginNavigationWindow.ParentViewModelProperty, typeof(LoginViewModel));
        }
    }
}
