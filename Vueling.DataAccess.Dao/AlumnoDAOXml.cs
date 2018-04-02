using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDAOXml : IAlumnoDAO
    {
        public String PATH;
        public AlumnoDAOXml()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.XML);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }

        public Alumno Add(Alumno alumno)
        {
            List<Alumno> alumnosList = GetList();
            XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));

            if (alumnosList == null)
            {
                alumnosList = new List<Alumno>();
            }

            using (FileStream fs1 = new FileStream(@PATH, FileMode.Create))
            {
                alumnosList.Add(alumno);
                xSeriz.Serialize(fs1, alumnosList);
            }

            return (Select(alumno.Guid));
        }



        public List<Alumno> GetList()
        {
            List<Alumno> alumnosList =null;
            XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
            using (StreamReader r = new StreamReader(@PATH))
            {
                String xml = r.ReadToEnd();
                if (xml==String.Empty){
                    alumnosList = new List<Alumno>();
                }
                else
                {
                    StringReader stringReader = new StringReader(xml);
                    alumnosList = (List<Alumno>)xSeriz.Deserialize(stringReader);
                }
                
            }
            return alumnosList;
        }

        public Alumno Select(Guid guid)
        {
            Alumno alumnoEncontrado = null;
            List<Alumno> alumnosList = GetList();
             foreach (var item in alumnosList)
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
