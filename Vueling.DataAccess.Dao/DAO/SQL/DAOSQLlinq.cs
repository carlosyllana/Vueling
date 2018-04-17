using System;
using System.Collections.Generic;
using System.Data.Linq;

using System.Linq;

using Vueling.Business.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public class DAOSQLlinq<T> : IDAO<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;
        private  DataContext _db;
        private readonly ConfigManager configManager = null;

        public DAOSQLlinq()
        {
            
            configManager = new ConfigManager();
        }

        protected virtual ITable GetTable()
        {
            _db = new DataContext(configManager.GetStringConnexion());
            return _db.GetTable<T>();
        }

        protected virtual IQueryable<T> GetAll()
        {
            _db = new DataContext(configManager.GetStringConnexion());
            return GetTable().AsQueryable().OfType<T>();
        }

        public T Add(T entity)
        {
            try
            {
                GetTable().InsertOnSubmit(entity);
                _db.SubmitChanges();
                return Select(entity.Guid);
            }finally
            {
                _db.Dispose();
            }
        }

        public T Select(Guid guid)
        {
            try
            {
                var query = from item in GetAll()
                            where item.Guid == guid
                            select item;
                return query.Single();
            }
            finally
            {
                _db.Dispose();
            }

        }


        public List<T> GetList()
        {
            try { 
                var query = from item in GetAll()
                            select item;
                return query.ToList();

            }
            finally
            {
                _db.Dispose();
            }
}

        public void Delete (T entity)
        {
            try { 
                GetTable().DeleteOnSubmit(entity);
                _db.SubmitChanges();
             }
            finally
            {
                _db.Dispose();
            }
}
       
    }
}