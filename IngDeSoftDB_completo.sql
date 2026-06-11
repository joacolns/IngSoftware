-- ===================================================================
-- DATABASE CREATION AND INITIALIZATION SCRIPT FOR IngDeSoftDB
-- ===================================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'IngDeSoftDB')
BEGIN
    ALTER DATABASE IngDeSoftDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE IngDeSoftDB;
END
GO

CREATE DATABASE IngDeSoftDB;
GO

USE IngDeSoftDB;
GO
-- ===================================================================
-- TABLE SCHEMAS
-- ===================================================================

CREATE TABLE [dbo].[Usuarios](
    [id_Usuario] [int] IDENTITY(1,1) NOT NULL,
    [nombre] [varchar](50) NOT NULL,
    [password] [varchar](250) NOT NULL,
    [DigVerH] [varchar](500) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([id_Usuario] ASC)
);
GO

CREATE TABLE [dbo].[Bitacora](
    [id_Bitacora] [int] IDENTITY(1,1) NOT NULL,
    [id_Usuario] [int] NOT NULL,
    [actividad] [varchar](200) NOT NULL,
    [detalle] [varchar](200) NOT NULL,
    [username] [varchar](50) NOT NULL,
    [fechaHora] [datetime] NULL,
    CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED ([id_Bitacora] ASC)
);
GO

CREATE TABLE [dbo].[Componentes](
    [id_Componente] [int] IDENTITY(1,1) NOT NULL,
    [nombre] [varchar](100) NOT NULL,
    [tipo] [varchar](50) NOT NULL,
    CONSTRAINT [PK_Componentes] PRIMARY KEY CLUSTERED ([id_Componente] ASC)
);
GO

CREATE TABLE [dbo].[Componente_Relacion](
    [id_Padre] [int] NOT NULL,
    [id_Hijo] [int] NOT NULL,
    CONSTRAINT [PK_Componente_Relacion] PRIMARY KEY CLUSTERED ([id_Padre] ASC, [id_Hijo] ASC),
    CONSTRAINT [FK_Relacion_Padre] FOREIGN KEY([id_Padre]) REFERENCES [dbo].[Componentes] ([id_Componente]),
    CONSTRAINT [FK_Relacion_Hijo] FOREIGN KEY([id_Hijo]) REFERENCES [dbo].[Componentes] ([id_Componente])
);
GO

