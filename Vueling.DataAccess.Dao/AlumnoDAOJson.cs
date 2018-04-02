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
    public class AlumnoDAOJson : IAlumnoDAO
    {

        private String PATH;

        public AlumnoDAOJson()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.JSON);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }


        public Alumno Add(Alumno alumno)
        {
            List<Alumno> alumnosList = GetList();
            if (alumnosList == null)
            {
                alumnosList = new List<Alumno>();
            }

            using (StreamWriter file = new StreamWriter(@PATH))
            {

                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                alumnosList.Add(alumno);
                serializer.Serialize(file, alumnosList);
            }

            return Select(alumno.Guid);
        }

        public List<Alumno> GetList()
        {
            List<Alumno> alumnosList = new List<Alumno>();
            string json = File.ReadAllText(@PATH);
            if (json.Equals(String.Empty))
            {
                alumnosList = new List<Alumno>();
            }
            else
            {
                alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(json);

            }

            return alumnosList;
        }

        public Alumno Select(Guid guid)
        {
            List<Alumno> alumnosList = null;
            string json = File.ReadAllText(@PATH);
            Alumno alumnoEncontrado = null;
            alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(json);
            foreach( var item in alumnosList)
            {

                if (item.Guid.Equals(guid))
                {
                    alumnoEncontrado = item;
                    continue;
                }
            }



            return alumnoEncontrado;
        }
    }
}
