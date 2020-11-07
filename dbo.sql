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

 Date: 07/11/2020 13:56:26
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
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'1717e42650d748c8b03d7fe87d217dc2', N'big1', NULL, NULL, N'2020-10-16 11:53:51.340', NULL, N'2020-10-29 14:57:26.857')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'2adfcc60118d4e1c9728e6af1a12eb44', N'primary', NULL, NULL, N'2020-10-16 15:44:50.703', NULL, N'2020-10-29 14:24:00.657')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'41ba7fcb9e284a57ab19049b7da06929', N'small', NULL, NULL, N'2020-10-16 11:54:36.947', NULL, N'2020-10-29 14:24:16.237')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'50c5766431a84356bec937d68ba560ce', N'mini', NULL, NULL, N'2020-10-16 10:29:33.193', NULL, N'2020-10-29 14:25:02.530')
GO

INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'a9e449814145492781f48d224cc2243e', N'string4', NULL, NULL, N'2020-10-16 09:40:43.077', NULL, N'2020-10-16 09:40:43.077')
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
INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'0d6f1ec8b8b14b5d9ed5194019c952ad', N'test1', NULL, N'a9e449814145492781f48d224cc2243e', NULL, N'2020-10-16 11:55:28.897', NULL, N'2020-10-29 14:54:43.163')
GO

INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'61d067af77db48858ac452c97009ddbd', N'string3', NULL, N'a9e449814145492781f48d224cc2243e', NULL, N'2020-10-16 11:55:38.870', NULL, N'2020-10-29 14:25:25.320')
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
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL
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
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [APPOINTMENT_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [COMPANY_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CAR_LICENSE] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [APPOINTMENT_DATE] datetime  NULL,
  [TYPE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PHONE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CONTACT] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [STATUS] int DEFAULT ((0)) NULL,
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
'MS_Description', N'预约编号: 预约年月日+公司编号(三位后三位（不足补）)+车牌后两位+当天公司维修次序（三位）',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'APPOINTMENT_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户公司',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'COMPANY_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'车牌号',
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
'MS_Description', N'预约日期',
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
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'PHONE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'MMS_APPOINTMENT',
'COLUMN', N'CONTACT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否取消，0未处理，1已处理，2取消',
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
'MS_Description', N'创建账号',
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
'MS_Description', N'最后更新账号',
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
INSERT INTO [dbo].[MMS_APPOINTMENT] ([ID], [APPOINTMENT_NO], [COMPANY_ID], [CAR_LICENSE], [DESCRIPTION], [APPOINTMENT_DATE], [TYPE], [PHONE], [CONTACT], [STATUS], [REMARK], [OCU], [OCD], [LUC], [LUD]) VALUES (N'0a3211611be24b878ff8390bdfef88b0', N'20201111dddss001', N'哒哒', N'粤B88888', N'爆胎', N'2020-11-11 16:00:00.000', N'大货车', N'123456789', N'张三', N'1', N'无', NULL, N'2020-11-05 13:17:04.877', NULL, N'2020-11-06 11:41:50.577')
GO


-- ----------------------------
-- Table structure for MMS_MAINTAIN
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MMS_MAINTAIN]') AND type IN ('U'))
	DROP TABLE [dbo].[MMS_MAINTAIN]
GO

CREATE TABLE [dbo].[MMS_MAINTAIN] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MAINTAIN_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [STAFF] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [APPOINTMENT_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [START_DATE] datetime  NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [RETURN_DATE] datetime  NULL,
  [OPERATOR] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[MMS_MAINTAIN] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'维修编号',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'MAINTAIN_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'员工',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'STAFF'
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联预约单',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'APPOINTMENT_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'开始时间',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'START_DATE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否已经签字完成，0没有，1处理完',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'归还时间',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'RETURN_DATE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'负责人',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN',
'COLUMN', N'OPERATOR'
GO


-- ----------------------------
-- Records of MMS_MAINTAIN
-- ----------------------------
INSERT INTO [dbo].[MMS_MAINTAIN] ([ID], [MAINTAIN_NO], [STAFF], [APPOINTMENT_ID], [START_DATE], [STATUS], [RETURN_DATE], [OPERATOR], [OCU], [OCD], [LUC], [LUD]) VALUES (N'bf0504f638044f818d68bb9f774ae7c5', N'string', N'string', N'string', N'2020-01-02 00:00:00.000', N'3', N'2020-01-02 00:00:00.000', N'string', NULL, N'2020-10-29 15:12:02.490', NULL, N'2020-10-29 15:12:02.490')
GO


-- ----------------------------
-- Table structure for MMS_MAINTAIN_OLDPART
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MMS_MAINTAIN_OLDPART]') AND type IN ('U'))
	DROP TABLE [dbo].[MMS_MAINTAIN_OLDPART]
