using Newtonsoft.Json;
using Serilog;
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
            try
            {

                Log.Debug("Inicio JSON Add ->" +entity.ToString());

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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error ->"+  entity.ToString());
                return null;
            }
            finally
            {
           
                Log.Information("Fin de JSON ADD");            
            }

        }

        public List<T> GetList()
        {

            try
            {

                Log.Information("Inicio JSON GetList");
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error GetList");
                return null;
            }
            finally
            {
                Log.Debug("Fin de JSON GetList");
            }
        }

        public T Select(Guid guid)
        {
            T entityFound = null;
            try
            {

                Log.Debug("Inicio JSON Select Guid->" +guid.ToString());
                List<T> entityList = null;
                string json = File.ReadAllText(@PATH);
              
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error GetList");
                return entityFound;
            }
            finally
            {

                Log.Debug("Fin de JSON GetList");
            }
        }
    }
    
}
