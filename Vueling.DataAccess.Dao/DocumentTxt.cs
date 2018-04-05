using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.Dao
{
    public class DocumentTxt<T> : IDocument<T> where T: VuelingObject
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private SendMail mailer;
        private String PATH;
        public DocumentTxt()
        {
            mailer = new SendMail();
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.TXT);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;

        }

        public T Add(T entity)
        {
            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                using (var tw = new StreamWriter(@PATH, true))
                {
                    tw.WriteLine(entity.ToString());
                }
                return Select(entity.Guid);
            }
            catch (FileNotFoundException ex)
            {     
                mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex); 
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            finally
            {
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                
            }
        }

        public List<T> GetList()
        {
            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (FileNotFoundException ex)
            {
                mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            finally
            {
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        public T Select(Guid guid)
        {

            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                            break;
                        }
                    }

                    file.Close();
                }
                var propValues = entityFound.Split(',');
                var entity = Activator.CreateInstance(typeof(T), propValues);
                return (T)entity;

            }
            catch (FileNotFoundException ex)
            {
                mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);

                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex);
                throw;
            }
            finally
            {
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
    }
}
