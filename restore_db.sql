USE [IngDeSoftDB]
GO

-- Add DigVerH column to Usuarios if not exists
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Usuarios' AND COLUMN_NAME = 'DigVerH')
BEGIN
    ALTER TABLE Usuarios ADD DigVerH VARCHAR(500) NULL;
END
GO


-- 1. Create Componentes Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Componentes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Componentes](
        [id_Componente] [int] IDENTITY(1,1) NOT NULL,
        [nombre] [varchar](100) NOT NULL,
        [tipo] [varchar](50) NOT NULL,
     CONSTRAINT [PK_Componentes] PRIMARY KEY CLUSTERED ([id_Componente] ASC)
    ) ON [PRIMARY]
END
GO

-- 2. Create Componente_Relacion Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Componente_Relacion]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Componente_Relacion](
        [id_Padre] [int] NOT NULL,
        [id_Hijo] [int] NOT NULL,
     CONSTRAINT [PK_Componente_Relacion] PRIMARY KEY CLUSTERED ([id_Padre] ASC, [id_Hijo] ASC),
     CONSTRAINT [FK_Relacion_Padre] FOREIGN KEY([id_Padre]) REFERENCES [dbo].[Componentes] ([id_Componente]),
     CONSTRAINT [FK_Relacion_Hijo] FOREIGN KEY([id_Hijo]) REFERENCES [dbo].[Componentes] ([id_Componente])
    ) ON [PRIMARY]
END
GO

-- 3. Create Usuario_Componente Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_Componente]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Usuario_Componente](
        [id_Usuario] [int] NOT NULL,
        [id_Componente] [int] NOT NULL,
     CONSTRAINT [PK_Usuario_Componente] PRIMARY KEY CLUSTERED ([id_Usuario] ASC, [id_Componente] ASC),
     CONSTRAINT [FK_UsuarioComp_Usuario] FOREIGN KEY([id_Usuario]) REFERENCES [dbo].[Usuarios] ([id_Usuario]) ON DELETE CASCADE,
     CONSTRAINT [FK_UsuarioComp_Componente] FOREIGN KEY([id_Componente]) REFERENCES [dbo].[Componentes] ([id_Componente]) ON DELETE CASCADE
    ) ON [PRIMARY]
END
GO

-- Recreate Stored Procedures

