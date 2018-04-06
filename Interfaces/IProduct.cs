using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Core;

namespace Kostowski.TeaCatalog.Interfaces
{
    public interface IProduct
    {
        IProducer Producer { get; set; }
        string Name { get; set; }
        Color Color { get; set; }
    }
}
