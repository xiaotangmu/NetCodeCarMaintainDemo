/*
 Navicat Premium Data Transfer

 Source Server         : MySqlServer
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : 127.0.0.1:1433
 Source Catalog        : maintain
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 20/10/2020 17:17:12
*/


-- ----------------------------
-- Table structure for BMMS_CATALOG_ATTR
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BMMS_CATALOG_ATTR]') AND type IN ('U'))
	DROP TABLE [dbo].[BMMS_CATALOG_ATTR]
GO

CREATE TABLE [dbo].[BMMS_CATALOG_ATTR] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ATTR_NAME] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CATALOG_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[BMMS_CATALOG_ATTR] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of BMMS_CATALOG_ATTR
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4cccb814186147768c7029cfb76194a9', N'string', N'e833bf95f28c4f8e82e8f61e94b0908e', NULL, N'2020-10-16 10:30:58.420', NULL, N'2020-10-16 10:30:58.420')
GO

INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'9f1d47e2cbbc477db6c1e4ecbbb862ba', N'string', N'61d067af77db48858ac452c97009ddbd', NULL, N'2020-10-16 11:56:37.043', NULL, N'2020-10-16 11:56:37.043')
GO

INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'df6afd21adc541e08c15711ca3afe15d', N'string2', N'e833bf95f28c4f8e82e8f61e94b0908e', NULL, N'2020-10-16 10:31:01.633', NULL, N'2020-10-16 10:31:01.633')
GO


-- ----------------------------
-- Table structure for BMMS_CATALOG1
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BMMS_CATALOG1]') AND type IN ('U'))
	DROP TABLE [dbo].[BMMS_CATALOG1]
GO

CREATE TABLE [dbo].[BMMS_CATALOG1] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CATALOG_NAME] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[BMMS_CATALOG1] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of BMMS_CATALOG1
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'1717e42650d748c8b03d7fe87d217dc2', N'小明2', NULL, NULL, N'2020-10-16 11:53:51.340', NULL, N'2020-10-16 11:53:51.340')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'2adfcc60118d4e1c9728e6af1a12eb44', N'小明hh22', NULL, NULL, N'2020-10-16 15:44:50.703', NULL, N'2020-10-16 15:44:50.703')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'41ba7fcb9e284a57ab19049b7da06929', N'string1', NULL, NULL, N'2020-10-16 11:54:36.947', NULL, N'2020-10-16 11:54:36.947')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'50c5766431a84356bec937d68ba560ce', N'小明', NULL, NULL, N'2020-10-16 10:29:33.193', NULL, N'2020-10-16 10:29:52.937')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'a9e449814145492781f48d224cc2243e', N'string4', NULL, NULL, N'2020-10-16 09:40:43.077', NULL, N'2020-10-16 09:40:43.077')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'b67d9cb109b5419fa556242e7e56bfed', N'小明22', NULL, NULL, N'2020-10-16 11:54:04.143', NULL, N'2020-10-16 11:54:04.143')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'bc639ceebbfd4859981a5757c0171916', N'string5', NULL, NULL, N'2020-10-16 09:40:43.077', NULL, N'2020-10-16 09:40:43.077')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'e3c426eb6a544b3f8937c42c3803a5ed', N'string2', NULL, NULL, N'2020-10-16 11:54:36.947', NULL, N'2020-10-16 11:54:36.947')
GO


-- ----------------------------
-- Table structure for BMMS_CATALOG2
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BMMS_CATALOG2]') AND type IN ('U'))
	DROP TABLE [dbo].[BMMS_CATALOG2]
GO

CREATE TABLE [dbo].[BMMS_CATALOG2] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CATALOG_NAME] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PARENT_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[BMMS_CATALOG2] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of BMMS_CATALOG2
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'0d6f1ec8b8b14b5d9ed5194019c952ad', N'string', NULL, N'a9e449814145492781f48d224cc2243e', NULL, N'2020-10-16 11:55:28.897', NULL, N'2020-10-16 11:55:28.897')
GO

INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'61d067af77db48858ac452c97009ddbd', N'string3', NULL, N'a9e449814145492781f48d224cc2243e', NULL, N'2020-10-16 11:55:38.870', NULL, N'2020-10-16 11:55:38.870')
GO


