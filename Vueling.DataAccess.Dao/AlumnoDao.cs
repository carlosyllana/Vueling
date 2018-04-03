using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    class AlumnoDao : IAlumnoDao
    {

        private IDocument<Alumno> _doc;
        public AlumnoDao(IDocument<Alumno> doc)
        {
            _doc = doc;
        }

        public Alumno Add(Alumno alumno)
        {
            _doc.Add(alumno);
            return _doc.Select(alumno.Guid);
        }
    }
}
