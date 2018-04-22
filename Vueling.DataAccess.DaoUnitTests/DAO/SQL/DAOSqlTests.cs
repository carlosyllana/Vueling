using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.Dao.DAO.Tests
{
    [TestClass()]
    public class DAOSqlTests
    {

        private MockFactory _mockFactory;
        private Mock<ICrudDAO<Student>> _crudDao;

        [TestInitialize]
        public void Init()
        {

        }
        [TestMethod()]
        public void DAOSqlTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}