GO

CREATE TABLE [dbo].[MMS_MAINTAIN_OLDPART] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MAINTAIN_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [NUM] int  NULL,
  [PRICE] decimal(18,2)  NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [REMARK] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DEAL_NUM] int DEFAULT ((0)) NULL
)
GO

ALTER TABLE [dbo].[MMS_MAINTAIN_OLDPART] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联维修单',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'MAINTAIN_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联库存，规格，品牌, 几成新，去设置spu，sku属性',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数量',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'NUM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'收购价',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否已经入库，0没有，1入库',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'REMARK'
GO

EXEC sp_addextendedproperty
'MS_Description', N'已经处理的数据',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_OLDPART',
'COLUMN', N'DEAL_NUM'
GO


-- ----------------------------
-- Records of MMS_MAINTAIN_OLDPART
-- ----------------------------
INSERT INTO [dbo].[MMS_MAINTAIN_OLDPART] ([ID], [MAINTAIN_ID], [SKU_ID], [NUM], [PRICE], [STATUS], [REMARK], [DEAL_NUM]) VALUES (N'1', N'sdsd', N'1', N'5', N'33.00', N'0', N'dfsd', N'3')
GO

INSERT INTO [dbo].[MMS_MAINTAIN_OLDPART] ([ID], [MAINTAIN_ID], [SKU_ID], [NUM], [PRICE], [STATUS], [REMARK], [DEAL_NUM]) VALUES (N'1077ea5d09064f568b2083af1e014415', N'bf0504f638044f818d68bb9f774ae7c5', N'string', N'3', NULL, N'2', N'string', N'3')
GO


-- ----------------------------
-- Table structure for MMS_MAINTAIN_OUT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MMS_MAINTAIN_OUT]') AND type IN ('U'))
	DROP TABLE [dbo].[MMS_MAINTAIN_OUT]
GO

CREATE TABLE [dbo].[MMS_MAINTAIN_OUT] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MAINTAIN_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OUT_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[MMS_MAINTAIN_OUT] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of MMS_MAINTAIN_OUT
-- ----------------------------
INSERT INTO [dbo].[MMS_MAINTAIN_OUT] ([ID], [MAINTAIN_ID], [OUT_ID]) VALUES (N'e9bc1816194a461dba5f46457e0c7eee', N'bf0504f638044f818d68bb9f774ae7c5', N'string')
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
-- Table structure for MMS_MAINTAIN_TOOL
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MMS_MAINTAIN_TOOL]') AND type IN ('U'))
	DROP TABLE [dbo].[MMS_MAINTAIN_TOOL]
GO

CREATE TABLE [dbo].[MMS_MAINTAIN_TOOL] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MAINTAIN_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OUT_SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DEAL_NUM] int DEFAULT ((0)) NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [REMARK] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [COMPENSATION] decimal(18,2)  NULL,
  [NUM] int  NULL
)
GO

ALTER TABLE [dbo].[MMS_MAINTAIN_TOOL] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联维修单',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'MAINTAIN_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联出库库存',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'OUT_SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'归还数量',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'DEAL_NUM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态，0没有解决，1已经解决',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'REMARK'
GO

EXEC sp_addextendedproperty
'MS_Description', N'赔偿金',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'COMPENSATION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数量',
'SCHEMA', N'dbo',
'TABLE', N'MMS_MAINTAIN_TOOL',
'COLUMN', N'NUM'
GO


-- ----------------------------
-- Records of MMS_MAINTAIN_TOOL
-- ----------------------------
INSERT INTO [dbo].[MMS_MAINTAIN_TOOL] ([ID], [MAINTAIN_ID], [OUT_SKU_ID], [DEAL_NUM], [STATUS], [REMARK], [COMPENSATION], [NUM]) VALUES (N'1', N'sds', N'dsdf', N'4', N'1', N'dfsdf', N'32.00', N'4')
GO

