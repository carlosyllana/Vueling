﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public static class DAOFactory<T> where T : VuelingObject
    {
        public static IDAO<T> getFormat()
        {
            var confManager = new ConfigManager();



            switch (confManager.GetActualFormat())
            {
                case TipoFichero.TXT:
                    return new DAOTxt<T>();
                case TipoFichero.JSON:
                    return new DAOJson<T>();
                case TipoFichero.XML:
                    return new DAOXml<T>();
                default:
                    return null;
            }
        }

    }
}