IF OBJECT_ID('dbo.SP_InsertarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_InsertarBitacora
GO
CREATE PROCEDURE [dbo].[SP_InsertarBitacora]
	@ID_Usuario INT,
	@Username VARCHAR(255),
    @Actividad VARCHAR(255),
    @Detalle VARCHAR(255),
	@FechaHora DATETIME
AS
BEGIN
    INSERT INTO Bitacora (id_Usuario, username, actividad, detalle, fechaHora) 
    VALUES (@ID_Usuario, @Username, @Actividad, @Detalle, @FechaHora);
END
GO

IF OBJECT_ID('dbo.SP_InsertarUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_InsertarUsuario
GO
CREATE PROCEDURE [dbo].[SP_InsertarUsuario]
    @Nombre VARCHAR(50),
    @Password VARCHAR(255),
	@Role VARCHAR(50),
	@DigVerH VARCHAR(500)
AS
BEGIN
    INSERT INTO Usuarios (nombre, password, role, DigVerH) 
    VALUES (@Nombre, @Password, @Role, @DigVerH);
END
GO

IF OBJECT_ID('dbo.SP_LimpiarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarBitacora
GO
CREATE PROCEDURE [dbo].[SP_LimpiarBitacora]
AS 
DELETE FROM bitacora
GO

IF OBJECT_ID('dbo.SP_ListarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarBitacora
GO
CREATE PROC [dbo].[SP_ListarBitacora]
AS
BEGIN
    SELECT * FROM Bitacora
END
GO

IF OBJECT_ID('dbo.SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LoginUsuario
GO
CREATE PROCEDURE [dbo].[SP_LoginUsuario]
    @Nombre VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; 
    SELECT 
        id_Usuario, 
        nombre, 
        password,
		role,
		DigVerH
    FROM 
        Usuarios
    WHERE 
        nombre = @Nombre;
END
GO

IF OBJECT_ID('dbo.SP_GuardarComponente', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarComponente
GO
CREATE PROCEDURE [dbo].[SP_GuardarComponente]
    @Nombre VARCHAR(100),
    @Tipo VARCHAR(50),
    @ID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @ID = id_Componente FROM Componentes WHERE nombre = @Nombre;
    IF @ID IS NULL
    BEGIN
        INSERT INTO Componentes (nombre, tipo) VALUES (@Nombre, @Tipo);
        SET @ID = SCOPE_IDENTITY();
    END
END
GO

IF OBJECT_ID('dbo.SP_GuardarRelacion', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarRelacion
GO
CREATE PROCEDURE [dbo].[SP_GuardarRelacion]
    @ID_Padre INT,
    @ID_Hijo INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Componente_Relacion WHERE id_Padre = @ID_Padre AND id_Hijo = @ID_Hijo)
    BEGIN
        INSERT INTO Componente_Relacion (id_Padre, id_Hijo) VALUES (@ID_Padre, @ID_Hijo);
    END
END
GO

IF OBJECT_ID('dbo.SP_LimpiarRelacionesComponente', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarRelacionesComponente
GO
CREATE PROCEDURE [dbo].[SP_LimpiarRelacionesComponente]
    @ID_Padre INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Componente_Relacion WHERE id_Padre = @ID_Padre;
END
GO

IF OBJECT_ID('dbo.SP_ListarComponentes', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarComponentes
GO
CREATE PROCEDURE [dbo].[SP_ListarComponentes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Componente, nombre, tipo FROM Componentes;
END
GO

IF OBJECT_ID('dbo.SP_ListarRelaciones', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarRelaciones
GO
CREATE PROCEDURE [dbo].[SP_ListarRelaciones]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Padre, id_Hijo FROM Componente_Relacion;
END
GO

IF OBJECT_ID('dbo.SP_ListarPermisosUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarPermisosUsuario
GO
CREATE PROCEDURE [dbo].[SP_ListarPermisosUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Componente FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario;
END
GO

IF OBJECT_ID('dbo.SP_GuardarUsuarioPermiso', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarUsuarioPermiso
GO
CREATE PROCEDURE [dbo].[SP_GuardarUsuarioPermiso]
    @ID_Usuario INT,
    @ID_Componente INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario AND id_Componente = @ID_Componente)
    BEGIN
        INSERT INTO Usuario_Componente (id_Usuario, id_Componente) VALUES (@ID_Usuario, @ID_Componente);
    END
END
GO

IF OBJECT_ID('dbo.SP_QuitarUsuarioPermiso', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_QuitarUsuarioPermiso
GO
CREATE PROCEDURE [dbo].[SP_QuitarUsuarioPermiso]
    @ID_Usuario INT,
    @ID_Componente INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario AND id_Componente = @ID_Componente;
END
GO

IF OBJECT_ID('dbo.SP_ListarUsuarios', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarUsuarios
GO
CREATE PROCEDURE [dbo].[SP_ListarUsuarios]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Usuario, nombre, password, role, DigVerH FROM Usuarios;
END
GO

IF OBJECT_ID('dbo.SP_LimpiarUsuarioPermisos', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarUsuarioPermisos
GO
CREATE PROCEDURE [dbo].[SP_LimpiarUsuarioPermisos]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario;
END
GO

-- ============================================
-- Digito Verificador - Tabla y Stored Procedures
-- ============================================

-- Create IntegridadDigVefV Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IntegridadDigVefV]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[IntegridadDigVefV](
        [id_Tabla] [int] IDENTITY(1,1) NOT NULL,
        [nombreTabla] [varchar](100) NOT NULL,
        [hashVertical] [varchar](500) NOT NULL,
     CONSTRAINT [PK_IntegridadDigVefV] PRIMARY KEY CLUSTERED ([id_Tabla] ASC)
    ) ON [PRIMARY]
END
GO


IF OBJECT_ID('dbo.SP_ActualizarDigVerH', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ActualizarDigVerH
GO
CREATE PROCEDURE [dbo].[SP_ActualizarDigVerH]
    @ID_Usuario INT,
    @DigVerH VARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuarios SET DigVerH = @DigVerH WHERE id_Usuario = @ID_Usuario;
END
GO

IF OBJECT_ID('dbo.SP_ObtenerDigVerH', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ObtenerDigVerH
GO
CREATE PROCEDURE [dbo].[SP_ObtenerDigVerH]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Usuario, nombre, password, role, DigVerH FROM Usuarios WHERE id_Usuario = @ID_Usuario;
END
GO

IF OBJECT_ID('dbo.SP_ActualizarDigVerV', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ActualizarDigVerV
GO
CREATE PROCEDURE [dbo].[SP_ActualizarDigVerV]
    @NombreTabla VARCHAR(100),
    @HashVertical VARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM IntegridadDigVefV WHERE nombreTabla = @NombreTabla)
    BEGIN
        UPDATE IntegridadDigVefV SET hashVertical = @HashVertical WHERE nombreTabla = @NombreTabla;
    END
    ELSE
    BEGIN
        INSERT INTO IntegridadDigVefV (nombreTabla, hashVertical) VALUES (@NombreTabla, @HashVertical);
    END
END
GO

IF OBJECT_ID('dbo.SP_ObtenerDigVerV', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ObtenerDigVerV
GO
CREATE PROCEDURE [dbo].[SP_ObtenerDigVerV]
    @NombreTabla VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Tabla, nombreTabla, hashVertical FROM IntegridadDigVefV WHERE nombreTabla = @NombreTabla;
END
GO
