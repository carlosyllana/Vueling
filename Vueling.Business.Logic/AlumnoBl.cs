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
    public class AlumnoBl : IAlumnoBL 
    {

        private readonly IAlumnoDao _alumnoDao;




        public Alumno Add(Alumno alumno)
        {
            try
            {

                Log.Information("Starting web host ");

                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaRegistro = CalcularFechaRegistro();

                ConfigurationManager.RefreshSection("appSettings");
                int tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoFichero"]);

                IDocument<Alumno> doc = DocumentFactory<Alumno>.getFormat((Enums.TipoFichero)tipo);

                return doc.Add(alumno);


            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return null;
            }
            finally
            {
                Log.CloseAndFlush();
             
            }


        
        }

        public void Formater(Enums.TipoFichero tipo)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var value = (int)tipo;
            config.AppSettings.Settings["tipoFichero"].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }

        public DateTime CalcularFechaRegistro()
        {
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - fechaNacimiento.Year;
            if (now < fechaNacimiento.AddYears(age))
            {
                --age;
            }
            return age;
        }
    }
}
