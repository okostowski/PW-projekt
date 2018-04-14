using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;
using Kostowski.TeaCatalog.Core;

namespace Kostowski.TeaCatalog.DAOMock2
{
    class Tea : IProduct
    {
        public IProducer Producer { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
