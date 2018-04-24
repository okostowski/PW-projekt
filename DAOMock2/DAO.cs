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
        private List<IProducer> _producersList;
        private List<IProduct> _teasList;

        public DAO()
        {
            _producersList = new List<IProducer>
            {
                new Producer {Name="Producer1", Founded=1831},
                new Producer {Name="Producer2", Founded=2002},
                new Producer {Name="Producer3", Founded=3001}
            };
            _teasList = new List<IProduct>
            {
                new Tea {Producer=_producersList[0], Name="Tea1", Color=Core.Color.Black},
                new Tea {Producer=_producersList[1], Name="Tea2", Color=Core.Color.Green},
                new Tea {Producer=_producersList[2], Name="Tea3", Color=Core.Color.Red}
            };
        }

        public IEnumerable<IProduct> GetAllTea()
        {
            return _teasList;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producersList;
        }
    }
}
