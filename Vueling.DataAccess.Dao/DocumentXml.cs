using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public class DocumentXml<T> : IDocument<T> where T: VuelingObject
    {

        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public String PATH;

        public DocumentXml()
        {
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.XML);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }

        public T Add(T entity)
        {
            try
            {
                _log.Debug("Error 4Net");
                Log.Debug("Inicio XML Add ->" + entity.ToString());
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error ADD XML");
                return null;
            }
            finally
            {
                Log.Debug("Fin de XML ADD");
            }
        }



        public List<T> GetList()
        {
            try
            {

                Log.Debug("Inicio XML GetList");
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error GetList XML");
                return null;
            }
            finally
            {

                Log.Debug("Fin de XML GetList");

            }
        }

        public T Select(Guid guid)
        {
            try
            {

                Log.Debug("Inicio XML Select ->"+ guid.ToString());
                T entityFound = null;
                List<T> entityList = GetList();
                 foreach (var item in entityList)
                {

                    if (item.Guid.Equals(guid))
                    {
                        entityFound = item;
                        break;
                    }
                }


                return entityFound;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error Select XML");
                return null;
            }
            finally
            {

                Log.Debug("Fin de XML Select");

            }
        }
    }
}
