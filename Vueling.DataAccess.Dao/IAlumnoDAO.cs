using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao

{
    public interface IAlumnoDAO
    {
        Alumno Add(Alumno alumno);
        Alumno Select(Guid guid);
        List<Alumno> GetList();
    }
}
