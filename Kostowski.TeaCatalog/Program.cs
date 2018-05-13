using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;
using Kostowski.TeaCatalog.BLC;
using Kostowski.TeaCatalog.UI.Properties;

namespace Kostowski.TeaCatalog.UI
{
    public class Program
    {
        private static Settings _settings = new Settings();
        public static void Main(string[] args)
        {
            DataProvider dp = new DataProvider(_settings.DAO_Name);
            System.Console.WriteLine("Baza 1:");
            System.Console.WriteLine(" Producers:");
            foreach (var p in dp.ProducersList)
            {
                System.Console.WriteLine($"  {p.Name} founded in {p.Founded}");
            }
            System.Console.WriteLine(" Products:");
            foreach (var t in dp.TeaList)
            {
                System.Console.WriteLine($"  Name: {t.Name}, producer: {t.Producer.Name}, color: {t.Color}");
            }
        }
    }
}
