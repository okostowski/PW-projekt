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
        Settings settings = new Settings();
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
                settings.DAOName = "DAOMock";
            else
                settings.DAOName = "DAOMock2";
            settings.Save();
            loadDatabase();
        }

        private void loadDatabase()
        {
            Assembly a = Assembly.UnsafeLoadFrom(@"C:\Users\Oskar\Desktop\pw\PW-projekt\"+settings.DAOName+".dll");
            Type t = a.GetType("Kostowski.TeaCatalog."+ settings.DAOName+".DAO");
            ConstructorInfo constructorInfo = t.GetConstructor(new Type[] {  });            var o = constructorInfo.Invoke(new object[] {  });
            DAO = (IDAO) o;
        }

        public DataProvider()
        {
            loadDatabase();
        }
    }
}
