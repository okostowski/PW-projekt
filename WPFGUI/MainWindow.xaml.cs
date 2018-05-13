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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings _settings = new Settings();

        private ObservableCollection<IProduct> _products;
        public ObservableCollection<IProduct> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public MainWindow()
        {
            DataProvider dp = new DataProvider(_settings.DAO_Name);
            _products = new ObservableCollection<IProduct>(dp.TeaList);
            InitializeComponent();
        }
    }
}
