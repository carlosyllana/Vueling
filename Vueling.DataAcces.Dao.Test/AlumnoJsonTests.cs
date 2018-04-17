using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.DataAcces.Dao.Test
{
    [TestClass]
    public class AlumnoJsonTests
    {
        private IDAO<Alumno> iAlumnoDao;
       // private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);

        [TestInitialize]    
        public void TestInit()
        {
            //_log.Info("Inicialiazamos Tests");
            //_log.Debug("Limpiamos de ficheros existentes");
            ConfigManager confManager = new ConfigManager();
            confManager.Formater(TipoFichero.JSON);
            DocumentsManager docMan = new DocumentsManager(confManager.GetActualFormat());
            String filename = docMan.GetPath();
            if (File.Exists(filename)) File.Delete(filename);
            //_log.Debug("Obtenemos el alumno DAO con el formato actual.");
            iAlumnoDao = new AlumnoDao<Alumno>(DAOFactory<Alumno>.getFormat());
        }


        [DataRow("1", "cyllana", "gales", "99887766w", "10-01-2018", "23", "1-1-2017")]
        [DataTestMethod]
        public void AddTest(string id, string name, string apellidos, string dni, string fechaNac, string edad, string registro)
        {

            //_log.Debug("AlumnoJsonTests inicio "+ System.Reflection.MethodBase.GetCurrentMethod().Name );
            Alumno alumno = new Alumno(Guid.NewGuid().ToString(), id, name, apellidos, dni, fechaNac, edad, registro);
            var alumnoObt = iAlumnoDao.Add(alumno);
            Assert.IsTrue(alumno.Equals(alumnoObt));
            //_log.Debug("Fin AlumnoJsonTests " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

    }
}
