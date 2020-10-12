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

 Date: 12/10/2020 17:12:05
*/


-- ----------------------------
-- Table structure for CMS_CLIENT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CLIENT]') AND type IN ('U'))
	DROP TABLE [dbo].[CMS_CLIENT]
GO

CREATE TABLE [dbo].[CMS_CLIENT] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [COMPANY] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [ADDRESS] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL,
  [PHONE] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [CONTACT] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [EMAIL] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TYPE] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DESCRIPTION] varchar(1024) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[CMS_CLIENT] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'CMS_CLIENT',
'COLUMN', N'ID'
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
SET IDENTITY_INSERT [dbo].[CMS_CLIENT] ON
GO

SET IDENTITY_INSERT [dbo].[CMS_CLIENT] OFF
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
-- Table structure for sms_sku
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sms_sku]') AND type IN ('U'))
	DROP TABLE [dbo].[sms_sku]
GO

CREATE TABLE [dbo].[sms_sku] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [SkuName] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Type] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Brand] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Unit] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Number] int  NULL,
  [Price] decimal(18)  NULL,
  [Alarm] int  NULL,
  [Description] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCU] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [OCD] date  NULL,
  [LUU] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [LUD] date  NULL
)
GO

ALTER TABLE [dbo].[sms_sku] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sms_sku
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sms_sku] ON
GO

SET IDENTITY_INSERT [dbo].[sms_sku] OFF
GO


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
-- Auto increment value for CMS_CLIENT
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[CMS_CLIENT]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table CMS_CLIENT
-- ----------------------------
ALTER TABLE [dbo].[CMS_CLIENT] ADD CONSTRAINT [PK__mms_comp__3213E83F15CBBA15] PRIMARY KEY CLUSTERED ([ID])
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
-- Auto increment value for sms_sku
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sms_sku]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table sms_sku
-- ----------------------------
ALTER TABLE [dbo].[sms_sku] ADD CONSTRAINT [PK__sms_sku__3213E83FDB265B9C] PRIMARY KEY CLUSTERED ([id])
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

