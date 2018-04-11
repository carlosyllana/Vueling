using log4net;
using log4net.Repository.Hierarchy;
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
    public class DAOTxt<T> : IDAO<T> where T: VuelingObject
    {
        private readonly IVuelingLogger _log= null;
        private String PATH;
        public DAOTxt()
        {
           
            DocumentsManager docManager = new DocumentsManager(Enums.TipoFichero.TXT);
            docManager.LoadDocument();
            this.PATH = DocumentsManager.PATH;
            _log = new AdpSerilog();
        }

        public T Add(T entity)
        {
            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                using (var tw = new StreamWriter(@PATH, true))
                {
                    tw.WriteLine(entity.ToString());
                }
                //throw new IOException();
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
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<T> GetList()
        {
            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        public T Select(Guid guid)
        {

            try
            {

                _log.Info("Inicio TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _log.Info("Fin de TXT " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
    }
}
