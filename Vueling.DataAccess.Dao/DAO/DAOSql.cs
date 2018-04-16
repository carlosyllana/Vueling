using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao.DAO.SQL;

namespace Vueling.DataAccess.Dao.DAO
{
    public class DAOSql<T> : IDAO<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;
        private DataContext _db;
        private ConfigManager configManager = null;

        public DAOSql()
        {
            configManager = new ConfigManager();
            _db = new DataContext(configManager.GetStringConnexion());
            //_db = new DataContext("‪C:\\CursoSqlServer2017\\Data\\VuelingDB.mdf");
            _db.DeferredLoadingEnabled = false;
        }

        public virtual ITable GetTable()
        {
            return _db.GetTable<T>();
        }

        public T Add(T entity)
        {
            GetTable().InsertOnSubmit(entity);
            _db.SubmitChanges(); 
            return Select(entity.Guid); ;

        }

        public T Select(Guid guid)
        {
            IQueryable<T> list = _db.GetTable<Alumno>().OfType<T>();
            var query = from item in list
                        where item.Guid == guid
                        select item;
            return query.Single();
        }


        public List<T> GetList()
        {

            IQueryable<T> list = _db.GetTable<T>();
            var query = from item in list
                              select item;
            return query.ToList();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _db.GetTable<T>();
        }
        

       
    }
}