using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.Common.Logic
{
     public sealed class ListadoAlumnosJson
    {

        private static ListadoAlumnosJson instance = null;
        private static List<Alumno> alumnoList = new List<Alumno>();
        private static readonly object padlock = new object();

        private ListadoAlumnosJson() {

            DAOJson<Alumno> daoJson = new DAOJson<Alumno>();
            alumnoList = daoJson.SelectAll();
        }

        public List<Alumno> GetList()
        {
            return alumnoList;
        }

        public static ListadoAlumnosJson Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new ListadoAlumnosJson();
                        return instance;
                    }
                }
                return instance;
            }

        }

    }
}
