 CREATE PROCEDURE [dbo].[insertonAlumnos]
		@Guid		uniqueidentifier = NULL   , 
		@Nombre                       NVARCHAR(50)  = NULL   , 
		@Apellido            NVARCHAR(50)  = NULL,
		@Dni            NVARCHAR(50)  = NULL,  
		@FechaNacimiento           datetime  = NULL  ,
		@Edad            int = NULL  ,
		@FechaRegistro            datetime  = NULL  

AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.Alumnos
          (                    
			Guid,
			Nombre,
			Apellido,
			Dni,
			FechaNacimiento,
			Edad,
			FechaRegistro 
          ) 
     VALUES 
          ( 
            @Guid,
			@Nombre,
			@Apellido,
			@Dni,
			@FechaNacimiento,
			@Edad,
			@FechaRegistro
          ) 

END 

GO