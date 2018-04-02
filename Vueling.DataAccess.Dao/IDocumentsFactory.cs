using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public interface IDocumentsFactory
    {
        void WriteTxtFile(Alumno nuevoAlumno);
        void WriteJsonFile(Alumno nuevoAlumno);
        void WriteXmlFile(Alumno nuevoAlumno);
        List<Alumno> ReaderTxtFile();
        List<Alumno> ReaderJsonFile();
        List<Alumno> ReaderXmlFile();
    }
}
