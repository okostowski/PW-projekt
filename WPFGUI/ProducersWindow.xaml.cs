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
using System.Windows.Shapes;
using Kostowski.TeaCatalog.Interfaces;
using System.Collections.ObjectModel;
using Kostowski.TeaCatalog.BLC;

namespace Kostowski.TeaCatalog.WPFGUI
{
    /// <summary>
    /// Logika interakcji dla klasy ProducersWindow.xaml
    /// </summary>
    public partial class ProducersWindow : Window
    {
        private ObservableCollection<IProducer> _producers;
        public ObservableCollection<IProducer> Producers
        {
            get { return _producers; }
            set { _producers = value; }
        }

        public ProducersWindow()
        {
            DataProvider dp = new DataProvider();
            _producers = new ObservableCollection<IProducer>(dp.ProducersList);
            InitializeComponent();
        }
    }
}
