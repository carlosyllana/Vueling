using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.Dao
{
    public class DAOJson<T> : IDAO<T> where T: VuelingObject
    {

        private String PATH;
        private readonly IVuelingLogger _log = null;
        private SendMail mailer;

        public DAOJson()
        {
            mailer = new SendMail();
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.JSON);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
            _log = new AdpSerilog();
        }


        public T Add(T entity)
        {
            try
            {

                _log.Info("Inicio JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);

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
            catch (ArgumentNullException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
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
                _log.Info("Fin de JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        public List<T> GetList()
        {

            try
            {
                _log.Info("Inicio JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (ArgumentNullException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
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
                _log.Info("Fin de JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public T Select(Guid guid)
        {
            T entityFound = null;
            try
            {

                _log.Info("Inicio JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (ArgumentNullException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
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
                _log.Info("Fin de JSON " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
    
}