INSERT INTO [dbo].[MMS_MAINTAIN_TOOL] ([ID], [MAINTAIN_ID], [OUT_SKU_ID], [DEAL_NUM], [STATUS], [REMARK], [COMPENSATION], [NUM]) VALUES (N'8afbe615a3fc411984beeb92bd6d251e', N'bf0504f638044f818d68bb9f774ae7c5', N'string', N'3', N'3', N'string', N'2.00', N'3')
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
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'07bdae310ae0432eac760e04e7e824a6', N'0d6f1ec8b8b14b5d9ed5194019c952ad', NULL, N'test', N'test', NULL, N'11  5 2020  5:19PM', NULL, N'11  5 2020  5:19PM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'23477d9ce1144e80a18662b4886c6a1e', N'string2', NULL, N'string3', N'string', NULL, N'10 19 2020  4:48PM', NULL, N'11  5 2020 11:04AM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'994ec977cbee486497fdf69da2b639d7', N'61d067af77db48858ac452c97009ddbd', NULL, N'fxh', N'fxh', NULL, N'11  4 2020  1:21PM', NULL, N'11  4 2020  1:21PM')
GO

INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'd7ed3c8162cb41bb87073530891717e5', N'0d6f1ec8b8b14b5d9ed5194019c952ad', NULL, N'string2', N'string', NULL, N'10 19 2020  4:48PM', NULL, N'10 19 2020  4:48PM')
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
INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'288dd8bbc8784abc83933a76ddf47cf8', N'9f1d47e2cbbc477db6c1e4ecbbb862ba', N'994ec977cbee486497fdf69da2b639d7')
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
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'7c567ab6773b4cef975c5000bfdcfae1', N'288dd8bbc8784abc83933a76ddf47cf8', N'testfxh')
GO


-- ----------------------------
-- Table structure for SMS_CHECK
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_CHECK]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_CHECK]
GO

CREATE TABLE [dbo].[SMS_CHECK] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CHECK_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OPERATOR] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CHECK_DATE] datetime  NULL,
  [ACCOUNT_PRICE] decimal(20,2)  NULL,
  [CHECK_PRICE] decimal(20,2)  NULL,
  [DIFFERENCE_PRICE] decimal(20,2) DEFAULT ((0)) NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[SMS_CHECK] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'盘点单号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'CHECK_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作员',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'OPERATOR'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盘点日期',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'CHECK_DATE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'账面总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'ACCOUNT_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盘点总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'CHECK_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'相差总金额，正为多了，负为少了',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'DIFFERENCE_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否解决，0解决，1未解决',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK',
'COLUMN', N'STATUS'
GO


-- ----------------------------
-- Records of SMS_CHECK
-- ----------------------------
INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4c02a45dca9b49ed8f366eb0ad466294', N'20200130string23', N'string', N'2020-03-22 00:00:00.000', N'2.00', N'3.00', N'100.00', N'string', N'1', NULL, N'2020-10-26 14:11:05.607', NULL, N'2020-10-26 16:01:01.753')
GO

INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'5eff775c132a4a188dbec3e9b79b5404', N'20200130string', N'string', N'2020-01-30 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', NULL, N'2020-10-26 14:10:01.107', NULL, N'2020-10-26 14:10:01.107')
GO

INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'7077629c57604397a2d489675af0e3ba', N'20200123string23', N'string23', N'2020-01-23 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', NULL, N'2020-10-26 14:34:02.600', NULL, N'2020-10-26 14:34:02.600')
GO

INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'ecde2e9e62044324a4e2eef7dd97d742', N'20200124string23', N'string23', N'2020-01-24 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', NULL, N'2020-10-26 15:30:09.453', NULL, N'2020-10-26 15:30:09.453')
GO


-- ----------------------------
-- Table structure for SMS_CHECK_SKU
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_CHECK_SKU]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_CHECK_SKU]
GO

