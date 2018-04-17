using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.DAO.SQL
{
    public class EntitiesContext<T> :DbContext where T : VuelingObject
    {
        public EntitiesContext() : base("name=Entities")
        {

        }

        public DbSet<T> Alumnos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>()
                .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertAlumno", "dbo"))
                                                .Insert(u => u.HasName("SelectAll", "dbo"))
                                                //.Delete(u => u.HasName("DeleteEmployee", "dbo"))
                );
        }

    }
}
