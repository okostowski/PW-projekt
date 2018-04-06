using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.BLC;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvider dp = new DataProvider();
            System.Console.WriteLine("Producers:");
            foreach (var p in dp.ProducersList)
                System.Console.WriteLine($" {p.Name} founded in {p.Founded}");
            System.Console.WriteLine("Products:");
            foreach (var t in dp.TeaList)
                System.Console.WriteLine($" Name: {t.Name}, producer: {t.Producer.Name}, color: {t.Color}");
        }
    }
}
