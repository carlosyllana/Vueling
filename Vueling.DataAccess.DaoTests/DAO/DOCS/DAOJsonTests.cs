using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class DAOJsonTests
    {
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);

        [TestInitialize]
        public void TestInit()
        {
            _log.Info("Inicialiazamos Tests");
            _log.Debug("Limpiamos de ficheros existentes");
            DocumentsManager docMan = new DocumentsManager(TipoFichero.JSON);
            String filename = docMan.GetPath();
            if (File.Exists(filename)) File.Delete(filename);
            _log.Debug("Obtenemos el alumno DAO con el formato actual.");
            iAlumnoDao = new AlumnoDao<Alumno>(DAOFactory<Alumno>.getFormat());
        }



        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectTest()
        {
            Assert.Fail();
        }
    }
}