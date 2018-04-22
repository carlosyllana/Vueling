using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;
using Vueling.DataAccess.Dao.DAO.SQL;
using static Vueling.Common.Logic.TipoFichero;

namespace Vueling.Business.Logic
{
    public class GenericBL : ICrBL<Alumno> 
    {
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
        private ConfigManager confManager = null;

        public GenericBL() {
            confManager = new ConfigManager();
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                _log.Fatal("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name+ " -> " + alumno.ToString());
                //Calcular Campos
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();
                IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
                return doc.Insert(alumno);


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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public DateTime CalcularFechaRegistro()
        {
            return DateTime.Now.Date;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                DateTime now = DateTime.Today.Date;
                return Convert.ToInt32((now - fechaNacimiento).TotalDays / 365);

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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<Alumno> getList()
        {

            try
            {
                switch (confManager.GetActualFormat())
                {
                    case TipoFichero.TXT:
                        return ListadoAlumnosTxt.Instance.GetList();
                    case TipoFichero.JSON:
                        return ListadoAlumnosJson.Instance.GetList();
                    case TipoFichero.XML:
                        return ListadoAlumnosXml.Instance.GetList();
                    case TipoFichero.SQL:
                        IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
                        return doc.SelectAll();
                    default:
                        return new List<Alumno>();
                }



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
