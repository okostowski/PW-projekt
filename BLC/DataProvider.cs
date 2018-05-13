using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        
        private void loadDatabase(String path)
        {
            Assembly a = Assembly.UnsafeLoadFrom(path+".dll");
            Type t = null;
            foreach (Type t1 in a.GetTypes())
            {
                if (t1.GetInterfaces().Contains<Type>(typeof(IDAO)))
                {
                    t = t1;
                    break;
                }
            }
            ConstructorInfo constructorInfo = t.GetConstructor(new Type[] {  });
            var o = constructorInfo.Invoke(new object[] {  });
            DAO = (IDAO) o;
        }

        public DataProvider(String path)
        {
            loadDatabase(path);
        }
    }
}
