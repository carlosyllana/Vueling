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
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.Dao
{
    public class DocumentXml<T> : IDocument<T> where T: VuelingObject
    {

        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public String PATH;
        private SendMail mailer;


        public DocumentXml()
        {
            mailer = new SendMail();
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.XML);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
        }

        public IVuelingLogger Log => _log;

        public T Add(T entity)
        {
            try
            {
                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (FileNotFoundException ex)
            {
                //mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        public List<T> GetList()
        {
            try
            {

                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (FileNotFoundException ex)
            {
                //mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }

        public T Select(Guid guid)
        {
            try
            {

                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (FileNotFoundException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                //mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
