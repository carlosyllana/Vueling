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
    public class DocumentJson<T> : IDocument<T> where T: VuelingObject
    {

        private String PATH;

        public DocumentJson()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.JSON);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }


        public T Add(T entity)
        {
            List<T> entityList = GetList();
            if (entityList == null)
            {
                entityList = new List<T>();
            }

            using (StreamWriter file = new StreamWriter(@PATH))
            {

                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                entityList.Add(entity);
                serializer.Serialize(file, entityList);
            }

            return Select(entity.Guid);
        }

        public List<T> GetList()
        {
            List<T> entityList;
            string json = File.ReadAllText(@PATH);
            if (String.IsNullOrEmpty(json))
            {
                entityList = new List<T>();
            }
            else
            {
                entityList = JsonConvert.DeserializeObject<List<T>>(json);

            }

            return entityList;
        }

        public T Select(Guid guid)
        {
            List<T> entityList = null;
            string json = File.ReadAllText(@PATH);
            T entityFound = null;
            entityList = JsonConvert.DeserializeObject<List<T>>(json);
            foreach( var item in entityList)
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
