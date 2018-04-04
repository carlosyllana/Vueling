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

                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();

                ConfigurationManager.RefreshSection("appSettings");
                int tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoFichero"]);

                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat((Enums.TipoFichero)tipo);

                return doc.Add(alumno);


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

        public void Formater(Enums.TipoFichero tipo)
        {
            try
            {

                Log.Debug("Inicio AlumnoBl Formatear a ->" + tipo.ToString());
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var value = (int)tipo;
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

        public DateTime CalcularFechaRegistro()
        {
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            try
            {

                Log.Debug("Inicio AlumnoBl Calculad Edad");
                DateTime now = DateTime.Today;
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
    }
}