-- ----------------------------
-- Table structure for CMS_CLIENT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CLIENT]') AND type IN ('U'))
	DROP TABLE [dbo].[CMS_CLIENT]
GO

CREATE TABLE [dbo].[CMS_CLIENT] (
  [COMPANY] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [ADDRESS] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [PHONE] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [CONTACT] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [EMAIL] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TYPE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL,
  [ID] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[CMS_CLIENT] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'公司名称',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'COMPANY'
GO

EXEC sp_addextendedproperty
'MS_Description', N'公司地址',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'ADDRESS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'PHONE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'CONTACT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'EMAIL'
GO

EXEC sp_addextendedproperty
'MS_Description', N'车型',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'TYPE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'描述/备注',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'DESCRIPTION'
GO


-- ----------------------------
-- Records of CMS_CLIENT
-- ----------------------------
INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'string', N'string', N'string', N'string', N'string', N'string', N'string', NULL, N'2020-10-14 10:31:54.267', NULL, N'2020-10-14 10:31:54.267', N'3c0495a3b676483f91fd94f8a64270a8')
GO

INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'xiao', N'dsf', N'dd', NULL, N'dd', N'dd', N'xiao', NULL, N'2020-10-13 16:08:46.050', NULL, N'2020-10-13 16:53:38.847', N'a52232aea81d4b37bed1006fccd76557')
GO

INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'xx', N'dd', N'fdf', N'dfs', N'ee', N'ee', N'dfs', NULL, N'2020-10-13 14:47:23.747', NULL, N'2020-10-13 14:47:23.747', N'c9b6cfd49d024ba583418f4dd41a059a')
GO


-- ----------------------------
-- Table structure for COMMON_TYPE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[COMMON_TYPE]') AND type IN ('U'))
	DROP TABLE [dbo].[COMMON_TYPE]
GO

CREATE TABLE [dbo].[COMMON_TYPE] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [TYPE_NO] int  NULL,
  [TITLE] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [TYPE_NAME] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[COMMON_TYPE] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of COMMON_TYPE
-- ----------------------------
SET IDENTITY_INSERT [dbo].[COMMON_TYPE] ON
GO

SET IDENTITY_INSERT [dbo].[COMMON_TYPE] OFF
GO


-- ----------------------------
-- Table structure for MMS_APPOINTMENT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MMS_APPOINTMENT]') AND type IN ('U'))
	DROP TABLE [dbo].[MMS_APPOINTMENT]
GO

CREATE TABLE [dbo].[MMS_APPOINTMENT] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [APPOINTMENT_NO] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [COMPANY_ID] int  NULL,
  [CAR_LICENSE] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [APPOINTMENT_DATE] datetime  NULL,
  [TYPE] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [CONTACT] int DEFAULT ((0)) NULL,
  [PHONE] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [STATUS] varchar(1) COLLATE Chinese_PRC_CI_AS  NULL,
  [REMARK] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[MMS_APPOINTMENT] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'预约单编号',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'APPOINTMENT_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定所属公司',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'COMPANY_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'车牌',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'CAR_LICENSE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'问题描述',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'预约时间',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'APPOINTMENT_DATE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'车型',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'TYPE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'CONTACT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'PHONE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'预约单状态，0为处理，1已处理，2取消预约',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'REMARK'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'OCU'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'OCD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新人',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'LUC'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新时间',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'LUD'
GO


-- ----------------------------
-- Records of MMS_APPOINTMENT
-- ----------------------------
SET IDENTITY_INSERT [dbo].[MMS_APPOINTMENT] ON
GO

SET IDENTITY_INSERT [dbo].[MMS_APPOINTMENT] OFF
GO


-- ----------------------------
-- Table structure for mms_maintain
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[mms_maintain]') AND type IN ('U'))
	DROP TABLE [dbo].[mms_maintain]
GO

