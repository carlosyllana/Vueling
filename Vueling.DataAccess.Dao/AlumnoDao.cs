using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDao : IAlumnoDao
    {

        private IDocument<Alumno> iDoc;

        public AlumnoDao()
        {
        }

        public AlumnoDao(IDocument<Alumno> doc)
        {
            iDoc = doc;
        }

        public Alumno Add(Alumno alumno)
        {
            return iDoc.Add(alumno); 
        }

        public List<Alumno> getList()
        {
            return iDoc.GetList();
        }

        public Alumno Select(Guid guid)
        {
            return iDoc.Select(guid);
        }
    }
}
