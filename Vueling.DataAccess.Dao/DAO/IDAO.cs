using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao

{
    public interface IDAO<T> where T : VuelingObject
    {
        T Add(T entity);
        T Select(Guid guid);
        List<T> GetList();    
    }
}