CREATE TABLE [dbo].[mms_maintain] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [STAFF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [APPOINTMENT_ID] int  NULL,
  [CREATE_TIME] datetime  NULL,
  [SATUS] int DEFAULT ((0)) NULL,
  [RETURN_TIME] datetime  NULL,
  [MAINTAIN_NO] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[mms_maintain] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'员工',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'STAFF'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定预约单',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'APPOINTMENT_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'CREATE_TIME'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否完成，0没有，1完成',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'SATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'交付时间',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'RETURN_TIME'
GO

EXEC sp_addextendedproperty
'MS_Description', N'维修单号',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'MAINTAIN_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'OCU'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'OCD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新人',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'LUC'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新时间',
'SCHEMA', N'dbo',
'TABLE', N'mms_maintain',
'COLUMN', N'LUD'
GO


-- ----------------------------
-- Records of mms_maintain
-- ----------------------------
SET IDENTITY_INSERT [dbo].[mms_maintain] ON
GO

SET IDENTITY_INSERT [dbo].[mms_maintain] OFF
GO


-- ----------------------------
-- Table structure for mms_maintain_oldpart
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[mms_maintain_oldpart]') AND type IN ('U'))
	DROP TABLE [dbo].[mms_maintain_oldpart]
GO

CREATE TABLE [dbo].[mms_maintain_oldpart] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [FromCar] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [FromCompany] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [MaintainId] int  NULL,
  [Type] varchar(1) COLLATE Chinese_PRC_CI_AS  NULL,
  [Number] varchar(1) COLLATE Chinese_PRC_CI_AS  NULL,
  [Price] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[mms_maintain_oldpart] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of mms_maintain_oldpart
-- ----------------------------
SET IDENTITY_INSERT [dbo].[mms_maintain_oldpart] ON
GO

SET IDENTITY_INSERT [dbo].[mms_maintain_oldpart] OFF
GO


-- ----------------------------
-- Table structure for mms_maintain_sku
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[mms_maintain_sku]') AND type IN ('U'))
	DROP TABLE [dbo].[mms_maintain_sku]
GO

CREATE TABLE [dbo].[mms_maintain_sku] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [SkuId] int  NULL,
  [Price] decimal(18)  NULL,
  [Number] int  NULL,
  [MaintainId] int  NULL
)
GO

ALTER TABLE [dbo].[mms_maintain_sku] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of mms_maintain_sku
-- ----------------------------
SET IDENTITY_INSERT [dbo].[mms_maintain_sku] ON
GO

SET IDENTITY_INSERT [dbo].[mms_maintain_sku] OFF
GO


-- ----------------------------
-- Table structure for mms_maintain_tool
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[mms_maintain_tool]') AND type IN ('U'))
	DROP TABLE [dbo].[mms_maintain_tool]
GO

CREATE TABLE [dbo].[mms_maintain_tool] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [SkuId] int  NULL,
  [Number] int  NULL,
  [MaintainId] int  NULL
)
GO

ALTER TABLE [dbo].[mms_maintain_tool] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of mms_maintain_tool
-- ----------------------------
SET IDENTITY_INSERT [dbo].[mms_maintain_tool] ON
GO

SET IDENTITY_INSERT [dbo].[mms_maintain_tool] OFF
GO


-- ----------------------------
-- Table structure for PMS_SPU
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PMS_SPU]') AND type IN ('U'))
	DROP TABLE [dbo].[PMS_SPU]
GO

CREATE TABLE [dbo].[PMS_SPU] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CATALOG2_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SPU_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PRODUCT_NAME] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[PMS_SPU] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PMS_SPU
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'23477d9ce1144e80a18662b4886c6a1e', N'string2', NULL, N'string3', N'string', NULL, N'10 19 2020  4:48PM', NULL, N'10 19 2020  4:48PM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'3d5cae2ab2914ab9ab8a1ac308e6ed0d', N'string', NULL, N'string', N'string', NULL, N'10 19 2020  4:23PM', NULL, N'10 19 2020  4:23PM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'd7ed3c8162cb41bb87073530891717e5', N'string2', NULL, N'string2', N'string', NULL, N'10 19 2020  4:48PM', NULL, N'10 19 2020  4:48PM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'df28ab9c0fb5413db5436e69dac9d00c', N'string', NULL, N'你好吗', N'string', NULL, N'10 20 2020  9:09AM', NULL, N'10 20 2020  9:09AM')
GO


