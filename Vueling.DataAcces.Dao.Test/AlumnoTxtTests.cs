using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.DataAcces.Dao.Test
{

    [TestClass()]
    class AlumnoTxtTests
    {
        private IAlumnoDao iAlumnoDao;

        [TestInitialize]
        public void TestInit()
        {
            DocumentsManager docMan = new DocumentsManager(Enums.TipoFichero.TXT);
            String filename = docMan.GetPath(); if (File.Exists(filename )) File.Delete(filename);
            iAlumnoDao = new AlumnoDao(DocumentFactory<Alumno>.getFormat((Enums.TipoFichero.TXT)));
        }


        [DataRow("1", "cyllana", "gales", "99887766w", "10-01-2018", "23", "1-1-2017")]
        [DataTestMethod]
        public void AddTest(string id, string name, string apellidos, string dni, string fechaNac, string edad, string registro)
        {

            Alumno alumno = new Alumno(Guid.NewGuid().ToString(),id, name, apellidos, dni, fechaNac, edad, registro);
            var alumnoObt = iAlumnoDao.Add(alumno);
            Assert.IsTrue(alumno.Equals(alumnoObt));
        }

    }
}
