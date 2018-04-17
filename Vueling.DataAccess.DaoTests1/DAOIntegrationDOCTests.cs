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
        [TestInitialize]
        public void InitTest()
        {
            DocumentsManager docManager = new DocumentsManager(TipoFichero.TXT);
            if (File.Exists(docManager.GetPath())) File.Delete(docManager.GetPath());
            docManager.tipo = TipoFichero.JSON;
            if (File.Exists(docManager.GetPath())) File.Delete(docManager.GetPath());
            docManager.tipo = TipoFichero.XML;
            if (File.Exists(docManager.GetPath())) File.Delete(docManager.GetPath());

        }

        [TestCleanup]
        public void CleanTest()
        {
            DocumentsManager docManager = new DocumentsManager(TipoFichero.TXT);
            File.Delete(docManager.GetPath());
            docManager.tipo = TipoFichero.JSON;
            File.Delete(docManager.GetPath());
            docManager.tipo = TipoFichero.XML;
            File.Delete(docManager.GetPath());
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
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.TXT);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt= doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestDAOJSON(Alumno alumno)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.SQL);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestDAOXML(Alumno alumno)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.XML);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }
    }
}