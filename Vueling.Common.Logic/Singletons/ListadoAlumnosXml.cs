using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Common.Logic
{
    public sealed class ListadoAlumnosXml
    {

        private static ListadoAlumnosXml instance =null;
        private static List<Alumno> alumnoList = new List<Alumno>();

        private ListadoAlumnosXml(){}

        public static ListadoAlumnosXml Instance{
            get
            {
                lock (alumnoList)
                {
                    if (instance == null)
                        instance = new ListadoAlumnosXml();
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
