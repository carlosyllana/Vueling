using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO.Interfaces
{
    public interface IGeneric<T>: IDAO<T>, ICrud<T> where T:VuelingObject
    {
    }
}
