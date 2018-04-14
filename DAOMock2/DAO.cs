using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.DAOMock2
{
    public class DAO : IDAO
    {
        private List<IProducer> producersList;
        private List<IProduct> teaList;

        public DAO()
        {
            producersList = new List<IProducer>
            {
                new Producer {Name="Producer1", Founded=1831},
                new Producer {Name="Producer2", Founded=2002},
                new Producer {Name="Producer3", Founded=3001}
            };
            teaList = new List<IProduct>
            {
                new Tea {Producer=producersList[0], Name="Tea1", Color=Core.Color.Black},
                new Tea {Producer=producersList[1], Name="Tea2", Color=Core.Color.Green},
                new Tea {Producer=producersList[2], Name="Tea3", Color=Core.Color.Red}
            };
        }

        public IEnumerable<IProduct> GetAllTea()
        {
            return teaList;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producersList;
        }
    }
}
