/*
 Navicat Premium Data Transfer

 Source Server         : LOCAL MSSQL
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : PAULVELIZ-WINDO\SQLEXPRESS01:1433
 Source Catalog        : estetica_lupita
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 21/12/2020 01:10:27
*/


-- ----------------------------
-- Table structure for auditorias
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[auditorias]') AND type IN ('U'))
	DROP TABLE [dbo].[auditorias]
GO

CREATE TABLE [dbo].[auditorias] (
  [idauditoria] int  IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(245) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [fecha] varchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [hora] varchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[auditorias] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of auditorias
-- ----------------------------
SET IDENTITY_INSERT [dbo].[auditorias] ON
GO

SET IDENTITY_INSERT [dbo].[auditorias] OFF
GO


-- ----------------------------
-- Table structure for cita_detalle
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[cita_detalle]') AND type IN ('U'))
	DROP TABLE [dbo].[cita_detalle]
GO

CREATE TABLE [dbo].[cita_detalle] (
  [idserviciodetalle] int  IDENTITY(1,1) NOT NULL,
  [sv_id] smallint  NOT NULL,
  [sv_cant] int  NOT NULL,
  [sv_precio] decimal(6,2)  NOT NULL,
  [sv_importe] decimal(6,2)  NOT NULL,
  [sv_cita] int  NOT NULL
)
GO

ALTER TABLE [dbo].[cita_detalle] SET (LOCK_ESCALATION = AUTO)
GO


-- ----------------------------
-- Records of cita_detalle
-- ----------------------------
SET IDENTITY_INSERT [dbo].[cita_detalle] ON
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'1', N'6', N'1', N'1288.00', N'1288.00', N'12')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'2', N'5', N'2', N'829.00', N'1658.00', N'12')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'3', N'3', N'1', N'899.00', N'899.00', N'12')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'4', N'2', N'4', N'250.00', N'1000.00', N'12')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'5', N'6', N'2', N'1288.00', N'2576.00', N'13')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'6', N'4', N'1', N'125.00', N'125.00', N'13')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'7', N'2', N'2', N'250.00', N'500.00', N'13')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'8', N'5', N'3', N'829.00', N'2487.00', N'13')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'9', N'6', N'1', N'1288.00', N'1288.00', N'13')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'10', N'6', N'1', N'1288.00', N'1288.00', N'14')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'11', N'6', N'1', N'1288.00', N'1288.00', N'14')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'12', N'4', N'1', N'125.00', N'125.00', N'14')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'13', N'3', N'1', N'899.00', N'899.00', N'14')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'14', N'6', N'2', N'1288.00', N'2576.00', N'15')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'15', N'3', N'3', N'899.00', N'2697.00', N'15')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'16', N'6', N'1', N'1288.00', N'1288.00', N'16')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'17', N'2', N'2', N'250.00', N'500.00', N'16')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'18', N'4', N'1', N'125.00', N'125.00', N'16')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'19', N'3', N'3', N'899.00', N'2697.00', N'16')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'20', N'6', N'2', N'1288.00', N'2576.00', N'17')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'21', N'4', N'2', N'125.00', N'250.00', N'17')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'22', N'2', N'2', N'250.00', N'500.00', N'17')
GO

INSERT INTO [dbo].[cita_detalle] ([idserviciodetalle], [sv_id], [sv_cant], [sv_precio], [sv_importe], [sv_cita]) VALUES (N'23', N'4', N'1', N'125.00', N'125.00', N'17')
GO

SET IDENTITY_INSERT [dbo].[cita_detalle] OFF
GO


-- ----------------------------
-- Table structure for citas
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[citas]') AND type IN ('U'))
	DROP TABLE [dbo].[citas]
GO

CREATE TABLE [dbo].[citas] (
  [idcita] int  IDENTITY(1,1) NOT NULL,
  [ct_empleado] smallint  NOT NULL,
  [ct_cliente] smallint  NOT NULL,
  [ct_fecha] date  NOT NULL,
  [ct_hora] time(7)  NOT NULL,
  [ct_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[citas] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of citas
-- ----------------------------
SET IDENTITY_INSERT [dbo].[citas] ON
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'12', N'4', N'3', N'2020-12-21', N'01:23:00.0000000', N'3')
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'13', N'3', N'3', N'2020-12-26', N'01:27:00.0000000', N'1')
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'14', N'3', N'4', N'2020-12-21', N'07:10:00.0000000', N'1')
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'15', N'3', N'5', N'2020-12-21', N'11:58:00.0000000', N'1')
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'16', N'3', N'3', N'2020-12-21', N'01:58:00.0000000', N'1')
GO

