using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO
{
    public class DAOSP<T> : ICrud<T> where T : VuelingObject
    {
        private readonly IVuelingLogger _log = null;
        private  DataContext _db;
        private readonly ConfigManager configManager = null;

        public DAOSP()
        {
            
            configManager = new ConfigManager();
        }


        public T Insert(T entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configManager.GetStringConnexion()))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        var id = String.Empty;
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "insertonAlumnos";
                        foreach (var property in entity.GetType().GetProperties())
                        {
                            if (property.Name != "Id")
                                command.Parameters.AddWithValue(String.Concat("@", property.Name), property.GetValue(entity, null));
                            
                        }
                        connection.Open();
                         command.ExecuteNonQuery();
                        
                        return SelectById((int) entity.GetType().GetProperty("Id").GetValue(entity));
                       
                    }
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }
        public T SelectById(int id)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(configManager.GetStringConnexion()))
                {
                    T entity = default(T);
                    using (SqlCommand command = new SqlCommand())
                    {
                       
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "selectAlumnosByID";

                         command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        var reader = command.ExecuteReader();
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


        public List<T> SelectAll()
        {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(configManager.GetStringConnexion()))
                    {
                        var results = new List<T>();
                        T entity = default(T);
                        using (SqlCommand command = new SqlCommand())
                        {

                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "selectAllAlumnos";

                            connection.Open();
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                var properties = new object[typeof(T).GetProperties().Length];
                                for (int i = 0; i < properties.Length; i++)
                                {
                                    properties[i] = reader.GetValue(i);
                                }
                                entity = (T)Activator.CreateInstance(typeof(T), properties);
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

        public T Update(T entity)
        {

            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        int IDelete<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}