-- ----------------------------
-- Table structure for PMS_SPU_ATTR
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PMS_SPU_ATTR]') AND type IN ('U'))
	DROP TABLE [dbo].[PMS_SPU_ATTR]
GO

CREATE TABLE [dbo].[PMS_SPU_ATTR] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ATTR_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SPU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[PMS_SPU_ATTR] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PMS_SPU_ATTR
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'1', N'9f1d47e2cbbc477db6c1e4ecbbb862ba', N'23477d9ce1144e80a18662b4886c6a1e')
GO

INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'1bc92de23a50488c82099d85bc2fbdcf', N'string', N'df28ab9c0fb5413db5436e69dac9d00c')
GO

INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'43bd668189094108bffc3af7640a6c7a', N'df6afd21adc541e08c15711ca3afe15d', N'3d5cae2ab2914ab9ab8a1ac308e6ed0d')
GO


-- ----------------------------
-- Table structure for PMS_SPU_ATTR_VALUE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PMS_SPU_ATTR_VALUE]') AND type IN ('U'))
	DROP TABLE [dbo].[PMS_SPU_ATTR_VALUE]
GO

CREATE TABLE [dbo].[PMS_SPU_ATTR_VALUE] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SPU_ATTR_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [VALUE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[PMS_SPU_ATTR_VALUE] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PMS_SPU_ATTR_VALUE
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'1', N'1', N'xx')
GO

INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'2', N'1', N'dd')
GO

INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'5f6786704aad4f59bfd73ce9cf068078', N'43bd668189094108bffc3af7640a6c7a', N'string')
GO

INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'6d376bdf512e4ae8b35ac529e1b17df3', N'1bc92de23a50488c82099d85bc2fbdcf', N'string')
GO


-- ----------------------------
-- Table structure for sms_check
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_check]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_check]
GO

CREATE TABLE [dbo].[sms_check] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [CheckNo] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Operator] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Status] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[sms_check] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_check
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_check] ON
GO

SET IDENTITY_INSERT [dbo].[sms_check] OFF
GO


-- ----------------------------
-- Table structure for sms_check_sku
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_check_sku]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_check_sku]
GO

CREATE TABLE [dbo].[sms_check_sku] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [CheckId] int  NULL,
  [SkuId] int  NULL,
  [Quantity] int  NULL,
  [Status] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [OldQuantity] int  NULL
)
GO

ALTER TABLE [dbo].[sms_check_sku] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_check_sku
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_check_sku] ON
GO

SET IDENTITY_INSERT [dbo].[sms_check_sku] OFF
GO


-- ----------------------------
-- Table structure for sms_entry
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_entry]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_entry]
GO

CREATE TABLE [dbo].[sms_entry] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [EntryNo] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Operator] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [EntryDate] date  NULL,
  [TotalPrice] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[sms_entry] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_entry
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_entry] ON
GO

SET IDENTITY_INSERT [dbo].[sms_entry] OFF
GO


-- ----------------------------
-- Table structure for sms_entry_sku
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_entry_sku]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_entry_sku]
GO

CREATE TABLE [dbo].[sms_entry_sku] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [SkuId] int  NULL,
  [EntryNo] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Number] int  NULL,
  [Price] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[sms_entry_sku] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_entry_sku
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_entry_sku] ON
GO

SET IDENTITY_INSERT [dbo].[sms_entry_sku] OFF
GO


-- ----------------------------
-- Table structure for sms_out
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_out]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_out]
GO

CREATE TABLE [dbo].[sms_out] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [OutNo] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Operator] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [OutDate] date  NULL,
  [TotalPrice] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[sms_out] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_out
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_out] ON
GO

SET IDENTITY_INSERT [dbo].[sms_out] OFF
GO


-- ----------------------------
-- Table structure for sms_out_sku
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_out_sku]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_out_sku]
GO

CREATE TABLE [dbo].[sms_out_sku] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [SkuId] int  NULL,
  [Number] int  NULL,
  [Price] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[sms_out_sku] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_out_sku
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_out_sku] ON
GO