CREATE TABLE [dbo].[SMS_CHECK_SKU] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CHECK_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ADDRESS_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CHECK_NUM] int  NULL,
  [CHECK_PRICE] decimal(20,2)  NULL,
  [PRICE] decimal(20,2)  NULL,
  [ACCOUNT_NUM] int  NULL,
  [ACCOUNT_PRICE] decimal(20,2)  NULL,
  [DIFFERENCE_NUM] int DEFAULT ((0)) NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [STATUS] int DEFAULT ((0)) NOT NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DIFFERENCE_PRICE] decimal(20,2) DEFAULT ((0)) NULL
)
GO

ALTER TABLE [dbo].[SMS_CHECK_SKU] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联盘点表',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'CHECK_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'关联库存（位置）',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'ADDRESS_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盘点数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'CHECK_NUM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盘点总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'CHECK_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'当时单价',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'账面数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'ACCOUNT_NUM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'账面总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'ACCOUNT_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'相差数量，正多，负少',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'DIFFERENCE_NUM'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0已处理，1未处理',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'预留字段（冗余）',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'相差金额，正多，负少',
'SCHEMA', N'dbo',
'TABLE', N'SMS_CHECK_SKU',
'COLUMN', N'DIFFERENCE_PRICE'
GO


-- ----------------------------
-- Records of SMS_CHECK_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'2dbf845b918c48eba774d45f23a3c063', N'5eff775c132a4a188dbec3e9b79b5404', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', NULL, N'3.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'4c3a6985638346be9c1163f15dc4c36a', N'4c02a45dca9b49ed8f366eb0ad466294', N'string', N'100', N'100.00', N'100.00', N'100', N'100.00', N'100', N'string', N'1', NULL, N'100.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'5791d1a1ce1d457a9cd6d394af485821', N'7077629c57604397a2d489675af0e3ba', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', NULL, N'3.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'706156bd234743dbafe9e2739e25a0e9', N'7077629c57604397a2d489675af0e3ba', N'fsdf', N'33', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', NULL, N'3.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'8b4277f46ef64806aa38e2721a7d02b1', N'ecde2e9e62044324a4e2eef7dd97d742', N'fsdf', N'33', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', NULL, N'3.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'ef4aa024f9374019aaed9f25d3b2c6e6', N'ecde2e9e62044324a4e2eef7dd97d742', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', NULL, N'3.00')
GO

INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'Id', N'checkId', N'addressId', N'3', N'3.00', N'3.00', N'3', N'3.00', N'3', N'DESCRIPTION', N'1', N'SKU_ID', N'3.00')
GO


-- ----------------------------
-- Table structure for SMS_ENTRY
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_ENTRY]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_ENTRY]
GO

CREATE TABLE [dbo].[SMS_ENTRY] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ENTRY_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OPERATOR] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TOTAL_PRICE] decimal(18,2)  NULL,
  [ENTRY_DATE] datetime  NULL,
  [BATCH] int DEFAULT ((1)) NULL,
  [SUPPLIER_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL,
  [IS_MAINTAIN] int DEFAULT ((0)) NULL,
  [MAINTAIN_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SMS_ENTRY] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'入库编号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'ENTRY_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作员',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'OPERATOR'
GO

EXEC sp_addextendedproperty
'MS_Description', N'批次',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'BATCH'
GO

EXEC sp_addextendedproperty
'MS_Description', N'供应商',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'SUPPLIER_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0不是绑定维修单，1绑定维修单',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'IS_MAINTAIN'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定维修单',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY',
'COLUMN', N'MAINTAIN_ID'
GO


-- ----------------------------
-- Records of SMS_ENTRY
-- ----------------------------
INSERT INTO [dbo].[SMS_ENTRY] ([ID], [ENTRY_NO], [OPERATOR], [TOTAL_PRICE], [ENTRY_DATE], [BATCH], [SUPPLIER_ID], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [IS_MAINTAIN], [MAINTAIN_ID]) VALUES (N'99067c08f1ed4156b0aa8021c49ada32', N'20201101xxx02', N'xxx', N'4.00', N'2020-11-01 16:00:00.000', N'1', N'xxx', N'xxxx', NULL, N'2020-11-06 14:17:42.307', NULL, N'2020-11-07 10:32:11.610', NULL, NULL)
GO


-- ----------------------------
-- Table structure for SMS_ENTRY_SKU
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_ENTRY_SKU]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_ENTRY_SKU]
GO

