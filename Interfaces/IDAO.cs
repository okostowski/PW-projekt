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

        IProducer AddNewProducer();
        IProduct AddNewProduct();

        void SaveProduct(IProduct p);
        void SaveProducer(IProducer p);

        void DeleteProduct(IProduct p);
        void DeleteProducer(IProducer p);
    }
}