SET IDENTITY_INSERT [dbo].[sms_out_sku] OFF
GO


-- ----------------------------
-- Table structure for SMS_SKU
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU]
GO

CREATE TABLE [dbo].[SMS_SKU] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SKU_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SKU_NAME] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SPU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BRAND] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PRICE] decimal(2)  NULL,
  [UNIT] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TOTAL_COUNT] int  NULL,
  [ALARM] int  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [TYPE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [STATUS] int  NULL,
  [OLD_PARTID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CATALOG2_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[SMS_SKU] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键哈希生成',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存编号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'SKU_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存名(冗余，方便 操作)',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'SKU_NAME'
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联SPU',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'SPU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'配件品牌',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'BRAND'
GO

EXEC sp_addextendedproperty
'MS_Description', N'单价',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'单位',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'UNIT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'总数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'TOTAL_COUNT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'警报值',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'ALARM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'规格',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'TYPE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态，0为新，1为旧（回收配件）',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定旧配件表',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'OLD_PARTID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定二级分类',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'CATALOG2_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建账号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'OCU'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'OCD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新账号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'LUC'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新时间',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'LUD'
GO


-- ----------------------------
-- Records of SMS_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU] ([ID], [SKU_NO], [SKU_NAME], [SPU_ID], [BRAND], [PRICE], [UNIT], [TOTAL_COUNT], [ALARM], [DESCRIPTION], [TYPE], [STATUS], [OLD_PARTID], [CATALOG2_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'1', N'no', N'name', N'spu', N'brand', N'22', N'unit', N'33', N'3', N'descr', N'type', N'0', N'oldpart', N'cata', NULL, N'2020-10-20 16:05:04.000', NULL, NULL)
GO

INSERT INTO [dbo].[SMS_SKU] ([ID], [SKU_NO], [SKU_NAME], [SPU_ID], [BRAND], [PRICE], [UNIT], [TOTAL_COUNT], [ALARM], [DESCRIPTION], [TYPE], [STATUS], [OLD_PARTID], [CATALOG2_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'2', N'no', N'string3', N'd7ed3c8162cb41bb87073530891717e5', N'brand', N'22', N'unit', N'33', N'3', N'descr', N'type', N'0', N'oldpart', N'cata', NULL, N'2020-10-24 16:05:09.000', NULL, NULL)
GO


-- ----------------------------
-- Table structure for SMS_SKU_ADDRESS
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU_ADDRESS]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU_ADDRESS]
GO

CREATE TABLE [dbo].[SMS_SKU_ADDRESS] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [QUANTITY] int  NULL
)
GO

ALTER TABLE [dbo].[SMS_SKU_ADDRESS] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联sku',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ADDRESS',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ADDRESS',
'COLUMN', N'QUANTITY'
GO


-- ----------------------------
-- Records of SMS_SKU_ADDRESS
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU_ADDRESS] ([ID], [SKU_ID], [ROOM], [SELF], [QUANTITY]) VALUES (N'1', N'2', N'd', N'd', N'3')
GO


-- ----------------------------
-- Table structure for SMS_SKU_ATTR_VALUE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU_ATTR_VALUE]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU_ATTR_VALUE]
GO

CREATE TABLE [dbo].[SMS_SKU_ATTR_VALUE] (
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SPU_ATTR_VALUE_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SMS_SKU_ATTR_VALUE] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ATTR_VALUE',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'属性值',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ATTR_VALUE',
'COLUMN', N'SPU_ATTR_VALUE_ID'
GO


-- ----------------------------
-- Records of SMS_SKU_ATTR_VALUE
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU_ATTR_VALUE] ([SKU_ID], [SPU_ATTR_VALUE_ID], [ID]) VALUES (N'2', N'5f6786704aad4f59bfd73ce9cf068078', N'1')
GO


-- ----------------------------
-- Table structure for SMS_SKU_LOG
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU_LOG]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU_LOG]
GO

