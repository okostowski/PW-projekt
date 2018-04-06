using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kostowski.TeaCatalog.Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        int Founded { get; set; }
    }
}