CREATE TABLE [dbo].[SMS_ENTRY_SKU] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ENTRY_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [QUANTITY] int  NULL,
  [PRICE] decimal(18,2)  NULL,
  [TOTAL_PRICE] decimal(18,2)  NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [OLD_PARTID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ADDRESS_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SMS_ENTRY_SKU] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'入库单',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'ENTRY_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'QUANTITY'
GO

EXEC sp_addextendedproperty
'MS_Description', N'单价',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'总价',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'TOTAL_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0为新，1为旧',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'如果是旧，绑定旧来源',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'OLD_PARTID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'地址',
'SCHEMA', N'dbo',
'TABLE', N'SMS_ENTRY_SKU',
'COLUMN', N'ADDRESS_ID'
GO


-- ----------------------------
-- Records of SMS_ENTRY_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_ENTRY_SKU] ([ID], [ENTRY_ID], [SKU_ID], [QUANTITY], [PRICE], [TOTAL_PRICE], [STATUS], [OLD_PARTID], [ADDRESS_ID]) VALUES (N'26aee2957650444092d4c599575dc6fd', N'99067c08f1ed4156b0aa8021c49ada32', N'72a85844809945a481b85c0b72bd4113', N'1', N'4.00', N'4.00', N'0', N'', N'3009c45eeffa4cc6abea1054361a1e47')
GO


-- ----------------------------
-- Table structure for SMS_OUT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_OUT]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_OUT]
GO

CREATE TABLE [dbo].[SMS_OUT] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [OUT_NO] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OPERATOR] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OUT_DATE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TOTAL_PRICE] decimal(20,2)  NULL,
  [BATCH] int  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [CLIENT_ID] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] datetime  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] datetime  NULL
)
GO

ALTER TABLE [dbo].[SMS_OUT] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单号',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'OUT_NO'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作员',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'OPERATOR'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库日期',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'OUT_DATE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'TOTAL_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'批次',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'BATCH'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'DESCRIPTION'
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户ID',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT',
'COLUMN', N'CLIENT_ID'
GO


-- ----------------------------
-- Records of SMS_OUT
-- ----------------------------
INSERT INTO [dbo].[SMS_OUT] ([ID], [OUT_NO], [OPERATOR], [OUT_DATE], [TOTAL_PRICE], [BATCH], [DESCRIPTION], [CLIENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4544b43cc46d4e178a11d4f551581a28', N'20200430string06', N'string', N'04 30 2020 12:00AM', N'5.00', N'6', N'string', N'string', NULL, N'2020-10-22 16:18:10.170', NULL, N'2020-11-07 10:34:39.177')
GO


-- ----------------------------
-- Table structure for SMS_OUT_SKU
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_OUT_SKU]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_OUT_SKU]
GO

CREATE TABLE [dbo].[SMS_OUT_SKU] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [OUT_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [QUANTITY] int  NULL,
  [PRICE] decimal(18,2)  NULL,
  [TOTAL_PRICE] decimal(18,2)  NULL,
  [TOOL] int  NULL,
  [ADDRESS_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SMS_OUT_SKU] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单ID',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'OUT_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存ID',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'SKU_ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数量',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'QUANTITY'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单价',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'总金额',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'TOTAL_PRICE'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0是配件，1是工具',
'SCHEMA', N'dbo',
'TABLE', N'SMS_OUT_SKU',
'COLUMN', N'TOOL'
GO


-- ----------------------------
-- Records of SMS_OUT_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_OUT_SKU] ([ID], [OUT_ID], [SKU_ID], [QUANTITY], [PRICE], [TOTAL_PRICE], [TOOL], [ADDRESS_ID]) VALUES (N'55438db0f7084f4383cb1e2d30b20f61', N'4544b43cc46d4e178a11d4f551581a28', N'72a85844809945a481b85c0b72bd4113', N'1', N'5.00', N'5.00', N'0', N'3009c45eeffa4cc6abea1054361a1e47')
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
  [PRICE] decimal(20,2)  NULL,
  [UNIT] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TOTAL_COUNT] int  NULL,
  [ALARM] int  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [TOOL] int  NULL,
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
'MS_Description', N'参考单价',
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
'MS_Description', N'是否是工具，0为配件，1为工具（自己用）',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU',
'COLUMN', N'TOOL'
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
INSERT INTO [dbo].[SMS_SKU] ([ID], [SKU_NO], [SKU_NAME], [SPU_ID], [BRAND], [PRICE], [UNIT], [TOTAL_COUNT], [ALARM], [DESCRIPTION], [TOOL], [CATALOG2_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'72a85844809945a481b85c0b72bd4113', NULL, N'test', N'07bdae310ae0432eac760e04e7e824a6', N'ttttttttttttttttttttttt', N'1.00', NULL, N'0', N'1', N'ttttttttttttt', N'1', N'0d6f1ec8b8b14b5d9ed5194019c952ad', NULL, N'2020-11-05 17:28:16.557', NULL, N'2020-11-07 10:12:37.573')
GO


-- ----------------------------
-- Table structure for SMS_SKU_ADDRESS
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU_ADDRESS]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU_ADDRESS]
GO

