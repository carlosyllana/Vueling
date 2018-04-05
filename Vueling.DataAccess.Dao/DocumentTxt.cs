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
    public class DocumentTxt<T> : IDocument<T> where T: VuelingObject
    {

        private String PATH;
        public DocumentTxt()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.TXT);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;

        }

        public T Add(T entity)
        {
            try
            {

                Log.Debug("Inicio Txt Add ->"+ entity.ToString());
                    using (var tw = new StreamWriter(@PATH, true))
                {
                    tw.WriteLine(entity.ToString());
                }
               
                return Select(entity.Guid);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error Add " + entity.ToString());
                return null;
            }
            finally
            {
                Log.Debug("Fin TXT Add");
            }
        }

        public List<T> GetList()
        {
            try
            {

                Log.Debug("Inicio Txt GuetList");
                string line;
                List<T> entityList = new List<T>();
                using (StreamReader file = new StreamReader(@PATH))
                {
                while ((line = file.ReadLine()) != null)
                 {
                    String[] entityString = line.Split(',');
                    var entity = Activator.CreateInstance(typeof(T), entityString);
                    entityList.Add((T)entity);
                 }

                file.Close();
                }


                return entityList;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error GuetList ");
                return null;
            }
            finally
            {

                Log.Debug("Fin de TXT GuetList");
            }
            
        }

        public T Select(Guid guid)
        {

            try
            {

                Log.Debug("Inicio Txt Select Guid->" + guid.ToString());
                var line = String.Empty;
                Guid actualGuid;
                var entityString = new String[] { };
                var entityFound = String.Empty;
                var encontrado = false;
                using (StreamReader file = new StreamReader(@PATH))
                {
                    while (!encontrado && ((line = file.ReadLine()) != null))
                    {
                        entityString = line.Split(',');
                        actualGuid = new Guid(entityString[0]);
                        Log.Debug("Guid While Item->" + actualGuid.ToString());
                        if (actualGuid.Equals(guid))
                        { 
                            entityFound = line;
                            encontrado = true;
                            continue;
                        }
                    }

                    file.Close();
                }
                var propValues = entityFound.Split(',');
                var entity = Activator.CreateInstance(typeof(T), propValues);
                return (T)entity;

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error Select ");
                return null;
            }
            finally
            {

                Log.Debug("Fin de TXT Select");

            }
                
        }
    }
}
