using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO.SQL
{
    public static class SQLFactory<T> where T : VuelingObject
    {
        public static IDAO<T> getFormat()
        {
            var confManager = new ConfigManager();

            switch (confManager.GetActualSQLFormat())
            {
                case TipoSQL.LINQ:
                    return new DAOSQLlinq<T>();
                case TipoSQL.SQL:
                    return new DAOSql<T>();
                case TipoSQL.SP:
                    return new DAOSP<T>();
                default:
                    return null;
            }
        }

    }
}