CREATE TABLE [dbo].[SMS_SKU_ADDRESS] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS DEFAULT ((0)) NOT NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [QUANTITY] int DEFAULT ((0)) NULL,
  [STATUS] int DEFAULT ((0)) NULL,
  [OLD_PARTID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PRICE] decimal(18,2)  NULL
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

EXEC sp_addextendedproperty
'MS_Description', N'记录新旧，0新，1旧',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ADDRESS',
'COLUMN', N'STATUS'
GO

EXEC sp_addextendedproperty
'MS_Description', N'绑定旧来源',
'SCHEMA', N'dbo',
'TABLE', N'SMS_SKU_ADDRESS',
'COLUMN', N'OLD_PARTID'
GO


-- ----------------------------
-- Records of SMS_SKU_ADDRESS
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU_ADDRESS] ([ID], [SKU_ID], [ROOM], [SELF], [QUANTITY], [STATUS], [OLD_PARTID], [PRICE]) VALUES (N'3009c45eeffa4cc6abea1054361a1e47', N'72a85844809945a481b85c0b72bd4113', N'1', N'2', N'0', N'0', N'', N'.00')
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

-- ----------------------------
-- Table structure for SMS_SKU_LOG
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS_SKU_LOG]') AND type IN ('U'))
	DROP TABLE [dbo].[SMS_SKU_LOG]
GO

CREATE TABLE [dbo].[SMS_SKU_LOG] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SKU_ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OLD_QUANTITY] int  NULL,
  [OLD_ALARM] int  NULL,
  [OLD_PRICE] decimal(20,2)  NULL,
  [NEW_ROOM] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [NEW_SELF] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [NEW_QUANTITY] int  NULL,
  [NEW_PRICE] decimal(20,2)  NULL,
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
-- Table structure for UMS_USER
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UMS_USER]') AND type IN ('U'))
	DROP TABLE [dbo].[UMS_USER]
GO

CREATE TABLE [dbo].[UMS_USER] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [USER_NAME] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PWD] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SALT] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUC] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[UMS_USER] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户名',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'USER_NAME'
GO

EXEC sp_addextendedproperty
'MS_Description', N'密码',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'PWD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盐值',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'SALT'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'OCD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后更新时间',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'LUD'
GO

EXEC sp_addextendedproperty
'MS_Description', N'忽略',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'OCU'
GO

EXEC sp_addextendedproperty
'MS_Description', N'忽略',
'SCHEMA', N'dbo',
'TABLE', N'UMS_USER',
'COLUMN', N'LUC'
GO