INSERT INTO [dbo].[citas] ([idcita], [ct_empleado], [ct_cliente], [ct_fecha], [ct_hora], [ct_estatus]) VALUES (N'17', N'1', N'3', N'2020-12-21', N'01:20:00.0000000', N'1')
GO

SET IDENTITY_INSERT [dbo].[citas] OFF
GO


-- ----------------------------
-- Table structure for clientes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[clientes]') AND type IN ('U'))
	DROP TABLE [dbo].[clientes]
GO

CREATE TABLE [dbo].[clientes] (
  [idcliente] smallint  IDENTITY(1,1) NOT NULL,
  [cl_nombrecompleto] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [cl_telefono] varchar(10) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [cl_sexo] char(1) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [cl_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[clientes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of clientes
-- ----------------------------
SET IDENTITY_INSERT [dbo].[clientes] ON
GO

INSERT INTO [dbo].[clientes] ([idcliente], [cl_nombrecompleto], [cl_telefono], [cl_sexo], [cl_estatus]) VALUES (N'1', N'PEPE PECAX', N'6871896128', N'm', N'0')
GO

INSERT INTO [dbo].[clientes] ([idcliente], [cl_nombrecompleto], [cl_telefono], [cl_sexo], [cl_estatus]) VALUES (N'2', N'PEPE PECOSO', N'6871896128', N'h', N'0')
GO

INSERT INTO [dbo].[clientes] ([idcliente], [cl_nombrecompleto], [cl_telefono], [cl_sexo], [cl_estatus]) VALUES (N'3', N'BALTA OZUNA AGUILAR', N'1231231231', N'h', N'1')
GO

INSERT INTO [dbo].[clientes] ([idcliente], [cl_nombrecompleto], [cl_telefono], [cl_sexo], [cl_estatus]) VALUES (N'4', N'CHRISTIAN NODAL', N'6879999999', N'h', N'1')
GO

INSERT INTO [dbo].[clientes] ([idcliente], [cl_nombrecompleto], [cl_telefono], [cl_sexo], [cl_estatus]) VALUES (N'5', N'BELINDA OZUNA', N'8009875555', N'm', N'1')
GO

SET IDENTITY_INSERT [dbo].[clientes] OFF
GO


-- ----------------------------
-- Table structure for empleados
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[empleados]') AND type IN ('U'))
	DROP TABLE [dbo].[empleados]
GO

CREATE TABLE [dbo].[empleados] (
  [idempleado] smallint  IDENTITY(1,1) NOT NULL,
  [emp_nombrecompleto] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [emp_telefono] varchar(10) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [emp_sueldo] decimal(7,2)  NOT NULL,
  [emp_puesto] smallint  NOT NULL,
  [emp_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[empleados] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of empleados
-- ----------------------------
SET IDENTITY_INSERT [dbo].[empleados] ON
GO

INSERT INTO [dbo].[empleados] ([idempleado], [emp_nombrecompleto], [emp_telefono], [emp_sueldo], [emp_puesto], [emp_estatus]) VALUES (N'1', N'GERONIMO VARGAS', N'1232131232', N'120.00', N'1', N'1')
GO

INSERT INTO [dbo].[empleados] ([idempleado], [emp_nombrecompleto], [emp_telefono], [emp_sueldo], [emp_puesto], [emp_estatus]) VALUES (N'2', N'ALMA MARCELA GOZO', N'8992388838', N'568.00', N'2', N'0')
GO

INSERT INTO [dbo].[empleados] ([idempleado], [emp_nombrecompleto], [emp_telefono], [emp_sueldo], [emp_puesto], [emp_estatus]) VALUES (N'3', N'JUAN MIGUEL VELAZQUES', N'6992828282', N'500.00', N'3', N'1')
GO

INSERT INTO [dbo].[empleados] ([idempleado], [emp_nombrecompleto], [emp_telefono], [emp_sueldo], [emp_puesto], [emp_estatus]) VALUES (N'4', N'PABLO ESCOBAR', N'6871889922', N'150.00', N'3', N'1')
GO

SET IDENTITY_INSERT [dbo].[empleados] OFF
GO


-- ----------------------------
-- Table structure for notaventa
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[notaventa]') AND type IN ('U'))
	DROP TABLE [dbo].[notaventa]
GO

CREATE TABLE [dbo].[notaventa] (
  [idnotaventa] int  IDENTITY(1,1) NOT NULL,
  [nv_total] decimal(6,2)  NOT NULL,
  [nv_cita] int  NOT NULL,
  [nv_cliente] smallint  NOT NULL,
  [nv_empleado] smallint  NOT NULL,
  [nv_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[notaventa] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of notaventa
-- ----------------------------
SET IDENTITY_INSERT [dbo].[notaventa] ON
GO

INSERT INTO [dbo].[notaventa] ([idnotaventa], [nv_total], [nv_cita], [nv_cliente], [nv_empleado], [nv_estatus]) VALUES (N'10', N'4845.00', N'12', N'3', N'4', N'1')
GO

SET IDENTITY_INSERT [dbo].[notaventa] OFF
GO


-- ----------------------------
-- Table structure for notaventa_detalle
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[notaventa_detalle]') AND type IN ('U'))
	DROP TABLE [dbo].[notaventa_detalle]
GO

CREATE TABLE [dbo].[notaventa_detalle] (
  [idnotaventa] int  NOT NULL,
  [nvd_servicio] smallint  NOT NULL,
  [nvd_precio] decimal(6,2)  NOT NULL,
  [nvd_cantidad] smallint  NOT NULL,
  [nvd_estatus] smallint DEFAULT ((0)) NOT NULL,
  [idnotaventadetalle] int  IDENTITY(1,1) NOT NULL
)
GO

ALTER TABLE [dbo].[notaventa_detalle] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of notaventa_detalle
-- ----------------------------
SET IDENTITY_INSERT [dbo].[notaventa_detalle] ON
GO

INSERT INTO [dbo].[notaventa_detalle] ([idnotaventa], [nvd_servicio], [nvd_precio], [nvd_cantidad], [nvd_estatus], [idnotaventadetalle]) VALUES (N'10', N'6', N'1288.00', N'1', N'0', N'2')
GO

INSERT INTO [dbo].[notaventa_detalle] ([idnotaventa], [nvd_servicio], [nvd_precio], [nvd_cantidad], [nvd_estatus], [idnotaventadetalle]) VALUES (N'10', N'5', N'829.00', N'2', N'0', N'3')
GO

INSERT INTO [dbo].[notaventa_detalle] ([idnotaventa], [nvd_servicio], [nvd_precio], [nvd_cantidad], [nvd_estatus], [idnotaventadetalle]) VALUES (N'10', N'3', N'899.00', N'1', N'0', N'4')
GO

INSERT INTO [dbo].[notaventa_detalle] ([idnotaventa], [nvd_servicio], [nvd_precio], [nvd_cantidad], [nvd_estatus], [idnotaventadetalle]) VALUES (N'10', N'2', N'250.00', N'4', N'0', N'5')
GO

SET IDENTITY_INSERT [dbo].[notaventa_detalle] OFF
GO


-- ----------------------------
-- Table structure for puestos
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[puestos]') AND type IN ('U'))
	DROP TABLE [dbo].[puestos]
GO

CREATE TABLE [dbo].[puestos] (
  [idpuesto] smallint  IDENTITY(1,1) NOT NULL,
  [pst_descripcion] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [pst_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[puestos] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of puestos
-- ----------------------------
SET IDENTITY_INSERT [dbo].[puestos] ON
GO

INSERT INTO [dbo].[puestos] ([idpuesto], [pst_descripcion], [pst_estatus]) VALUES (N'1', N'DEPILADOR', N'1')
GO

INSERT INTO [dbo].[puestos] ([idpuesto], [pst_descripcion], [pst_estatus]) VALUES (N'2', N'PELUQUERO', N'1')
GO

INSERT INTO [dbo].[puestos] ([idpuesto], [pst_descripcion], [pst_estatus]) VALUES (N'3', N'MASAJISTA', N'1')
GO

INSERT INTO [dbo].[puestos] ([idpuesto], [pst_descripcion], [pst_estatus]) VALUES (N'4', N'NONEE', N'0')
GO

SET IDENTITY_INSERT [dbo].[puestos] OFF
GO


-- ----------------------------
-- Table structure for servicios
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[servicios]') AND type IN ('U'))
	DROP TABLE [dbo].[servicios]
GO

CREATE TABLE [dbo].[servicios] (
  [idservicio] smallint  IDENTITY(1,1) NOT NULL,
  [sv_descripcion] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [sv_precio] decimal(6,2)  NOT NULL,
  [sv_estatus] smallint DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[servicios] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of servicios
-- ----------------------------
SET IDENTITY_INSERT [dbo].[servicios] ON
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'1', N'CORTE CABELLO', N'120.00', N'0')
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'2', N'MASAJE MONTANA', N'250.00', N'1')
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'3', N'MASAJE MELOTOCON', N'899.00', N'1')
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'4', N'CORTE DE CABELLO', N'125.00', N'1')
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'5', N'MANICURE', N'829.00', N'1')
GO

INSERT INTO [dbo].[servicios] ([idservicio], [sv_descripcion], [sv_precio], [sv_estatus]) VALUES (N'6', N'PEDICURE', N'1288.00', N'1')
GO

SET IDENTITY_INSERT [dbo].[servicios] OFF
GO


-- ----------------------------
-- Table structure for usuarios
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[usuarios]') AND type IN ('U'))
	DROP TABLE [dbo].[usuarios]
GO

CREATE TABLE [dbo].[usuarios] (
  [idusuario] int  IDENTITY(1,1) NOT NULL,
  [usuario_name] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [usuario_pass] varchar(45) COLLATE Modern_Spanish_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[usuarios] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of usuarios
-- ----------------------------
SET IDENTITY_INSERT [dbo].[usuarios] ON
GO

INSERT INTO [dbo].[usuarios] ([idusuario], [usuario_name], [usuario_pass]) VALUES (N'1', N'veronica', N'veronica123')
GO

INSERT INTO [dbo].[usuarios] ([idusuario], [usuario_name], [usuario_pass]) VALUES (N'4', N'PATOLUCAS', N'12345123')
GO

SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO


-- ----------------------------
-- Auto increment value for auditorias
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[auditorias]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table auditorias
-- ----------------------------
ALTER TABLE [dbo].[auditorias] ADD CONSTRAINT [pk_auditorias] PRIMARY KEY CLUSTERED ([idauditoria])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for cita_detalle
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[cita_detalle]', RESEED, 23)
GO


-- ----------------------------
-- Primary Key structure for table cita_detalle
-- ----------------------------
ALTER TABLE [dbo].[cita_detalle] ADD CONSTRAINT [PK__cita_det__C2B2659D969393A2] PRIMARY KEY CLUSTERED ([idserviciodetalle])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for citas
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[citas]', RESEED, 17)
GO


-- ----------------------------
-- Indexes structure for table citas
-- ----------------------------
CREATE NONCLUSTERED INDEX [fkcliente_idx]
ON [dbo].[citas] (
  [ct_cliente] ASC
)
GO

CREATE NONCLUSTERED INDEX [fkempleado_idx]
ON [dbo].[citas] (
  [ct_empleado] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table citas
-- ----------------------------
ALTER TABLE [dbo].[citas] ADD CONSTRAINT [pk_citas] PRIMARY KEY CLUSTERED ([idcita])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for clientes
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[clientes]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table clientes
-- ----------------------------
ALTER TABLE [dbo].[clientes] ADD CONSTRAINT [pk_clientes] PRIMARY KEY CLUSTERED ([idcliente])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for empleados
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[empleados]', RESEED, 4)
GO


-- ----------------------------
-- Indexes structure for table empleados
-- ----------------------------
CREATE NONCLUSTERED INDEX [fkemppuesto_idx]
ON [dbo].[empleados] (
  [emp_puesto] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table empleados
-- ----------------------------
ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [pk_empleados] PRIMARY KEY CLUSTERED ([idempleado])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for notaventa
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[notaventa]', RESEED, 10)
GO


-- ----------------------------
-- Indexes structure for table notaventa
-- ----------------------------
CREATE NONCLUSTERED INDEX [fknotacita_idx]
ON [dbo].[notaventa] (
  [nv_cita] ASC
)
GO

CREATE NONCLUSTERED INDEX [fknotacliente_idx]
ON [dbo].[notaventa] (
  [nv_cliente] ASC
)
GO

CREATE NONCLUSTERED INDEX [fknotaemp_idx]
ON [dbo].[notaventa] (
  [nv_empleado] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table notaventa
-- ----------------------------
ALTER TABLE [dbo].[notaventa] ADD CONSTRAINT [pk_notaventa] PRIMARY KEY CLUSTERED ([idnotaventa])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for notaventa_detalle
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[notaventa_detalle]', RESEED, 5)
GO


-- ----------------------------
-- Indexes structure for table notaventa_detalle
-- ----------------------------
CREATE NONCLUSTERED INDEX [fknotacnota_idx]
ON [dbo].[notaventa_detalle] (
  [idnotaventa] ASC
)
GO

CREATE NONCLUSTERED INDEX [fknotavservicio_idx]
ON [dbo].[notaventa_detalle] (
  [nvd_servicio] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table notaventa_detalle
-- ----------------------------
ALTER TABLE [dbo].[notaventa_detalle] ADD CONSTRAINT [PK__notavent__280A47B5480A0A9B] PRIMARY KEY CLUSTERED ([idnotaventadetalle])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for puestos
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[puestos]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table puestos
-- ----------------------------
ALTER TABLE [dbo].[puestos] ADD CONSTRAINT [pk_puestos] PRIMARY KEY CLUSTERED ([idpuesto])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for servicios
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[servicios]', RESEED, 6)
GO


-- ----------------------------
-- Primary Key structure for table servicios
-- ----------------------------
ALTER TABLE [dbo].[servicios] ADD CONSTRAINT [pk_servicios] PRIMARY KEY CLUSTERED ([idservicio])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for usuarios
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[usuarios]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table usuarios
-- ----------------------------
ALTER TABLE [dbo].[usuarios] ADD CONSTRAINT [pk_usuarios] PRIMARY KEY CLUSTERED ([idusuario])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table cita_detalle
-- ----------------------------
ALTER TABLE [dbo].[cita_detalle] ADD CONSTRAINT [fk_svd_sv] FOREIGN KEY ([sv_id]) REFERENCES [dbo].[servicios] ([idservicio]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[cita_detalle] ADD CONSTRAINT [fk_svd_ct] FOREIGN KEY ([sv_cita]) REFERENCES [dbo].[citas] ([idcita]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table citas
-- ----------------------------
ALTER TABLE [dbo].[citas] ADD CONSTRAINT [fkcliente] FOREIGN KEY ([ct_cliente]) REFERENCES [dbo].[clientes] ([idcliente]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[citas] ADD CONSTRAINT [fkempleado] FOREIGN KEY ([ct_empleado]) REFERENCES [dbo].[empleados] ([idempleado]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table empleados
-- ----------------------------
ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [fkemppuesto] FOREIGN KEY ([emp_puesto]) REFERENCES [dbo].[puestos] ([idpuesto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table notaventa
-- ----------------------------
ALTER TABLE [dbo].[notaventa] ADD CONSTRAINT [fknotacita] FOREIGN KEY ([nv_cita]) REFERENCES [dbo].[citas] ([idcita]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[notaventa] ADD CONSTRAINT [fknotacliente] FOREIGN KEY ([nv_cliente]) REFERENCES [dbo].[clientes] ([idcliente]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[notaventa] ADD CONSTRAINT [fknotaemp] FOREIGN KEY ([nv_empleado]) REFERENCES [dbo].[empleados] ([idempleado]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table notaventa_detalle
-- ----------------------------
ALTER TABLE [dbo].[notaventa_detalle] ADD CONSTRAINT [fknotacnota] FOREIGN KEY ([idnotaventa]) REFERENCES [dbo].[notaventa] ([idnotaventa]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[notaventa_detalle] ADD CONSTRAINT [fknotavservicio] FOREIGN KEY ([nvd_servicio]) REFERENCES [dbo].[servicios] ([idservicio]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

