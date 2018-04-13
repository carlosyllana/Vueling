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
using static Vueling.Common.Logic.TipoFichero;

namespace Vueling.Business.Logic
{
    public class AlumnoBl : ICrudBl<Alumno> 
    {
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
        private ConfigManager confManager = null;

        public Alumno Add(Alumno alumno)
        {
            try
            {
                _log.Fatal("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name+ " -> " + alumno.ToString());
                //Calcular Campos
                confManager = new ConfigManager();
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();
                IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
                return doc.Add(alumno);


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
                int age = now.Year - fechaNacimiento.Year;
                if (now <= fechaNacimiento.AddYears(age))
                {
                    --age;
                }
                return age;
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
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);

                IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
                //Añadir.
                var a = doc.GetList();
                return a;



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
