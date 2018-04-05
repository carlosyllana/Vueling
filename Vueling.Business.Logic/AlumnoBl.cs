using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums;

namespace Vueling.Business.Logic
{
    public class AlumnoBl : ICrudBl<Alumno> 
    {

        public Alumno Add(Alumno alumno)
        {
            try
            {

                Log.Debug("Inicio AlumnoBl add -> "+ alumno.ToString());
                //Calcular Campos
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();
                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat(GetActualFormat());

                IAlumnoDao iAlumnoDao = new AlumnoDao(doc);

                //Añadir.
                return iAlumnoDao.Add(alumno);


            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error al añadir Alumno" );
                return null;
            }
            finally
            {
                Log.Debug("Fin de Alumno Bl add" );
            }
        }

        public void Formater(Enums.TipoFichero tipoFichero)
        {
            try
            {

                //Log.Debug("Inicio AlumnoBl Formatear a ->" + tipoFichero.ToString());

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var value = (int)tipoFichero;
                config.AppSettings.Settings["tipoFichero"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "AlumnoBl Formatear");               
            }
            finally
            {
                Log.Debug("Fin AlumnoBl Formatear");
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
            catch (Exception ex)
            {
                Log.Fatal(ex, "AlumnoBl Formatear");
                return Enums.TipoFichero.TXT;
            }
            finally
            {
                Log.Debug("Fin AlumnoBl Formatear");
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
                Log.Debug("Inicio AlumnoBl Calculad Edad");
                DateTime now = DateTime.Today.Date;
                int age = now.Year - fechaNacimiento.Year;
                if (now < fechaNacimiento.AddYears(age))
                {
                    --age;
                }
                return age;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "AlumnoBl Calculad Edad");
                return -1;
            }
            finally
            {

                Log.Debug("Fin de AlumnoBl Calculad Edad");

            }
        }

        public List<Alumno> getList()
        {

            try
            {

                Log.Debug("Inicio AlumnoBl getList ");

                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat(GetActualFormat());
                IAlumnoDao iAlumnoDao = new AlumnoDao(doc);

                //Añadir.
                return iAlumnoDao.getList();



            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error  AlumnoBl getList");
                return null;
            }
            finally
            {
                Log.Debug("Fin de  AlumnoBl getList");
            }

        }
    }
}
