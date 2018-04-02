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

        private  IAlumnoDAO _alumnoDao;
      

  

        public Alumno Add(Alumno alumno)
        {
            DateTime hoy = DateTime.Today;
            alumno.Edad = hoy.AddTicks(-alumno.FechaNacimiento.Ticks).Year - 1;
            alumno.FechaRegistro = hoy;

            ConfigurationManager.RefreshSection("appSettings");
            int tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoFichero"]);

    
            switch ((TipoFichero)tipo)
            {
                case TipoFichero.TXT:
                    _alumnoDao = new AlumnoDAOTxt();
                    _alumnoDao.Add(alumno);
                    break;
                case TipoFichero.JSON:
                    _alumnoDao = new AlumnoDAOJson();
                    _alumnoDao.Add(alumno);
                    break;
                case TipoFichero.XML:
                    _alumnoDao = new AlumnoDAOXml();
                    _alumnoDao.Add(alumno);
                    break;
            }

       
            return alumno;
        }

        public void Formater(Enums.TipoFichero tipo)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var value = (int)tipo;
            config.AppSettings.Settings["tipoFichero"].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
