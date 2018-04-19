using System;
using System.Collections.Generic;
using System.Data.Linq;

using System.Linq;

using Vueling.Business.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public class DAOSQLlinq<T> : ICrud<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;
        private DataContext _db;
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

        public T Insert(T entity)
        {
            try
            {
                GetTable().InsertOnSubmit(entity);
                _db.SubmitChanges();
                return SelectById(Convert.ToInt32(entity.GetType().GetProperty("id").GetValue(entity, null)));
            }
            finally
            {
                _db.Dispose();
            }
        }

        public T SelectById(int id)
        {
            try
            {
              // GetTable().OfType<T>().Single(c => (int)c.GetType().GetProperty("Id").GetValue(c) == id);

                var query = from item in GetAll()
                            where Convert.ToInt32(item.GetType().GetProperty("id").GetValue(item, null)) == id
                            select item;
                return query.Single();
            }
            finally
            {
                _db.Dispose();
            }

        }


        public List<T> SelectAll()
        {
            try
            {
                var query = from item in GetAll()
                            select item;
                return query.ToList();

            }
            finally
            {
                _db.Dispose();
            }
        }

        int IDelete<T>.Delete(T entity)
        {
            try
            {
                var inicio = GetAll().Count();
                GetTable().DeleteOnSubmit(entity);
                _db.SubmitChanges();
                var final = GetAll().Count();
                return inicio - final;

            }
            finally
            {
                _db.Dispose();
            }
        }

        public T Update(T entity)
        {

            var entityToModify = from item in GetAll()
                        where item.GetType().GetProperty("Id") == entity.GetType().GetProperty("Id")
                        select item;
 

            
            foreach (var property in entityToModify.GetType().GetProperties())
            {
                property.SetValue(entityToModify, entity.GetType().GetProperty(property.Name).GetValue(entity, null));
            }
            _db.SubmitChanges();
            return SelectById(Convert.ToInt32(entity.GetType().GetProperty("Id")));
        }
    }
}