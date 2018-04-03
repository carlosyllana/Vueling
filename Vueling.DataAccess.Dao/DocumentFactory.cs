using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public static class DocumentFactory<T> where T : VuelingObject
    {
        public static IDocument<T> getFormat(Enums.TipoFichero dataType)
        {
            switch (dataType)
            {
                case Enums.TipoFichero.TXT:
                    return new DocumentTxt<T>();
                case Enums.TipoFichero.JSON:
                    return new DocumentJson<T>();
                case Enums.TipoFichero.XML:
                    return new DocumentJson<T>();
                default:
                    return null;
            }
        }

    }
}
