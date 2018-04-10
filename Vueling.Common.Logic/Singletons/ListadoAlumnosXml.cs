using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Serilog;
using Vueling.Common.Logic.Log;
using System.Reflection;

namespace Vueling.Common.Logic
{
    public sealed class ListadoAlumnosXml
    {

        private static ListadoAlumnosXml instance =null;
        private static List<Alumno> alumnoList = new List<Alumno>();
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
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
            try
            {
                _log.Debug("Inicio AddList ListadoAlumnosXml");
                foreach (var item in listAl)
                {
                    alumnoList.Add(item);
                }
            }
            catch(NullReferenceException e)
            {
                _log.Debug("Lista Vacia AddList ERROR:" + e);
                throw;
            }
            finally
            {
                _log.Debug("Fin AddList ListadoAlumnosXml");
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
