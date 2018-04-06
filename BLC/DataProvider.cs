using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.BLC
{
    public class DataProvider
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IProduct> TeaList
        {
            get { return DAO.GetAllTea(); }
        }
        public IEnumerable<IProducer> ProducersList
        {
            get { return DAO.GetAllProducers(); }
        }

        public DataProvider()
        {
            DAO = (IDAO)new Kostowski.TeaCatalog.DAOMock.DAO();
        }
    }
}
