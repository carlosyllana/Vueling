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
        public AlumnoDao(IDocument<Alumno> doc)
        {
            iDoc = doc;
        }

        public Alumno Add(Alumno alumno)
        {
            iDoc.Add(alumno);
            return iDoc.Select(alumno.Guid);
        }
    }
}
