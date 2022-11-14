use master
go

create database DB_BasePruebas
go

use DB_BasePruebas
go

create schema SCH_GENERAL
go

create table SCH_GENERAL.TBL_USUARIOS(
	IUTUX TINYINT IDENTITY(1,1) PRIMARY KEY, -- ID USUARIO TABLA USUARIO
	NUTUX VARCHAR(15) NOT NULL, -- NOMBRE USUARIO TABLA USUARIO
	PATUX VARCHAR(15) NOT NULL, -- PRIMER APELLITO TABLA USUARIO
	SATUX VARCHAR(15) NULL, -- SEGUNDO APELLIDO TABLA USUARIO
	FNTUX SMALLDATETIME NOT NULL, -- FECHA NACIMIENTO TABLA USUARIO
	ETUXX BIT NOT NULL -- ESTADO TABLA USUARIO
)
go