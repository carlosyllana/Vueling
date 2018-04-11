using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public static class DAOFactory<T> where T : VuelingObject
    {
        public static IDAO<T> getFormat(Enums.TipoFichero dataType)
        {
            switch (dataType)
            {
                case Enums.TipoFichero.TXT:
                    return new DAOTxt<T>();
                case Enums.TipoFichero.JSON:
                    return new DAOJson<T>();
                case Enums.TipoFichero.XML:
                    return new DAOXml<T>();
                default:
                    return null;
            }
        }

    }
}
