﻿using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums;

namespace Vueling.Business.Logic
{
    public class AlumnoBl : ICrudBl<Alumno> 
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name+ " -> " + alumno.ToString());
                Log.Debug("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + alumno.ToString());
                //Calcular Campos
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();
                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat(GetActualFormat());

                IAlumnoDao iAlumnoDao = new AlumnoDao(doc);

                //Añadir.
                return iAlumnoDao.Add(alumno);


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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }

        public void Formater(Enums.TipoFichero tipoFichero)
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name );
                Log.Debug("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var value = (int)tipoFichero;
                config.AppSettings.Settings["tipoFichero"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch(ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en AppSettings-- > " + ex);
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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name); 
            }
        }

        public Enums.TipoFichero GetActualFormat()
        {
            try
            {
                Log.Debug("Inicio AlumnoBl GetActualFormat");
                //Obtener Formato.
                ConfigurationManager.RefreshSection("appSettings");
                var tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoFichero"]);
                return (Enums.TipoFichero)tipo;
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en AppSettings-- > " + ex);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer  en AppSettings--> " + ex);
                Log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer en AppSettings-- > " + ex);
                throw;
            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name); 
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
                Log.Debug("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }

        public List<Alumno> getList()
        {

            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Debug("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);

                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat(GetActualFormat());
                IAlumnoDao iAlumnoDao = new AlumnoDao(doc);

                //Añadir.
                return iAlumnoDao.getList();



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
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Log.Information("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }

        }
    }
}
