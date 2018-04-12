using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public class SqlFormat<T> : IDAO<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;



        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetList()
        {
            throw new NotImplementedException();
        }

        public T Select(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}