using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Serilog;
using Vueling.Common.Logic.Log;
using System.Reflection;
using Vueling.DataAccess.Dao;

namespace Vueling.Common.Logic
{
    public sealed class ListadoAlumnosXml
    {

        private static ListadoAlumnosXml instance =null;
        private static List<Alumno> alumnoList = new List<Alumno>();
        private static readonly object padlock = new object();
        private ListadoAlumnosXml(){

            DAOXml<Alumno> daoXml = new DAOXml<Alumno>();
            alumnoList = daoXml.GetList();
        }

        public List<Alumno> GetList()
        {
            return alumnoList;
        }

        public static ListadoAlumnosXml Instance{
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new ListadoAlumnosXml();
                        return instance;
                    }
                }
                return instance;
            }

        }
     }
}
