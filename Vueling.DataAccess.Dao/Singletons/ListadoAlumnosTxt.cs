using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.Common.Logic
{
    public sealed class ListadoAlumnosTxt
    {

        private static ListadoAlumnosTxt instance = null;
        private static List<Alumno> alumnoList = new List<Alumno>();
        private static readonly object padlock = new object();

        private ListadoAlumnosTxt()
        {

            DAOTxt<Alumno> daoTxt = new DAOTxt<Alumno>();
            alumnoList = daoTxt.SelectAll();
        }

        public List<Alumno> GetList()
        {
            return alumnoList;
        }
        public static ListadoAlumnosTxt Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new ListadoAlumnosTxt();
                        return instance;
                    }
                }
                return instance;
            }

        }

        public static List<Alumno> AlumnoList { get => alumnoList; set => alumnoList = value; }
    }

}
