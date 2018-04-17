USE [VuelingDB]
GO
/****** Object:  StoredProcedure [dbo].[selectAllAlumnos]    Script Date: 17/04/2018 23:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[selectAllAlumnos]
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

END 