CREATE TABLE [dbo].[SMS_SKU_LOG] (
  [ID] varchar(1) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SKU_ID] varchar(1) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_QUANTITY] int  NULL,
  [OLD_ALARM] int  NULL,
  [OLD_PRICE] decimal(2)  NULL,
  [NEW_ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [NEW_SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [NEW_QUANTITY] int  NULL,
  [NEW_PRICE] decimal(2)  NULL,
  [NEW_ALARM] int  NULL,
  [TYPE] int  NULL,
  [OCD] datetime  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SMS_SKU_LOG] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改前的房间号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG',
'COLUMN', N'OLD_ROOM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改前的架子号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG',
'COLUMN', N'OLD_SELF'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0为更新，1为删除，2 为出库，3 为入库',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG',
'COLUMN', N'TYPE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间/配件修改时间',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG',
'COLUMN', N'OCD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作账号/配件修改账号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG',
'COLUMN', N'OCU'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作账号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_LOG'
GO


-- ----------------------------
-- Records of SMS_SKU_LOG
-- ----------------------------

-- ----------------------------
-- Table structure for ums_authority
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_authority]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_authority]
GO

CREATE TABLE [dbo].[ums_authority] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [AuthorityName] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ums_authority] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_authority
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_authority] ON
GO

SET IDENTITY_INSERT [dbo].[ums_authority] OFF
GO


-- ----------------------------
-- Table structure for ums_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_role]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_role]
GO

CREATE TABLE [dbo].[ums_role] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [RoleName] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ums_role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_role] ON
GO

SET IDENTITY_INSERT [dbo].[ums_role] OFF
GO


-- ----------------------------
-- Table structure for ums_role_authority
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_role_authority]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_role_authority]
GO

CREATE TABLE [dbo].[ums_role_authority] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [RoleId] int  NULL,
  [AuthorityId] int  NULL
)
GO

ALTER TABLE [dbo].[ums_role_authority] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_role_authority
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_role_authority] ON
GO

SET IDENTITY_INSERT [dbo].[ums_role_authority] OFF
GO


-- ----------------------------
-- Table structure for ums_user
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_user]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_user]
GO

CREATE TABLE [dbo].[ums_user] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [UserName] varchar(30) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Pwd] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ums_user] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_user
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_user] ON
GO

SET IDENTITY_INSERT [dbo].[ums_user] OFF
GO


-- ----------------------------
-- Table structure for ums_user_info
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_user_info]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_user_info]
GO

CREATE TABLE [dbo].[ums_user_info] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [UserId] int  NULL,
  [Email] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Phone] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sex] int  NULL,
  [Photo] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ums_user_info] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_user_info
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_user_info] ON
GO

SET IDENTITY_INSERT [dbo].[ums_user_info] OFF
GO


-- ----------------------------
-- Table structure for ums_user_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ums_user_role]') AND type IN ('U'))
	DROP TABLE [dbo].[ums_user_role]
GO

CREATE TABLE [dbo].[ums_user_role] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [RoleId] int  NULL,
  [UserId] int  NULL
)
GO

ALTER TABLE [dbo].[ums_user_role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ums_user_role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_user_role] ON
GO

SET IDENTITY_INSERT [dbo].[ums_user_role] OFF
GO


