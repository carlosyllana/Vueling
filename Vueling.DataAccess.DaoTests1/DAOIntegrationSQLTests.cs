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
    public class DAOIntegrationSQLTests
    {

        public void InitTest()
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
        public void TestSQLLinq(Alumno alumno)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.SQL);
            configManager.SetActualSQLFormat(TipoSQL.LINQ);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt= doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestSQLSql(Alumno alumno)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.SQL);
            configManager.SetActualSQLFormat(TipoSQL.SQL);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }

        [DataTestMethod]
        [DynamicData(nameof(DatosAlumno), DynamicDataSourceType.Method)]
        public void TestSQLSP(Alumno alumno)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.Formater(TipoFichero.SQL);
            configManager.SetActualSQLFormat(TipoSQL.SP);
            IDAO<Alumno> doc = DAOFactory<Alumno>.getFormat();
            Alumno alObt = doc.Add(alumno);
            Assert.IsTrue(alumno.Equals(alObt));
        }
    }
}