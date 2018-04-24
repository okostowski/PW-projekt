using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.DAOMock
{
    public class Producer : IProducer
    {
        public string Name { get; set; }
        public int Founded { get; set; }
    }
}
