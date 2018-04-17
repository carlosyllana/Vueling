using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao

{
    public interface ICRUD<T> where T : VuelingObject
    {
        T Create(T entity);
        T Read(Guid guid);
        void Update(Guid guid);
        T Delete(Guid guid);
        List<T> GetList();    
    }
}
