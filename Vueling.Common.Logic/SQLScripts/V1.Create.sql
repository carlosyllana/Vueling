-- Ejemplo de creación Base de Datos y una Tabla
USE master
-- GO es un comando no una sentencia.
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'VuelingDB'
)
CREATE DATABASE VuelingDB
ON PRIMARY(
    name=VuelingDB_data,
	filename='C:\CursoSqlServer2017\Data\VuelingDB.mdf',
	size=6MB,
	maxsize=15MB,
	filegrowth=1MB)
	LOG ON(
	name=gescom_log,
	filename='C:\CursoSqlServer2017\Data\VuelingDB_log.ldf',
	size=2MB,
	maxsize=2MB,
	filegrowth=0MB
	)
	COLLATE modern_spanish_ci_as
GO
-- Abrir Base de Datos Vueling DB
USE VuelingDB  
-- Crear nueva Tabla llamada 'Alumnos' con Chema 'dbo'
-- La tabla si existe la borramos
IF OBJECT_ID('dbo.Alumnos', 'U') IS NOT NULL
DROP TABLE dbo.Alumnos
GO
-- Creamos la Tabla
CREATE TABLE dbo.Alumnos
(
   Id  				INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, -- Clave Primaria
   Guid             UNIQUEIDENTIFIER, 
   Nombre     		[NVARCHAR](50)  NOT NULL,
   Apellidos   		[NVARCHAR](50)  NOT NULL,
   Dni         		[NVARCHAR](50)  NOT NULL,
   FechaNacimiento  [DATETIME] NOT NULL, 
   Edad				INT NOT NULL,
   FechaCreacion	[NVARCHAR](50)  NOT NULL
);
GO
-- Visualizamos todos los registros de la Tabla  'Alumnos'
SELECT * FROM dbo.Alumnos;
