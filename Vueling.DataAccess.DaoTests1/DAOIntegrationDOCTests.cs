using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Business.Logic;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class DAOIntegrationDOCTests
    {

        ConfigManager configManager = null;

        [TestInitialize]
        public void InitTest()
        {
            configManager = new ConfigManager();
        
        }

        [TestCleanup]
        public void CleanTest()
        {

        }

        public static IEnumerable<object[]> DatosAlumno()
        {
            yield return new object[] { new Alumno(Guid.NewGuid(), 1, "carlos", "Yllana", "1111111", new DateTime(1994, 1, 24), 24, DateTime.Now) };
            yield return new object[] { new Alumno(Guid.NewGuid(), 2, "rosario", "gales", "22222222", new DateTime(2000, 12, 3), 17, DateTime.Now) };
            yield return new object[] { new Alumno(Guid.NewGuid(), 3, "Usuario", "Pruebas", "33333333C", new DateTime(2015, 4, 4), 3, DateTime.Now) };
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestDAOTXT(Alumno alumno)
        {
            configManager.Formater(TipoFichero.TXT);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt= doc.Insert(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestDAOJSON(Alumno alumno)
        {

            configManager.Formater(TipoFichero.JSON);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Insert(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestDAOXML(Alumno alumno)
        {
            configManager.Formater(TipoFichero.XML);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Insert(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }
    }
}