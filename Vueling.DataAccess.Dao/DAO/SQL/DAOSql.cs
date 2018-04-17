using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public class DAOSql<T> : IDAO<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;
        private  DataContext _db;
        private readonly ConfigManager configManager = null;

        public DAOSql()
        {
            
            configManager = new ConfigManager();
        }


        public T Add(T entity)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(configManager.GetStringConnexion()))
                {
                    //query.Append("INSERT INTO dbo.Alumnos (");
                    var strInsert = new StringBuilder();
                    var strValues = new StringBuilder();
                     strInsert.Append(" INSERT INTO dbo.Alumnos(");
                     strValues.Append( " VALUES (");
                    foreach (var property in entity.GetType().GetProperties())
                    {
                        if (property.Name != "Id") {
                            strInsert.Append(property.Name);
                            strInsert.Append(!typeof(T).GetProperties().Last().Equals(property) ? "," : ")");
                            strValues.Append(String.Concat("@", property.Name));
                            strValues.Append(!typeof(T).GetProperties().Last().Equals(property) ? "," : ")");
                        }
                    }

                    strInsert.Append(strValues.ToString());

                        using (SqlCommand cmd = new SqlCommand(strInsert.ToString(), _connection))
                        {
                            _connection.Open();
                            cmd.CommandType = CommandType.Text;
                        foreach (var property in entity.GetType().GetProperties())
                        {
                            if (property.Name != "Id")
                                cmd.Parameters.AddWithValue(String.Concat("@", property.Name), property.GetValue(entity, null));
                        }
                        cmd.ExecuteNonQuery();
                            _connection.Close();
                        }
                    
                    return Select(entity.Guid);
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T Select(Guid guid)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(configManager.GetStringConnexion()))
                {
                    T entity = default(T);
                    var query = new StringBuilder();
                    query.Append("Select * from dbo.Alumnos where dbo.Alumnos.Guid ='");
                    query.Append(guid.ToString());
                    query.Append("';");

                    using (var _command = new SqlCommand(query.ToString(), _connection))
                    {
                        _connection.Open();
                        var reader = _command.ExecuteReader();
                        while (reader.Read())
                        {
                            var properties = new object[typeof(T).GetProperties().Length];
                            for (int i = 0; i < properties.Length; i++)
                            {
                                properties[i] = reader.GetValue(i);
                            }
                            entity = (T)Activator.CreateInstance(typeof(T), properties);

                        }
                    }
                    return entity;
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }

        }


        public List<T> GetList()
        {
            {
                try
                {
                    using (SqlConnection _connection = new SqlConnection(configManager.GetStringConnexion()))
                    {
                        var results = new List<T>();
                        _connection.Open();
                        var queryString = "Select * from dbo.Alumnos";
                        using (var _command = new SqlCommand(queryString, _connection))
                        {
                            var reader = _command.ExecuteReader();
                            while (reader.Read())
                            {
                                var properties = new object[typeof(T).GetProperties().Length];
                                for (int i = 0; i < properties.Length; i++)
                                {
                                    properties[i] = reader.GetValue(i);
                                }
                                var entity = Activator.CreateInstance(typeof(T), properties);
                                results.Add((T)entity);
                            }
                        }
                        return results;
                    }
                }
                catch (SqlException ex)
                {
                    _log.Error(ex);
                    throw;
                }
            }
        }
    }
}