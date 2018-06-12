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
using Kostowski.TeaCatalog.Interfaces;
using System.Collections.ObjectModel;
using Kostowski.TeaCatalog.BLC;
using Kostowski.TeaCatalog.WPFGUI.Properties;

namespace WPFGUI
{
    public partial class MainWindow : Window
    {
        static public DataProvider Provider;

        private Settings _settings = new Settings();

        public MainWindow()
        {
            if (Provider == null)
                Provider = new DataProvider(_settings.DAO_Name);
            InitializeComponent();
        }
    }
}