-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG_ATTR
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG_ATTR] ADD CONSTRAINT [PK__BMMS_CAT__3214EC278CA46BC2] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG1
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG1] ADD CONSTRAINT [PK__BMMS_CAT__3214EC27FDF21027] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG2
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG2] ADD CONSTRAINT [PK__BMMS_CAT__3214EC279D1B02E1] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CMS_CLIENT
-- ----------------------------
ALTER TABLE [dbo].[CMS_CLIENT] ADD CONSTRAINT [PK__CMS_CLIE__3214EC27BB95052F] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for COMMON_TYPE
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[COMMON_TYPE]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table COMMON_TYPE
-- ----------------------------
ALTER TABLE [dbo].[COMMON_TYPE] ADD CONSTRAINT [PK__COMMON_T__3214EC27A881BC0D] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for MMS_APPOINTMENT
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[MMS_APPOINTMENT]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table MMS_APPOINTMENT
-- ----------------------------
ALTER TABLE [dbo].[MMS_APPOINTMENT] ADD CONSTRAINT [PK__mms_appo__3213E83F7612500E] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for mms_maintain
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[mms_maintain]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table mms_maintain
-- ----------------------------
ALTER TABLE [dbo].[mms_maintain] ADD CONSTRAINT [PK__mms_main__3213E83F872FCAE5] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for mms_maintain_oldpart
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[mms_maintain_oldpart]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table mms_maintain_oldpart
-- ----------------------------
ALTER TABLE [dbo].[mms_maintain_oldpart] ADD CONSTRAINT [PK__mms_main__3213E83F1535E3EF] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for mms_maintain_sku
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[mms_maintain_sku]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table mms_maintain_sku
-- ----------------------------
ALTER TABLE [dbo].[mms_maintain_sku] ADD CONSTRAINT [PK__mms_main__3213E83F121CFC63] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for mms_maintain_tool
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[mms_maintain_tool]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table mms_maintain_tool
-- ----------------------------
ALTER TABLE [dbo].[mms_maintain_tool] ADD CONSTRAINT [PK__mms_main__3213E83F998DCA1D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PMS_SPU
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU] ADD CONSTRAINT [PK__PMS_SPU__3214EC27A5CC33E7] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PMS_SPU_ATTR
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU_ATTR] ADD CONSTRAINT [PK__PMS_SPU___3214EC279328EA7A] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_check
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_check]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_check
-- ----------------------------
ALTER TABLE [dbo].[sms_check] ADD CONSTRAINT [PK__sms_chec__3213E83F7EE241F8] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_check_sku
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_check_sku]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_check_sku
-- ----------------------------
ALTER TABLE [dbo].[sms_check_sku] ADD CONSTRAINT [PK__sms_chec__3213E83F9C0702E4] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_entry
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_entry]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_entry
-- ----------------------------
ALTER TABLE [dbo].[sms_entry] ADD CONSTRAINT [PK__sms_entr__3213E83F940188C9] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_entry_sku
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_entry_sku]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_entry_sku
-- ----------------------------
ALTER TABLE [dbo].[sms_entry_sku] ADD CONSTRAINT [PK__sms_entr__3213E83F0EB344A9] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_out
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_out]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_out
-- ----------------------------
ALTER TABLE [dbo].[sms_out] ADD CONSTRAINT [PK__sms_out__3213E83FFB057DE2] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sms_out_sku
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_out_sku]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_out_sku
-- ----------------------------
ALTER TABLE [dbo].[sms_out_sku] ADD CONSTRAINT [PK__sms_out___3213E83F995C96F3] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU] ADD CONSTRAINT [PK__SMS_SKU__3214EC270E5BFD34] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_ADDRESS
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ADDRESS] ADD CONSTRAINT [PK__SMS_SKU___3214EC27A87AE691] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_ATTR_VALUE
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ATTR_VALUE] ADD CONSTRAINT [PK__SMS_SKU___D458EB85DA171CE7] PRIMARY KEY CLUSTERED ([SKU_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_LOG
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_LOG] ADD CONSTRAINT [PK__SMS_SKU___3214EC273279DAFA] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_authority
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_authority]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_authority
-- ----------------------------
ALTER TABLE [dbo].[ums_authority] ADD CONSTRAINT [PK__ums_auth__3213E83F39C35174] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_role
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_role]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_role
-- ----------------------------
ALTER TABLE [dbo].[ums_role] ADD CONSTRAINT [PK__ums_role__3213E83F24E53FC8] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_role_authority
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_role_authority]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_role_authority
-- ----------------------------
ALTER TABLE [dbo].[ums_role_authority] ADD CONSTRAINT [PK__ums_role__3213E83FDC7588C6] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_user
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_user]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_user
-- ----------------------------
ALTER TABLE [dbo].[ums_user] ADD CONSTRAINT [PK__ums_user__3213E83F0A8AEAFB] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_user_info
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_user_info]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_user_info
-- ----------------------------
ALTER TABLE [dbo].[ums_user_info] ADD CONSTRAINT [PK__ums_user__3213E83F7619AD4D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ums_user_role
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ums_user_role]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table ums_user_role
-- ----------------------------
ALTER TABLE [dbo].[ums_user_role] ADD CONSTRAINT [PK__ums_user__3213E83F028639D1] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

