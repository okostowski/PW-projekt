using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.DAOMock
{
    public class DAO : IDAO
    {
        private List<IProducer> producersList;
        private List<IProduct> teaList;

        public DAO()
        {
            producersList = new List<IProducer>
            {
                new Producer {Name="Lipton", Founded=1890},
                new Producer {Name="Tetley", Founded=1837},
                new Producer {Name="Dilmah", Founded=1988}
            };
            teaList = new List<IProduct>
            {
                new Tea {Producer=producersList[0], Name="Yellow Label Tea", Color=Core.Color.Black},
                new Tea {Producer=producersList[1], Name="Tetley Pure Green Tea", Color=Core.Color.Green},
                new Tea {Producer=producersList[2], Name="Dilmah Lemon", Color=Core.Color.Black}
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
