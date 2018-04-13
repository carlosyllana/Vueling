using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.Dao.DAO.SQL
{
    public class Conexion
    {

        public Conexion()
        {
        }
        public string GetConex()
        {
            string strConex = ConfigurationManager.ConnectionStrings["DemoCapas"].ConnectionString;
            if (object.ReferenceEquals(strConex, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strConex;
            }
        }
        
    }
}