CREATE TABLE [dbo].[Usuario_Componente](
    [id_Usuario] [int] NOT NULL,
    [id_Componente] [int] NOT NULL,
    CONSTRAINT [PK_Usuario_Componente] PRIMARY KEY CLUSTERED ([id_Usuario] ASC, [id_Componente] ASC),
    CONSTRAINT [FK_UsuarioComp_Usuario] FOREIGN KEY([id_Usuario]) REFERENCES [dbo].[Usuarios] ([id_Usuario]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsuarioComp_Componente] FOREIGN KEY([id_Componente]) REFERENCES [dbo].[Componentes] ([id_Componente]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[Usuario_Cambios](
    [id_Cambio] [int] IDENTITY(1,1) NOT NULL,
    [id_Usuario] [int] NOT NULL,
    [version] [int] NOT NULL,
    [nombre] [varchar](50) NOT NULL,
    [password] [varchar](250) NOT NULL,
    [fecha] [datetime] NOT NULL,
    [modificado_por] [varchar](50) NOT NULL,
    [tipo_cambio] [varchar](50) NOT NULL,
    CONSTRAINT [PK_Usuario_Cambios] PRIMARY KEY CLUSTERED ([id_Cambio] ASC)
);
GO

CREATE TABLE [dbo].[Idioma](
    [id_Idioma] [int] NOT NULL,
    [Nombre] [varchar](100) NOT NULL,
    [Agregado] [bit] NOT NULL,
    CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED ([id_Idioma] ASC)
);
GO

CREATE TABLE [dbo].[Control](
    [id_Control] [int] NOT NULL,
    [nombre_control] [varchar](100) NOT NULL,
    [form] [varchar](100) NOT NULL,
    CONSTRAINT [PK_Control] PRIMARY KEY CLUSTERED ([id_Control] ASC)
);
GO

CREATE TABLE [dbo].[Traduccion](
    [id_Traduccion] [int] NOT NULL,
    [id_Idioma] [int] NOT NULL,
    [id_Control] [int] NOT NULL,
    [texto] [varchar](500) NOT NULL,
    CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED ([id_Traduccion] ASC),
    CONSTRAINT [FK_Traduccion_Idioma] FOREIGN KEY([id_Idioma]) REFERENCES [dbo].[Idioma] ([id_Idioma]) ON DELETE CASCADE,
    CONSTRAINT [FK_Traduccion_Control] FOREIGN KEY([id_Control]) REFERENCES [dbo].[Control] ([id_Control]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[IntegridadDigVefV](
    [id_Tabla] [int] NOT NULL,
    [nombreTabla] [varchar](100) NOT NULL,
    [hashVertical] [varchar](500) NOT NULL,
    CONSTRAINT [PK_IntegridadDigVefV] PRIMARY KEY CLUSTERED ([id_Tabla] ASC)
);
GO

-- ===================================================================
-- SEED DATA
-- ===================================================================

-- Data for Usuarios
SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([id_Usuario], [nombre], [password], [DigVerH]) VALUES (1, 'admin', '3pQQAVt/op6AR9q4Aju4z8AjVMU1pmo9fg//hv+O97Cs9z7X', '75452c39b9c981fb8f4587cf74d170f315a1709e6eaccba6365bd643c95d1380');
INSERT INTO [Usuarios] ([id_Usuario], [nombre], [password], [DigVerH]) VALUES (2, 'user', 'G/5pk0OyXlYg7BPNn227bwEniH4DD5nPx+3cq1/tKnvM8UcH', 'f076f1e80989c7f084fe1ea1529da68738e65b8bfd010ac8e2d81da1f48fe648');
SET IDENTITY_INSERT [Usuarios] OFF;
GO

-- Data for Componentes
SET IDENTITY_INSERT [Componentes] ON;
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (1, 'Ver Bitacora', 'Hoja');
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (2, 'Limpiar Bitacora', 'Hoja');
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (3, 'Registrar Usuario', 'Hoja');
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (4, 'Gestionar Permisos', 'Hoja');
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (5, 'Rol Admin', 'Composite');
INSERT INTO [Componentes] ([id_Componente], [nombre], [tipo]) VALUES (6, 'Rol Usuario', 'Composite');
SET IDENTITY_INSERT [Componentes] OFF;
GO

-- Data for Componente_Relacion
INSERT INTO [Componente_Relacion] ([id_Padre], [id_Hijo]) VALUES (5, 1);
INSERT INTO [Componente_Relacion] ([id_Padre], [id_Hijo]) VALUES (5, 2);
INSERT INTO [Componente_Relacion] ([id_Padre], [id_Hijo]) VALUES (5, 3);
INSERT INTO [Componente_Relacion] ([id_Padre], [id_Hijo]) VALUES (5, 4);
INSERT INTO [Componente_Relacion] ([id_Padre], [id_Hijo]) VALUES (6, 1);
GO

-- Data for Usuario_Componente
INSERT INTO [Usuario_Componente] ([id_Usuario], [id_Componente]) VALUES (1, 5);
GO

-- Data for Bitacora
SET IDENTITY_INSERT [Bitacora] ON;
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (1, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 14:53:04.140');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (2, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 14:53:16.703');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (3, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 19:33:26.453');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (4, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 19:33:59.803');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (5, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 19:38:38.763');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (6, 1, 'Registro', 'El administrador ha creado un nuevo usuario', 'admin', '2026-06-10 19:39:15.513');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (7, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 19:40:51.090');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (8, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 19:42:12.987');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (9, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 19:43:07.530');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (10, 2, 'Login', 'El usuario ha inicado sesion', 'user', '2026-06-10 19:43:24.460');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (11, 2, 'Logout', 'El administrador ha cerrado sesion', 'user', '2026-06-10 19:43:44.547');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (12, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 19:44:04.277');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (13, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 19:45:03.667');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (14, 2, 'Login', 'El usuario ha inicado sesion', 'user', '2026-06-10 19:45:09.420');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (15, 2, 'Logout', 'El administrador ha cerrado sesion', 'user', '2026-06-10 19:45:13.830');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (16, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 20:24:45.730');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (17, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 20:27:47.803');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (18, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:10:29.937');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (19, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:10:41.773');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (20, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:16:34.390');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (21, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:16:53.597');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (22, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:16:59.597');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (23, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:17:05.813');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (24, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:17:34.510');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (25, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:17:51.503');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (26, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:21:46.467');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (27, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:22:08.470');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (28, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:22:18.677');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (29, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:22:35.820');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (30, 1, 'Login', 'El usuario ha inicado sesion', 'admin', '2026-06-10 21:22:42.653');
INSERT INTO [Bitacora] ([id_Bitacora], [id_Usuario], [actividad], [detalle], [username], [fechaHora]) VALUES (31, 1, 'Logout', 'El administrador ha cerrado sesion', 'admin', '2026-06-10 21:23:06.840');
SET IDENTITY_INSERT [Bitacora] OFF;
GO

-- Data for Usuario_Cambios
SET IDENTITY_INSERT [Usuario_Cambios] ON;
INSERT INTO [Usuario_Cambios] ([id_Cambio], [id_Usuario], [version], [nombre], [password], [fecha], [modificado_por], [tipo_cambio]) VALUES (1, 2, 1, 'user', 'G/5pk0OyXlYg7BPNn227bwEniH4DD5nPx+3cq1/tKnvM8UcH', '2026-06-10 19:39:14.463', 'admin', 'Registro');
INSERT INTO [Usuario_Cambios] ([id_Cambio], [id_Usuario], [version], [nombre], [password], [fecha], [modificado_por], [tipo_cambio]) VALUES (2, 2, 2, 'user', 'exY0Ldk2WMVdT4UOCswV4ckH1gtNT1lRIDCvrWJTiTYv2BBd', '2026-06-10 19:42:58.930', 'admin', 'Modificacion');
INSERT INTO [Usuario_Cambios] ([id_Cambio], [id_Usuario], [version], [nombre], [password], [fecha], [modificado_por], [tipo_cambio]) VALUES (3, 2, 3, 'user', 'G/5pk0OyXlYg7BPNn227bwEniH4DD5nPx+3cq1/tKnvM8UcH', '2026-06-10 19:44:51.940', 'admin', 'Recomposicion (v1)');
SET IDENTITY_INSERT [Usuario_Cambios] OFF;
GO

-- Data for Idioma
INSERT INTO [Idioma] ([id_Idioma], [Nombre], [Agregado]) VALUES (1, 'Espanol', 1);
INSERT INTO [Idioma] ([id_Idioma], [Nombre], [Agregado]) VALUES (2, 'Ingles', 1);
GO

-- Data for Control
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (1, 'labelUsuario', 'Login');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (2, 'labelPassword', 'Login');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (3, 'btnLogin', 'Login');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (4, 'Login', 'Login');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (5, 'labelBienvenido', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (6, 'labelUsuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (7, 'labelContrasena', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (8, 'buttonRegistrarUsuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (9, 'buttonCerrarSesion', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (10, 'labelBitacora', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (11, 'labelRol', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (12, 'btn_LimpiarBitacora', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (13, 'buttonBuscar', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (14, 'labelFechaInicio', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (15, 'labelFechaFinal', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (16, 'labelNombredeusuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (17, 'labelSelectUsuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (18, 'labelTreePermisos', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (19, 'btnAsignar', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (20, 'btnQuitar', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (21, 'labelPermisosUsuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (22, 'labelControldecambios', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (23, 'buttonRecomponerEstadoAnterior', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (24, 'buttonModificarUsuario', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (25, 'labelManejodeidiomas', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (26, 'labelIdioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (27, 'buttonActivarIdioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (28, 'buttonDesactivarIdioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (29, 'labelNombredelidioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (30, 'buttonAgregarIdioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (31, 'buttonAplicarCambiosIdioma', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (32, 'PanelAdmin', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (33, 'buttonActualizarIdiomaMostrar', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (34, 'tabPageUsuarios', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (35, 'tabPageBitacora', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (36, 'tabPageControlCambios', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (37, 'tabPageIdiomas', 'PanelAdmin');
INSERT INTO [Control] ([id_Control], [nombre_control], [form]) VALUES (38, 'labelIdiomaLogin', 'Login');
GO

-- Data for Traduccion
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (1, 1, 1, 'Usuario');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (2, 1, 2, 'Contrasena');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (3, 1, 3, 'Iniciar Sesion');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (4, 1, 4, 'Iniciar Sesion');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (5, 1, 5, 'Bienvenido');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (6, 1, 6, 'Usuario');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (7, 1, 7, 'Contrasena');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (8, 1, 8, 'Registrar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (9, 1, 9, 'Cerrar Sesion');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (10, 1, 10, 'Bitacora');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (11, 1, 11, 'Rol');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (12, 1, 12, 'Limpiar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (13, 1, 13, 'Filtrar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (14, 1, 14, 'Fecha Inicio');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (15, 1, 15, 'Fecha Final');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (16, 1, 16, 'Nombre de usuario');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (17, 1, 17, 'Seleccionar Usuario:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (18, 1, 18, 'arbol de Permisos Disponibles:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (19, 1, 19, 'Asignar >>');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (20, 1, 20, '<< Quitar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (21, 1, 21, 'Permisos Directos del Usuario:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (22, 1, 22, 'Control de cambios');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (23, 1, 23, 'Recomponer estado anterior');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (24, 1, 24, 'Modificar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (25, 1, 25, 'Manejo de idiomas');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (26, 1, 26, 'Idioma');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (27, 1, 27, 'Activar idioma');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (28, 1, 28, 'Desactivar idioma');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (29, 1, 29, 'Nombre del idioma');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (30, 1, 30, 'Agregar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (31, 1, 31, 'Aplicar Cambios');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (32, 1, 32, 'Panel de Administracion');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (33, 1, 33, 'Actualizar');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (34, 1, 34, 'Usuarios y Permisos');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (35, 1, 35, 'Bitacora');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (36, 1, 36, 'Control de Cambios');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (37, 1, 37, 'Idiomas');

-- English Translations (id_Idioma = 2)
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (38, 2, 1, 'Username');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (39, 2, 2, 'Password');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (40, 2, 3, 'Login');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (41, 2, 4, 'Login');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (42, 2, 5, 'Welcome');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (43, 2, 6, 'User');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (44, 2, 7, 'Password');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (45, 2, 8, 'Register');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (46, 2, 9, 'Logout');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (47, 2, 10, 'Activity Log');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (48, 2, 11, 'Role');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (49, 2, 12, 'Clear');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (50, 2, 13, 'Filter');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (51, 2, 14, 'Start Date');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (52, 2, 15, 'End Date');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (53, 2, 16, 'Username');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (54, 2, 17, 'Select User:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (55, 2, 18, 'Available Permissions Tree:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (56, 2, 19, 'Assign >>');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (57, 2, 20, '<< Remove');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (58, 2, 21, 'User Direct Permissions:');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (59, 2, 22, 'Change Log');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (60, 2, 23, 'Restore previous state');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (61, 2, 24, 'Modify');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (62, 2, 25, 'Language Management');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (63, 2, 26, 'Language');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (64, 2, 27, 'Activate language');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (65, 2, 28, 'Deactivate language');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (66, 2, 29, 'Language name');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (67, 2, 30, 'Add');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (68, 2, 31, 'Apply Changes');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (69, 2, 32, 'Admin Panel');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (70, 2, 33, 'Update');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (71, 2, 34, 'Users and Permissions');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (72, 2, 35, 'Activity Log');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (73, 2, 36, 'Change Log');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (74, 2, 37, 'Languages');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (75, 1, 38, 'Idioma');
INSERT INTO [Traduccion] ([id_Traduccion], [id_Idioma], [id_Control], [texto]) VALUES (76, 2, 38, 'Language');
GO

-- Data for IntegridadDigVefV
INSERT INTO [IntegridadDigVefV] ([id_Tabla], [nombreTabla], [hashVertical]) VALUES (1, 'Usuarios', 'b99555ee1b8225110bc11bff12d7dc14414cab2ca2053b1c14cb7cc10fd0e080');
GO

-- ===================================================================
-- STORED PROCEDURES
-- ===================================================================

IF OBJECT_ID('dbo.SP_ListarCambiosUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarCambiosUsuario;
GO

CREATE PROCEDURE [dbo].[SP_ListarCambiosUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Cambio, id_Usuario, [version], nombre, [password], fecha, modificado_por, tipo_cambio
    FROM Usuario_Cambios
    WHERE id_Usuario = @ID_Usuario
    ORDER BY [version] DESC;
END

GO

IF OBJECT_ID('dbo.SP_ObtenerUltimaVersionUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ObtenerUltimaVersionUsuario;
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

IF OBJECT_ID('dbo.SP_ActualizarUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ActualizarUsuario;
GO

CREATE PROCEDURE [dbo].[SP_ActualizarUsuario]
    @ID_Usuario INT,
    @Nombre VARCHAR(50),
    @Password VARCHAR(255)
AS
BEGIN
    UPDATE Usuarios
    SET nombre = @Nombre,
        [password] = @Password
    WHERE id_Usuario = @ID_Usuario;
END

GO

IF OBJECT_ID('dbo.SP_InsertarCambioUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_InsertarCambioUsuario;
GO

CREATE PROCEDURE [dbo].[SP_InsertarCambioUsuario]
    @ID_Usuario INT,
    @Version INT,
    @Nombre VARCHAR(50),
    @Password VARCHAR(255),
    @Fecha DATETIME,
    @ModificadoPor VARCHAR(50),
    @TipoCambio VARCHAR(50)
AS
BEGIN
    INSERT INTO Usuario_Cambios (id_Usuario, [version], nombre, [password], fecha, modificado_por, tipo_cambio)
    VALUES (@ID_Usuario, @Version, @Nombre, @Password, @Fecha, @ModificadoPor, @TipoCambio);
END

GO

IF OBJECT_ID('dbo.sp_upgraddiagrams', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_upgraddiagrams;
GO

	CREATE PROCEDURE dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO

IF OBJECT_ID('dbo.sp_helpdiagrams', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_helpdiagrams;
GO

	CREATE PROCEDURE dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO

IF OBJECT_ID('dbo.sp_helpdiagramdefinition', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_helpdiagramdefinition;
GO

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO

IF OBJECT_ID('dbo.sp_creatediagram', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_creatediagram;
GO

	CREATE PROCEDURE dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO

IF OBJECT_ID('dbo.sp_renamediagram', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_renamediagram;
GO

	CREATE PROCEDURE dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO

IF OBJECT_ID('dbo.sp_alterdiagram', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_alterdiagram;
GO

	CREATE PROCEDURE dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO

IF OBJECT_ID('dbo.sp_dropdiagram', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_dropdiagram;
GO

	CREATE PROCEDURE dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO

IF OBJECT_ID('dbo.SP_InsertarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_InsertarBitacora;
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

IF OBJECT_ID('dbo.SP_InsertarUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_InsertarUsuario;
GO
CREATE PROCEDURE [dbo].[SP_InsertarUsuario]
    @Nombre VARCHAR(50),
    @Password VARCHAR(255),
	@DigVerH VARCHAR(500)
AS
BEGIN
    INSERT INTO Usuarios (nombre, password, DigVerH) 
    VALUES (@Nombre, @Password, @DigVerH);
END

GO

IF OBJECT_ID('dbo.SP_LimpiarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarBitacora;
GO
CREATE PROCEDURE [dbo].[SP_LimpiarBitacora]
AS 
DELETE FROM bitacora

GO

IF OBJECT_ID('dbo.SP_ListarBitacora', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarBitacora;
GO
CREATE PROC [dbo].[SP_ListarBitacora]
AS
BEGIN
    SELECT * FROM Bitacora
END

GO

IF OBJECT_ID('dbo.SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LoginUsuario;
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
		DigVerH
    FROM 
        Usuarios
    WHERE 
        nombre = @Nombre;
END

GO

IF OBJECT_ID('dbo.SP_GuardarComponente', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarComponente;
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

IF OBJECT_ID('dbo.SP_GuardarRelacion', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarRelacion;
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

IF OBJECT_ID('dbo.SP_LimpiarRelacionesComponente', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarRelacionesComponente;
GO
CREATE PROCEDURE [dbo].[SP_LimpiarRelacionesComponente]
    @ID_Padre INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Componente_Relacion WHERE id_Padre = @ID_Padre;
END

GO

IF OBJECT_ID('dbo.SP_ListarComponentes', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarComponentes;
GO
CREATE PROCEDURE [dbo].[SP_ListarComponentes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Componente, nombre, tipo FROM Componentes;
END

GO

IF OBJECT_ID('dbo.SP_ListarRelaciones', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarRelaciones;
GO
CREATE PROCEDURE [dbo].[SP_ListarRelaciones]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Padre, id_Hijo FROM Componente_Relacion;
END

GO

IF OBJECT_ID('dbo.SP_ListarPermisosUsuario', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarPermisosUsuario;
GO
CREATE PROCEDURE [dbo].[SP_ListarPermisosUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Componente FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario;
END

GO

IF OBJECT_ID('dbo.SP_GuardarUsuarioPermiso', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GuardarUsuarioPermiso;
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

IF OBJECT_ID('dbo.SP_QuitarUsuarioPermiso', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_QuitarUsuarioPermiso;
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

IF OBJECT_ID('dbo.SP_ListarUsuarios', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ListarUsuarios;
GO
CREATE PROCEDURE [dbo].[SP_ListarUsuarios]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Usuario, nombre, password, DigVerH FROM Usuarios;
END

GO

IF OBJECT_ID('dbo.SP_LimpiarUsuarioPermisos', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_LimpiarUsuarioPermisos;
GO
CREATE PROCEDURE [dbo].[SP_LimpiarUsuarioPermisos]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Usuario_Componente WHERE id_Usuario = @ID_Usuario;
END

GO

IF OBJECT_ID('dbo.SP_ActualizarDigVerH', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ActualizarDigVerH;
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

IF OBJECT_ID('dbo.SP_ObtenerDigVerH', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ObtenerDigVerH;
GO
CREATE PROCEDURE [dbo].[SP_ObtenerDigVerH]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Usuario, nombre, password, DigVerH FROM Usuarios WHERE id_Usuario = @ID_Usuario;
END

GO

IF OBJECT_ID('dbo.SP_ActualizarDigVerV', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ActualizarDigVerV;
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

IF OBJECT_ID('dbo.SP_ObtenerDigVerV', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ObtenerDigVerV;
GO
CREATE PROCEDURE [dbo].[SP_ObtenerDigVerV]
    @NombreTabla VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_Tabla, nombreTabla, hashVertical FROM IntegridadDigVefV WHERE nombreTabla = @NombreTabla;
END

GO

