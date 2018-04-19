using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic.Tests
{
    [TestClass()]
    public class AlumnoBlTests
    {
        private readonly AlumnoBl _alumnoBl = new AlumnoBl();

        public static IEnumerable<object[]> FechasData()
        {
            yield return new object[] { new DateTime(1994, 1, 12), 24 };
            yield return new object[] { new DateTime(1996, 2, 28), 22 };
        }

        [DataTestMethod]
        [DynamicData(nameof(FechasData), DynamicDataSourceType.Method)]
        public void CalcularEdadTest(DateTime nacimiento, int result)
        {
            Assert.IsTrue(_alumnoBl.CalcularEdad(nacimiento) == result);
        }
    }
}