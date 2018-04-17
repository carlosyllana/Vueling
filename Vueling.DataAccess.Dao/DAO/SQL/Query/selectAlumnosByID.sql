IF ( OBJECT_ID('dbo.selectAlumnosByID') IS NOT NULL ) 
   DROP PROCEDURE dbo.selectAlumnosByID
GO

CREATE PROCEDURE dbo.selectAlumnosByID
       @Guid   uniqueidentifier        
AS
BEGIN 
     SET NOCOUNT ON 

     SELECT 
           Guid,
			Id,
			Nombre,
			Apellido,
			Dni,
			FechaNacimiento,
			Edad,
			FechaRegistro        
     FROM   dbo.Alumnos (NOLOCK) 
     WHERE  
            Guid = @Guid

END 

GO