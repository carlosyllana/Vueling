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
    public class DocumentXml<T> : IDocument<T> where T: VuelingObject
    {
        public String PATH;

        public DocumentXml()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.XML);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }

        public T Add(T entity)
        {
            //XmlDocument
            List<T> entityList = GetList();
            XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));

            if (entityList == null)
            {
                entityList = new List<T>();
            }

            using (FileStream fs1 = new FileStream(@PATH, FileMode.Create))
            {
                entityList.Add(entity);
                xSeriz.Serialize(fs1, entityList);
            }

            return (Select(entity.Guid));
        }



        public List<T> GetList()
        {
            List<T> entityList =null;
            XmlSerializer xSeriz = new XmlSerializer(typeof(List<T>));
            using (StreamReader r = new StreamReader(@PATH))
            {
                String xml = r.ReadToEnd();
                if (xml==String.Empty){
                    entityList = new List<T>();
                }
                else
                {
                    StringReader stringReader = new StringReader(xml);
                    entityList = (List<T>)xSeriz.Deserialize(stringReader);
                }
                
            }
            return entityList;
        }

        public T Select(Guid guid)
        {
            T entityFound = null;
            List<T> entityList = GetList();
             foreach (var item in entityList)
            {

                if (item.Guid.Equals(guid))
                {
                    entityFound = item;
                    continue;
                }
            }


            return entityFound;
        }
    }
}
