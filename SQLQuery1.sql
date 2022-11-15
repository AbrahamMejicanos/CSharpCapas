use master
go

create database DB_BasePruebas
go

use DB_BasePruebas
go

create schema SCH_GENERAL
go

CREATE TABLE SCH_GENERAL.TBL_USUARIOS(
	IDTUX TINYINT IDENTITY(1,1) PRIMARY KEY, -- ID USUARIO TABLA USUARIO
	NUTUX VARCHAR(15) NOT NULL, -- NOMBRE USUARIO TABLA USUARIO
	PATUX VARCHAR(15) NOT NULL, -- PRIMER APELLITO TABLA USUARIO
	SATUX VARCHAR(15) NULL, -- SEGUNDO APELLIDO TABLA USUARIO
	FNTUX SMALLDATETIME NOT NULL, -- FECHA NACIMIENTO TABLA USUARIO
	ETUXX BIT NOT NULL -- ESTADO TABLA USUARIO
)
GO

CREATE PROCEDURE [SCH_GENERAL].[SP_Usuario_Index]
AS
BEGIN

	SELECT 
		IDTUX,
		NUTUX,
		PATUX,
		SATUX,
		FNTUX,
		ETUXX
	FROM [SCH_GENERAL].[TBL_USUARIOS]

END
GO

CREATE PROCEDURE [SCH_GENERAL].[SP_Usuario_Create]
(
	@NUTUX VARCHAR(15),
	@PATUX VARCHAR(15),
	@SATUX VARCHAR(15),
	@FNTUX SMALLDATETIME,
	@ETUXX BIT
)
AS
BEGIN
	INSERT INTO [SCH_GENERAL].[TBL_USUARIOS]
	(
		NUTUX,
		PATUX,
		SATUX,
		FNTUX,
		ETUXX
	) VALUES (
		@NUTUX,
		@PATUX,
		@SATUX,
		@FNTUX,
		@ETUXX
	)
	SELECT SCOPE_IDENTITY()
END
GO


CREATE PROCEDURE [SCH_GENERAL].[SP_Usuario_Read]
(
	@IDTUX TINYINT
)
AS
BEGIN

	SELECT 
		IDTUX,
		NUTUX,
		PATUX,
		SATUX,
		FNTUX,
		ETUXX
	FROM [SCH_GENERAL].[TBL_USUARIOS]
	WHERE IDTUX = @IDTUX

END
GO

CREATE PROCEDURE [SCH_GENERAL].[SP_Usuario_Update]
(
	@IDTUX TINYINT,
	@NUTUX VARCHAR(15),
	@PATUX VARCHAR(15),
	@SATUX VARCHAR(15),
	@FNTUX SMALLDATETIME,
	@ETUXX BIT
)
AS
BEGIN
	UPDATE [SCH_GENERAL].[TBL_USUARIOS]
	SET 
		NUTUX = @NUTUX,
		PATUX = @PATUX,
		SATUX = @SATUX,
		FNTUX = @FNTUX,
		ETUXX = @ETUXX
END
GO

CREATE PROCEDURE [SCH_GENERAL].[SP_Usuario_Delete]
(
	@IDTUX TINYINT
)
AS
BEGIN
	DELETE FROM [SCH_GENERAL].[TBL_USUARIOS]
	WHERE IDTUX = @IDTUX
END
GO