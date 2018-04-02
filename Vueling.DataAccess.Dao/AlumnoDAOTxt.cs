using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDAOTxt : IAlumnoDAO
    {

        private String PATH;
        public AlumnoDAOTxt()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.TXT);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;

        }

        public Alumno Add(Alumno alumno)
        {
            using (var tw = new StreamWriter(@PATH, true))
            {
                tw.WriteLine(alumno.ToString());
            }

            return Select(alumno.Guid);

        }

        public List<Alumno> GetList()
        {

                string line;
                List<Alumno> alumnosList = new List<Alumno>();
                using (StreamReader file = new StreamReader(@PATH))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        String[] alumneString = line.Split(',');
                        Alumno nuevoAlumno =  new Alumno(new Guid(alumneString[0]), Int32.Parse(alumneString[1]), alumneString[2], alumneString[3], alumneString[4], DateTime.Parse(alumneString[5]));
                    alumnosList.Add(nuevoAlumno);
                    }

                    file.Close();
                }


                return alumnosList;
            
        }

        public Alumno Select(Guid guid)
        {
            string line;
            Guid actualGuid;
            Alumno alumnoEncontrado = null;
            using (StreamReader file = new StreamReader(@PATH))
            {
                while (alumnoEncontrado == null && ((line = file.ReadLine()) != null))
                {
                    String[] alumneString = line.Split(',');
                    actualGuid = new Guid(alumneString[0]);
                    if (actualGuid.Equals(guid))
                    {
                        alumnoEncontrado = new Alumno(actualGuid, Int32.Parse(alumneString[1]), alumneString[2], alumneString[3], alumneString[4], DateTime.Parse(alumneString[5]));
                        continue;
                    }
                }

                file.Close();
            }

            return alumnoEncontrado;

        }
    }
}
