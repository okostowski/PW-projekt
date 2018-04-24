using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.BLC.Properties;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.BLC
{
    public class DataProvider
    {
        private Settings _settings = new Settings();
        public IDAO DAO { get; set; }
        public IEnumerable<IProduct> TeaList
        {
            get { return DAO.GetAllTea(); }
        }
        public IEnumerable<IProducer> ProducersList
        {
            get { return DAO.GetAllProducers(); }
        }

        public void switchDAO(int nb)
        {
            if (nb == 1)
                _settings.DAOName = "DAOMock";
            else
                _settings.DAOName = "DAOMock2";
            _settings.Save();
            loadDatabase();
        }
        
        private void loadDatabase()
        {
            Assembly a = Assembly.UnsafeLoadFrom(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString()).ToString() +"/"+_settings.DAOName+".dll");
            Type t = a.GetType("Kostowski.TeaCatalog."+ _settings.DAOName+".DAO");
            ConstructorInfo constructorInfo = t.GetConstructor(new Type[] {  });
            var o = constructorInfo.Invoke(new object[] {  });
            DAO = (IDAO) o;
        }

        public DataProvider()
        {
            loadDatabase();
        }
    }
}