-- ----------------------------
-- Records of UMS_USER
-- ----------------------------
INSERT INTO [dbo].[UMS_USER] ([ID], [USER_NAME], [PWD], [SALT], [OCD], [LUD], [OCU], [LUC]) VALUES (N'95cc0872c94942d5b4ca51e4d95c5cfa', N'string', N'string', NULL, N'11  4 2020  9:55AM', N'11  4 2020  9:55AM', NULL, NULL)
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
ALTER TABLE [dbo].[BMMS_CATALOG_ATTR] ADD CONSTRAINT [PK__BMMS_CAT__3214EC27C355B8E7] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG1
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG1] ADD CONSTRAINT [PK__BMMS_CAT__3214EC27313BD4E0] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG2
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG2] ADD CONSTRAINT [PK__BMMS_CAT__3214EC279A39DB63] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CMS_CLIENT
-- ----------------------------
ALTER TABLE [dbo].[CMS_CLIENT] ADD CONSTRAINT [PK__CMS_CLIE__3214EC27882E7A17] PRIMARY KEY CLUSTERED ([ID])
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
ALTER TABLE [dbo].[COMMON_TYPE] ADD CONSTRAINT [PK__COMMON_T__3214EC27BE33DF94] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MMS_APPOINTMENT
-- ----------------------------
ALTER TABLE [dbo].[MMS_APPOINTMENT] ADD CONSTRAINT [PK__MMS_APPO__3214EC27C7455D59] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN] ADD CONSTRAINT [PK__MMS_MAIN__3214EC27150A18B5] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OLDPART
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_OLDPART] ADD CONSTRAINT [PK__MMS_MAIN__3214EC27F2E5CC35] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OUT
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_OUT] ADD CONSTRAINT [PK__MMS_MAIN__3214EC279EFDD47E] PRIMARY KEY CLUSTERED ([ID])
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
ALTER TABLE [dbo].[mms_maintain_sku] ADD CONSTRAINT [PK__mms_main__3213E83F57789110] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_TOOL
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_TOOL] ADD CONSTRAINT [PK__MMS_MAIN__3214EC2700AEA867] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PMS_SPU
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU] ADD CONSTRAINT [PK__PMS_SPU__3214EC27826A7BFA] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PMS_SPU_ATTR
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU_ATTR] ADD CONSTRAINT [PK__PMS_SPU___3214EC27624AD5F9] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_CHECK
-- ----------------------------
ALTER TABLE [dbo].[SMS_CHECK] ADD CONSTRAINT [PK__SMS_CHEC__3214EC27D875FA34] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_CHECK_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_CHECK_SKU] ADD CONSTRAINT [PK__SMS_CHEC__3214EC2758A54FD1] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_ENTRY
-- ----------------------------
ALTER TABLE [dbo].[SMS_ENTRY] ADD CONSTRAINT [PK__SMS_ENTR__3214EC275075CEEE] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_ENTRY_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_ENTRY_SKU] ADD CONSTRAINT [PK__SMS_ENTR__3214EC271760610C] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_OUT
-- ----------------------------
ALTER TABLE [dbo].[SMS_OUT] ADD CONSTRAINT [PK__SMS_OUT__3214EC27642E3EAE] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_OUT_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_OUT_SKU] ADD CONSTRAINT [PK__SMS_OUT___3214EC27BBDC66B2] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU] ADD CONSTRAINT [PK__SMS_SKU__3214EC273EF09F71] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_ADDRESS
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ADDRESS] ADD CONSTRAINT [PK__SMS_SKU___3214EC276D2379D3] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_ATTR_VALUE
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ATTR_VALUE] ADD CONSTRAINT [PK__SMS_SKU___4BB929BA97D26CF4] PRIMARY KEY CLUSTERED ([SKU_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SMS_SKU_LOG
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_LOG] ADD CONSTRAINT [PK__SMS_SKU___3214EC278D767B8B] PRIMARY KEY CLUSTERED ([ID])
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
ALTER TABLE [dbo].[ums_authority] ADD CONSTRAINT [PK__ums_auth__3213E83F1C913B80] PRIMARY KEY CLUSTERED ([id])
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
ALTER TABLE [dbo].[ums_role] ADD CONSTRAINT [PK__ums_role__3213E83F5EA1640F] PRIMARY KEY CLUSTERED ([id])
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
ALTER TABLE [dbo].[ums_role_authority] ADD CONSTRAINT [PK__ums_role__3213E83FBBE23245] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UMS_USER
-- ----------------------------
ALTER TABLE [dbo].[UMS_USER] ADD CONSTRAINT [PK__UMS_USER__3214EC274C1C5E4C] PRIMARY KEY CLUSTERED ([ID])
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
ALTER TABLE [dbo].[ums_user_info] ADD CONSTRAINT [PK__ums_user__3213E83F9E43C267] PRIMARY KEY CLUSTERED ([id])
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
ALTER TABLE [dbo].[ums_user_role] ADD CONSTRAINT [PK__ums_user__3213E83FC26A922B] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

