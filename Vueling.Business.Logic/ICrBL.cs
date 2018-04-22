using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao.DAO;

namespace Vueling.Business.Logic
{
    public interface ICrBL<T>: ICreateBL<T>, IReadDoc<T> where T : VuelingObject
    {

    }
}
