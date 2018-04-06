using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kostowski.TeaCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProduct> GetAllTea();
        IEnumerable<IProducer> GetAllProducers();
    }
}
