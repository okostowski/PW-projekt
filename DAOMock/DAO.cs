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
        private List<IProducer> _producersList;
        private List<IProduct> _teaList;

        public DAO()
        {
            _producersList = new List<IProducer>
            {
                new Producer {Name="Lipton", Founded=1890},
                new Producer {Name="Tetley", Founded=1837},
                new Producer {Name="Dilmah", Founded=1988}
            };
            _teaList = new List<IProduct>
            {
                new Tea {Producer=_producersList[0], Name="Yellow Label Tea", Color=Core.Color.Black},
                new Tea {Producer=_producersList[1], Name="Tetley Pure Green Tea", Color=Core.Color.Green},
                new Tea {Producer=_producersList[2], Name="Dilmah Lemon", Color=Core.Color.Black}
            };
        }

        public IEnumerable<IProduct> GetAllTea()
        {
            return _teaList;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producersList;
        }

        public IProducer AddNewProducer()
        {
            Producer p = new Producer();
            p.Founded = 0;
            p.Name = "";
            return (IProducer)p;
        }

        public IProduct AddNewProduct()
        {
            Tea t = new Tea();
            t.Name = "";
            return (IProduct)t;
        }

        public void SaveProduct(IProduct p)
        {
            if(!_teaList.Contains(p))
                _teaList.Add(p);
        }

        public void SaveProducer(IProducer p)
        {
            if(!_producersList.Contains(p))
                _producersList.Add(p);
        }

        public void DeleteProduct(IProduct p)
        {
            if(_teaList.Contains(p))
                _teaList.Remove(p);
        }

        public void DeleteProducer(IProducer p)
        {
            if(_producersList.Contains(p))
                _producersList.Remove(p);
        }
    }
}
