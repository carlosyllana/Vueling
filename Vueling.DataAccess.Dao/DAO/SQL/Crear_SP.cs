using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.Dao.Properties;

namespace Vueling.DataAccess.Dao.DAO.SQL
{
    public partial class Crear_SP : DbMigration
    {
        public override void Up()
        {
            /* CreateStoredProcedure(
                 "dbo.InsertAlumno",
                  p => new
                  {
                      Guid = p.Guid(),
                      Id = p.Int(),
                      Nombre = p.String(),
                      Apellido = p.String(),
                      Dni = p.String(),
                      FechaNacimiento = p.DateTime(),
                      Edad = p.Int(),
                      FechaRegistro = p.DateTime()
                  },
                 body:
                     @"INSERT [dbo].[Alumno]([Guid], [Id], [Nombre], [Apellido], [Dni], [FechaNacimiento], [Edad], [FechaRegistro])  
                     VALUES (@Guid, @Id, @Nombre, @Apellido, @Dni, @FechaNacimiento, @Edad, @FechaRegistro) "
                  );

            /* CreateStoredProcedure(
                 "dbo.UpdateAlumno",
                 p => new
                 {
                     Guid = p.Guid(),
                     Id = p.Int(),
                     Nombre = p.String(),
                     Apellido = p.String(),
                     Dni = p.String(),
                     FechaNacimiento = p.DateTime(),
                     Edad = p.Int(),
                     FechaRegistro = p.DateTime()
                 },
                 body:
                     @"UPDATE [dbo].[EmployeeMasters]  
             SET [Code] = @Code, [Name] = @Name, [DepartmentId] = @DepartmentId  
             WHERE ([Guid] = @Guid)"
             );*/

            /* CreateStoredProcedure(
                 "dbo.DeleteEmployee",
                 p => new
                 {
                     EmployeeId = p.Int(),
                 },
                 body:
                     @"DELETE [dbo].[EmployeeMasters]  
             WHERE ([EmployeeId] = @EmployeeId)"
             );*/

            /* CreateStoredProcedure(
                "dbo.SelectAll",
                p => new
                {
                    EmployeeId = p.Int(),
                },
                body:
                    @"DELETE [dbo].[Alumnos]  
             WHERE ([Guid] = @Guid)"
            );

            CreateStoredProcedure(
                "dbo.SelectByGuid",
                p => new
                {
                    Guid = p.Guid(),
                },
                body:
                    @"SELECT t0.[Guid]  
                 FROM [dbo].[Alumnos] AS t0  
                 WHERE @@ROWCOUNT > 0 AND t0.[Guid] = @Guid"
            );*/
            Sql(ResourceSQL.InsertAlumno);
        }

        public override void Down()
        {
            //DropStoredProcedure("dbo.DeleteEmployee");
            //DropStoredProcedure("dbo.UpdateEmployee");
            DropStoredProcedure("dbo.insertonAlumnos");
            //DropStoredProcedure("dbo.SelectAll");
            //DropStoredProcedure("dbo.SelectByGuid");
        }
    }
}
