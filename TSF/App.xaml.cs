using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TSF_Models;

namespace TSF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Bibliotheque Manager { get; private set; } = new Bibliotheque();

        public App()
        {
            Manager.Chargement();
        }
        /*
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Login l = new Login();
            this.MainWindow = l;
            l.Show();
        }*/
    }
}
