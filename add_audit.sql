USE [IngDeSoftDB]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_Cambios]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Usuario_Cambios](
        [id_Cambio] [int] IDENTITY(1,1) NOT NULL,
        [id_Usuario] [int] NOT NULL,
        [version] [int] NOT NULL,
        [nombre] [varchar](50) NOT NULL,
        [password] [varchar](255) NOT NULL,
        [role] [varchar](50) NOT NULL,
        [fecha] [datetime] NOT NULL,
        [modificado_por] [varchar](50) NOT NULL,
        [tipo_cambio] [varchar](50) NOT NULL,
        CONSTRAINT [PK_Usuario_Cambios] PRIMARY KEY CLUSTERED ([id_Cambio] ASC)
    ) ON [PRIMARY]
END
GO

-- SP_InsertarCambioUsuario
IF OBJECT_ID('dbo.SP_InsertarCambioUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_InsertarCambioUsuario
GO
CREATE PROCEDURE [dbo].[SP_InsertarCambioUsuario]
    @ID_Usuario INT,
    @Version INT,
    @Nombre VARCHAR(50),
    @Password VARCHAR(255),
    @Role VARCHAR(50),
    @Fecha DATETIME,
    @ModificadoPor VARCHAR(50),
    @TipoCambio VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Usuario_Cambios (id_Usuario, [version], nombre, [password], [role], fecha, modificado_por, tipo_cambio)
    VALUES (@ID_Usuario, @Version, @Nombre, @Password, @Role, @Fecha, @ModificadoPor, @TipoCambio);
END
GO

-- SP_ListarCambiosUsuario
IF OBJECT_ID('dbo.SP_ListarCambiosUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ListarCambiosUsuario
GO
CREATE PROCEDURE [dbo].[SP_ListarCambiosUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Cambio, id_Usuario, [version], nombre, [password], [role], fecha, modificado_por, tipo_cambio
    FROM Usuario_Cambios
    WHERE id_Usuario = @ID_Usuario
    ORDER BY [version] DESC;
END
GO

-- SP_ActualizarUsuario
IF OBJECT_ID('dbo.SP_ActualizarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ActualizarUsuario
GO
CREATE PROCEDURE [dbo].[SP_ActualizarUsuario]
    @ID_Usuario INT,
    @Nombre VARCHAR(50),
    @Password VARCHAR(255),
    @Role VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuarios
    SET nombre = @Nombre,
        [password] = @Password,
        [role] = @Role
    WHERE id_Usuario = @ID_Usuario;
END
GO

-- SP_ObtenerUltimaVersionUsuario
IF OBJECT_ID('dbo.SP_ObtenerUltimaVersionUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ObtenerUltimaVersionUsuario
GO
CREATE PROCEDURE [dbo].[SP_ObtenerUltimaVersionUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX([version]), 0) AS UltimaVersion
    FROM Usuario_Cambios
    WHERE id_Usuario = @ID_Usuario;
END
GO
