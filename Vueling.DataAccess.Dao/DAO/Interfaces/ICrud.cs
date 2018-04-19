using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao.DAO;

namespace Vueling.DataAccess.Dao

{
    public interface ICrud<T>: ICreate<T>, IReadSQL<T>, IUpdate<T>, IDelete<T> where T : VuelingObject
    {

    }
}
