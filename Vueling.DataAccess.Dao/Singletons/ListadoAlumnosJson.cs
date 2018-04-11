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

        private ListadoAlumnosJson() {

            DAOJson<Alumno> daoJson = new DAOJson<Alumno>();
            AddList(daoJson.GetList());
        }

        public static ListadoAlumnosJson Instance
        {
            get
            {
                lock (alumnoList)
                {
                    if (instance == null)
                        instance = new ListadoAlumnosJson();
                    return instance;
                }
            }

        }

        public void AddAlumno(Alumno alumno)
        {
            alumnoList.Add(alumno);
        }
        public void AddList(List<Alumno> listAl)
        {
            foreach (var item in listAl)
            {
                alumnoList.Add(item);
            }
        }

        public bool ContainsAlumno(Alumno alumno)
        {
            return alumnoList.Contains(alumno);
        }

        public List<Alumno> GetListValues()
        {
            return alumnoList;
        }

    }
}
