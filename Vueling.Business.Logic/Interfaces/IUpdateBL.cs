using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public interface IUpdateBL<T> where T:VuelingObject
    {
        T Update(T entity);
    }
}
