/*
Navicat SQL Server Data Transfer

Source Server         : SqlServerLocal
Source Server Version : 140000
Source Host           : 127.0.0.1:1433
Source Database       : maintain
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 140000
File Encoding         : 65001

Date: 2020-10-28 21:06:48
*/


-- ----------------------------
-- Table structure for BMMS_CATALOG_ATTR
-- ----------------------------
DROP TABLE [dbo].[BMMS_CATALOG_ATTR]
GO
CREATE TABLE [dbo].[BMMS_CATALOG_ATTR] (
[ID] varchar(50) NOT NULL ,
[ATTR_NAME] varchar(255) NULL ,
[CATALOG_ID] varchar(50) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO

-- ----------------------------
-- Records of BMMS_CATALOG_ATTR
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4cccb814186147768c7029cfb76194a9', N'string', N'e833bf95f28c4f8e82e8f61e94b0908e', null, N'2020-10-16 10:30:58.420', null, N'2020-10-16 10:30:58.420')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'9f1d47e2cbbc477db6c1e4ecbbb862ba', N'string', N'61d067af77db48858ac452c97009ddbd', null, N'2020-10-16 11:56:37.043', null, N'2020-10-16 11:56:37.043')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG_ATTR] ([ID], [ATTR_NAME], [CATALOG_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'df6afd21adc541e08c15711ca3afe15d', N'string2', N'e833bf95f28c4f8e82e8f61e94b0908e', null, N'2020-10-16 10:31:01.633', null, N'2020-10-16 10:31:01.633')
GO
GO

-- ----------------------------
-- Table structure for BMMS_CATALOG1
-- ----------------------------
DROP TABLE [dbo].[BMMS_CATALOG1]
GO
CREATE TABLE [dbo].[BMMS_CATALOG1] (
[ID] varchar(50) NOT NULL ,
[CATALOG_NAME] varchar(255) NULL ,
[DESCRIPTION] varchar(255) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO

-- ----------------------------
-- Records of BMMS_CATALOG1
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'1717e42650d748c8b03d7fe87d217dc2', N'小明2', null, null, N'2020-10-16 11:53:51.340', null, N'2020-10-16 11:53:51.340')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'2adfcc60118d4e1c9728e6af1a12eb44', N'小明hh22', null, null, N'2020-10-16 15:44:50.703', null, N'2020-10-16 15:44:50.703')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'41ba7fcb9e284a57ab19049b7da06929', N'string1', null, null, N'2020-10-16 11:54:36.947', null, N'2020-10-16 11:54:36.947')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'50c5766431a84356bec937d68ba560ce', N'小明', null, null, N'2020-10-16 10:29:33.193', null, N'2020-10-16 10:29:52.937')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'a9e449814145492781f48d224cc2243e', N'string4', null, null, N'2020-10-16 09:40:43.077', null, N'2020-10-16 09:40:43.077')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'b67d9cb109b5419fa556242e7e56bfed', N'小明22', null, null, N'2020-10-16 11:54:04.143', null, N'2020-10-16 11:54:04.143')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'bc639ceebbfd4859981a5757c0171916', N'string5', null, null, N'2020-10-16 09:40:43.077', null, N'2020-10-16 09:40:43.077')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG1] ([ID], [CATALOG_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'e3c426eb6a544b3f8937c42c3803a5ed', N'string2', null, null, N'2020-10-16 11:54:36.947', null, N'2020-10-16 11:54:36.947')
GO
GO

-- ----------------------------
-- Table structure for BMMS_CATALOG2
-- ----------------------------
DROP TABLE [dbo].[BMMS_CATALOG2]
GO
CREATE TABLE [dbo].[BMMS_CATALOG2] (
[ID] varchar(50) NOT NULL ,
[CATALOG_NAME] varchar(255) NULL ,
[DESCRIPTION] varchar(255) NULL ,
[PARENT_ID] varchar(50) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO

-- ----------------------------
-- Records of BMMS_CATALOG2
-- ----------------------------
INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'0d6f1ec8b8b14b5d9ed5194019c952ad', N'string', null, N'a9e449814145492781f48d224cc2243e', null, N'2020-10-16 11:55:28.897', null, N'2020-10-16 11:55:28.897')
GO
GO
INSERT INTO [dbo].[BMMS_CATALOG2] ([ID], [CATALOG_NAME], [DESCRIPTION], [PARENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'61d067af77db48858ac452c97009ddbd', N'string3', null, N'a9e449814145492781f48d224cc2243e', null, N'2020-10-16 11:55:38.870', null, N'2020-10-16 11:55:38.870')
GO
GO

-- ----------------------------
-- Table structure for CMS_CLIENT
-- ----------------------------
DROP TABLE [dbo].[CMS_CLIENT]
GO
CREATE TABLE [dbo].[CMS_CLIENT] (
[COMPANY] varchar(30) NULL ,
[ADDRESS] varchar(1024) NULL ,
[PHONE] varchar(20) NULL ,
[CONTACT] varchar(30) NULL ,
[EMAIL] varchar(255) NULL ,
[TYPE] varchar(255) NULL ,
[DESCRIPTION] varchar(1024) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL ,
[ID] varchar(50) NOT NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'COMPANY')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'公司名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'COMPANY'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'公司名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'COMPANY'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'ADDRESS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'公司地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'ADDRESS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'公司地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'ADDRESS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'PHONE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'PHONE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'PHONE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'CONTACT')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'CONTACT'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'CONTACT'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'EMAIL')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'邮箱'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'EMAIL'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'邮箱'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'EMAIL'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'TYPE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'车型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'TYPE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'车型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'TYPE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'CMS_CLIENT', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'描述/备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'描述/备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'CMS_CLIENT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO

-- ----------------------------
-- Records of CMS_CLIENT
-- ----------------------------
INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'string', N'string', N'string', N'string', N'string', N'string', N'string', null, N'2020-10-14 10:31:54.267', null, N'2020-10-14 10:31:54.267', N'3c0495a3b676483f91fd94f8a64270a8')
GO
GO
INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'xiao', N'dsf', N'dd', null, N'dd', N'dd', N'xiao', null, N'2020-10-13 16:08:46.050', null, N'2020-10-13 16:53:38.847', N'a52232aea81d4b37bed1006fccd76557')
GO
GO
INSERT INTO [dbo].[CMS_CLIENT] ([COMPANY], [ADDRESS], [PHONE], [CONTACT], [EMAIL], [TYPE], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD], [ID]) VALUES (N'xx', N'dd', N'fdf', N'dfs', N'ee', N'ee', N'dfs', null, N'2020-10-13 14:47:23.747', null, N'2020-10-13 14:47:23.747', N'c9b6cfd49d024ba583418f4dd41a059a')
GO
GO

-- ----------------------------
-- Table structure for COMMON_TYPE
-- ----------------------------
DROP TABLE [dbo].[COMMON_TYPE]
GO
CREATE TABLE [dbo].[COMMON_TYPE] (
[ID] int NOT NULL IDENTITY(1,1) ,
[TYPE_NO] int NULL ,
[TITLE] varchar(30) NULL ,
[TYPE_NAME] varchar(50) NULL ,
[DESCRIPTION] varchar(255) NULL 
)


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
DROP TABLE [dbo].[MMS_APPOINTMENT]
GO
CREATE TABLE [dbo].[MMS_APPOINTMENT] (
[ID] varchar(50) NOT NULL ,
[APPOINTMENT_NO] varchar(50) NULL ,
[COMPANY_ID] varchar(50) NULL ,
[CAR_LICENSE] varchar(20) NULL ,
[DESCRIPTION] varchar(1024) NULL ,
[APPOINTMENT_DATE] datetime NULL ,
[TYPE] varchar(255) NULL ,
[PHONE] varchar(255) NULL ,
[CONTACT] varchar(255) NULL ,
[STATUS] int NULL DEFAULT ((0)) ,
[REMARK] varchar(1024) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'APPOINTMENT_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'预约编号: 预约年月日+公司编号(三位后三位（不足补）)+车牌后两位+当天公司维修次序（三位）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'预约编号: 预约年月日+公司编号(三位后三位（不足补）)+车牌后两位+当天公司维修次序（三位）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'COMPANY_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'客户公司'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'COMPANY_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'客户公司'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'COMPANY_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'CAR_LICENSE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'车牌号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'CAR_LICENSE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'车牌号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'CAR_LICENSE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'问题描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'问题描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'APPOINTMENT_DATE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'预约日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_DATE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'预约日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_DATE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'TYPE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'车型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'TYPE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'车型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'TYPE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'PHONE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'PHONE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'PHONE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'CONTACT')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'CONTACT'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'CONTACT'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否取消，0未处理，1已处理，2取消'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否取消，0未处理，1已处理，2取消'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'REMARK')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'REMARK'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'REMARK'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'OCU')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'OCU'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'OCU'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'OCD')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'OCD'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'OCD'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'LUC')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后更新账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'LUC'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后更新账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'LUC'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_APPOINTMENT', 
'COLUMN', N'LUD')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'LUD'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_APPOINTMENT'
, @level2type = 'COLUMN', @level2name = N'LUD'
GO

-- ----------------------------
-- Records of MMS_APPOINTMENT
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN
-- ----------------------------
DROP TABLE [dbo].[MMS_MAINTAIN]
GO
CREATE TABLE [dbo].[MMS_MAINTAIN] (
[ID] varchar(50) NOT NULL ,
[MAINTAIN_NO] varchar(50) NULL ,
[STAFF] varchar(1024) NULL ,
[APPOINTMENT_ID] varchar(50) NULL ,
[START_DATE] datetime NULL ,
[STATUS] int NULL DEFAULT ((0)) ,
[RETURN_DATE] datetime NULL ,
[OPERATOR] varchar(255) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'MAINTAIN_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'维修编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'维修编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'STAFF')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'员工'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'STAFF'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'员工'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'STAFF'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'APPOINTMENT_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联预约单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联预约单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'APPOINTMENT_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'START_DATE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'START_DATE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'START_DATE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经签字完成，0没有，1处理完'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经签字完成，0没有，1处理完'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'RETURN_DATE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'归还时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'RETURN_DATE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'归还时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'RETURN_DATE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN', 
'COLUMN', N'OPERATOR')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'负责人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'负责人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
GO

-- ----------------------------
-- Records of MMS_MAINTAIN
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN_OLDPART
-- ----------------------------
DROP TABLE [dbo].[MMS_MAINTAIN_OLDPART]
GO
CREATE TABLE [dbo].[MMS_MAINTAIN_OLDPART] (
[ID] varchar(50) NOT NULL ,
[MAINTAIN_ID] varchar(50) NULL ,
[SKU_ID] varchar(50) NULL ,
[NUM] int NULL ,
[PRICE] decimal(18,2) NULL ,
[STATUS] int NULL DEFAULT ((0)) ,
[REMARK] varchar(255) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'MAINTAIN_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联维修单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联维修单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联库存，规格，品牌, 几成新，去设置spu，sku属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联库存，规格，品牌, 几成新，去设置spu，sku属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'NUM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'NUM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'NUM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收购价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收购价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经入库，0没有，1入库'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经入库，0没有，1入库'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_OLDPART', 
'COLUMN', N'REMARK')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'REMARK'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_OLDPART'
, @level2type = 'COLUMN', @level2name = N'REMARK'
GO

-- ----------------------------
-- Records of MMS_MAINTAIN_OLDPART
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN_OUT
-- ----------------------------
DROP TABLE [dbo].[MMS_MAINTAIN_OUT]
GO
CREATE TABLE [dbo].[MMS_MAINTAIN_OUT] (
[ID] varchar(50) NOT NULL ,
[MAINTAIN_ID] varchar(50) NULL ,
[OUT_ID] varchar(50) NULL 
)


GO

-- ----------------------------
-- Records of MMS_MAINTAIN_OUT
-- ----------------------------

-- ----------------------------
-- Table structure for mms_maintain_sku
-- ----------------------------
DROP TABLE [dbo].[mms_maintain_sku]
GO
CREATE TABLE [dbo].[mms_maintain_sku] (
[id] int NOT NULL IDENTITY(1,1) ,
[SkuId] int NULL ,
[Price] decimal(18) NULL ,
[Number] int NULL ,
[MaintainId] int NULL 
)


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
DROP TABLE [dbo].[MMS_MAINTAIN_TOOL]
GO
CREATE TABLE [dbo].[MMS_MAINTAIN_TOOL] (
[ID] varchar(50) NOT NULL ,
[MAINTAIN_ID] varchar(50) NULL ,
[OUT_SKU_ID] varchar(50) NULL ,
[RETURN_NUM] int NULL DEFAULT ((0)) ,
[STATUS] int NULL DEFAULT ((0)) ,
[REMARK] varchar(1024) NULL ,
[COMPENSATION] decimal(18,2) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'MAINTAIN_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联维修单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联维修单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'MAINTAIN_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'OUT_SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联出库库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'OUT_SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联出库库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'OUT_SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'RETURN_NUM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'归还数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'RETURN_NUM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'归还数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'RETURN_NUM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'状态，0没有解决，1已经解决'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'状态，0没有解决，1已经解决'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'REMARK')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'REMARK'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'REMARK'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'MMS_MAINTAIN_TOOL', 
'COLUMN', N'COMPENSATION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'赔偿金'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'COMPENSATION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'赔偿金'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'MMS_MAINTAIN_TOOL'
, @level2type = 'COLUMN', @level2name = N'COMPENSATION'
GO

-- ----------------------------
-- Records of MMS_MAINTAIN_TOOL
-- ----------------------------

-- ----------------------------
-- Table structure for PMS_SPU
-- ----------------------------
DROP TABLE [dbo].[PMS_SPU]
GO
CREATE TABLE [dbo].[PMS_SPU] (
[ID] varchar(50) NOT NULL ,
[CATALOG2_ID] varchar(50) NULL ,
[SPU_NO] varchar(50) NULL ,
[PRODUCT_NAME] varchar(255) NULL ,
[DESCRIPTION] varchar(255) NULL ,
[OCU] varchar(255) NULL ,
[OCD] varchar(255) NULL ,
[LUC] varchar(255) NULL ,
[LUD] varchar(255) NULL 
)


GO

-- ----------------------------
-- Records of PMS_SPU
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'23477d9ce1144e80a18662b4886c6a1e', N'string2', null, N'string3', N'string', null, N'10 19 2020  4:48PM', null, N'10 19 2020  4:48PM')
GO
GO
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'3d5cae2ab2914ab9ab8a1ac308e6ed0d', N'string', null, N'string', N'string', null, N'10 19 2020  4:23PM', null, N'10 19 2020  4:23PM')
GO
GO
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'd7ed3c8162cb41bb87073530891717e5', N'string2', null, N'string2', N'string', null, N'10 19 2020  4:48PM', null, N'10 19 2020  4:48PM')
GO
GO
INSERT INTO [dbo].[PMS_SPU] ([ID], [CATALOG2_ID], [SPU_NO], [PRODUCT_NAME], [DESCRIPTION], [OCU], [OCD], [LUC], [LUD]) VALUES (N'df28ab9c0fb5413db5436e69dac9d00c', N'string', null, N'你好吗', N'string', null, N'10 20 2020  9:09AM', null, N'10 20 2020  9:09AM')
GO
GO

-- ----------------------------
-- Table structure for PMS_SPU_ATTR
-- ----------------------------
DROP TABLE [dbo].[PMS_SPU_ATTR]
GO
CREATE TABLE [dbo].[PMS_SPU_ATTR] (
[ID] varchar(50) NOT NULL ,
[ATTR_ID] varchar(50) NULL ,
[SPU_ID] varchar(50) NULL 
)


GO

-- ----------------------------
-- Records of PMS_SPU_ATTR
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'1', N'9f1d47e2cbbc477db6c1e4ecbbb862ba', N'23477d9ce1144e80a18662b4886c6a1e')
GO
GO
INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'1bc92de23a50488c82099d85bc2fbdcf', N'string', N'df28ab9c0fb5413db5436e69dac9d00c')
GO
GO
INSERT INTO [dbo].[PMS_SPU_ATTR] ([ID], [ATTR_ID], [SPU_ID]) VALUES (N'43bd668189094108bffc3af7640a6c7a', N'df6afd21adc541e08c15711ca3afe15d', N'3d5cae2ab2914ab9ab8a1ac308e6ed0d')
GO
GO

-- ----------------------------
-- Table structure for PMS_SPU_ATTR_VALUE
-- ----------------------------
DROP TABLE [dbo].[PMS_SPU_ATTR_VALUE]
GO
CREATE TABLE [dbo].[PMS_SPU_ATTR_VALUE] (
[ID] varchar(50) NULL ,
[SPU_ATTR_ID] varchar(50) NULL ,
[VALUE] varchar(255) NULL 
)


GO

-- ----------------------------
-- Records of PMS_SPU_ATTR_VALUE
-- ----------------------------
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'1', N'1', N'xx')
GO
GO
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'2', N'1', N'dd')
GO
GO
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'5f6786704aad4f59bfd73ce9cf068078', N'43bd668189094108bffc3af7640a6c7a', N'string')
GO
GO
INSERT INTO [dbo].[PMS_SPU_ATTR_VALUE] ([ID], [SPU_ATTR_ID], [VALUE]) VALUES (N'6d376bdf512e4ae8b35ac529e1b17df3', N'1bc92de23a50488c82099d85bc2fbdcf', N'string')
GO
GO

-- ----------------------------
-- Table structure for SMS_CHECK
-- ----------------------------
DROP TABLE [dbo].[SMS_CHECK]
GO
CREATE TABLE [dbo].[SMS_CHECK] (
[ID] varchar(50) NOT NULL ,
[CHECK_NO] varchar(50) NULL ,
[OPERATOR] varchar(255) NULL ,
[CHECK_DATE] datetime NULL ,
[ACCOUNT_PRICE] decimal(20,2) NULL ,
[CHECK_PRICE] decimal(20,2) NULL ,
[DIFFERENCE_PRICE] decimal(20,2) NULL DEFAULT ((0)) ,
[DESCRIPTION] varchar(1024) NULL ,
[STATUS] int NULL DEFAULT ((0)) ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'CHECK_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'盘点单号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'盘点单号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'OPERATOR')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'CHECK_DATE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'盘点日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_DATE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'盘点日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_DATE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'ACCOUNT_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账面总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账面总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'CHECK_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'盘点总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'盘点总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'CHECK_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'DIFFERENCE_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相差总金额，正为多了，负为少了'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相差总金额，正为多了，负为少了'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否解决，0解决，1未解决'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否解决，0解决，1未解决'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO

-- ----------------------------
-- Records of SMS_CHECK
-- ----------------------------
INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4c02a45dca9b49ed8f366eb0ad466294', N'20200130string23', N'string', N'2020-03-22 00:00:00.000', N'2.00', N'3.00', N'100.00', N'string', N'1', null, N'2020-10-26 14:11:05.607', null, N'2020-10-26 16:01:01.753')
GO
GO
INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'5eff775c132a4a188dbec3e9b79b5404', N'20200130string', N'string', N'2020-01-30 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', null, N'2020-10-26 14:10:01.107', null, N'2020-10-26 14:10:01.107')
GO
GO
INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'7077629c57604397a2d489675af0e3ba', N'20200123string23', N'string23', N'2020-01-23 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', null, N'2020-10-26 14:34:02.600', null, N'2020-10-26 14:34:02.600')
GO
GO
INSERT INTO [dbo].[SMS_CHECK] ([ID], [CHECK_NO], [OPERATOR], [CHECK_DATE], [ACCOUNT_PRICE], [CHECK_PRICE], [DIFFERENCE_PRICE], [DESCRIPTION], [STATUS], [OCU], [OCD], [LUC], [LUD]) VALUES (N'ecde2e9e62044324a4e2eef7dd97d742', N'20200124string23', N'string23', N'2020-01-24 00:00:00.000', N'3.00', N'2.00', N'3.00', N'string', N'1', null, N'2020-10-26 15:30:09.453', null, N'2020-10-26 15:30:09.453')
GO
GO

-- ----------------------------
-- Table structure for SMS_CHECK_SKU
-- ----------------------------
DROP TABLE [dbo].[SMS_CHECK_SKU]
GO
CREATE TABLE [dbo].[SMS_CHECK_SKU] (
[ID] varchar(50) NOT NULL ,
[CHECK_ID] varchar(50) NULL ,
[ADDRESS_ID] varchar(50) NULL ,
[CHECK_NUM] int NULL ,
[CHECK_PRICE] decimal(20,2) NULL ,
[PRICE] decimal(20,2) NULL ,
[ACCOUNT_NUM] int NULL ,
[ACCOUNT_PRICE] decimal(20,2) NULL ,
[DIFFERENCE_NUM] int NULL DEFAULT ((0)) ,
[DESCRIPTION] varchar(1024) NULL ,
[STATUS] int NOT NULL DEFAULT ((0)) ,
[SKU_ID] varchar(50) NULL ,
[DIFFERENCE_PRICE] decimal(20,2) NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'CHECK_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联盘点表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联盘点表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'ADDRESS_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联库存（位置）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ADDRESS_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联库存（位置）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ADDRESS_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'CHECK_NUM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'盘点数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_NUM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'盘点数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_NUM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'CHECK_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'盘点总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'盘点总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'CHECK_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当时单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当时单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'ACCOUNT_NUM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账面数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_NUM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账面数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_NUM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'ACCOUNT_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账面总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账面总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'ACCOUNT_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'DIFFERENCE_NUM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相差数量，正多，负少'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_NUM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相差数量，正多，负少'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_NUM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'0已处理，1未处理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'0已处理，1未处理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'预留字段（冗余）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'预留字段（冗余）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_CHECK_SKU', 
'COLUMN', N'DIFFERENCE_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相差金额，正多，负少'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相差金额，正多，负少'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_CHECK_SKU'
, @level2type = 'COLUMN', @level2name = N'DIFFERENCE_PRICE'
GO

-- ----------------------------
-- Records of SMS_CHECK_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'2dbf845b918c48eba774d45f23a3c063', N'5eff775c132a4a188dbec3e9b79b5404', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', null, N'3.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'4c3a6985638346be9c1163f15dc4c36a', N'4c02a45dca9b49ed8f366eb0ad466294', N'string', N'100', N'100.00', N'100.00', N'100', N'100.00', N'100', N'string', N'1', null, N'100.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'5791d1a1ce1d457a9cd6d394af485821', N'7077629c57604397a2d489675af0e3ba', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', null, N'3.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'706156bd234743dbafe9e2739e25a0e9', N'7077629c57604397a2d489675af0e3ba', N'fsdf', N'33', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', null, N'3.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'8b4277f46ef64806aa38e2721a7d02b1', N'ecde2e9e62044324a4e2eef7dd97d742', N'fsdf', N'33', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', null, N'3.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'ef4aa024f9374019aaed9f25d3b2c6e6', N'ecde2e9e62044324a4e2eef7dd97d742', N'string', N'3', N'5.00', N'2.00', N'1', N'3.00', N'1', N'string', N'1', null, N'3.00')
GO
GO
INSERT INTO [dbo].[SMS_CHECK_SKU] ([ID], [CHECK_ID], [ADDRESS_ID], [CHECK_NUM], [CHECK_PRICE], [PRICE], [ACCOUNT_NUM], [ACCOUNT_PRICE], [DIFFERENCE_NUM], [DESCRIPTION], [STATUS], [SKU_ID], [DIFFERENCE_PRICE]) VALUES (N'Id', N'checkId', N'addressId', N'3', N'3.00', N'3.00', N'3', N'3.00', N'3', N'DESCRIPTION', N'1', N'SKU_ID', N'3.00')
GO
GO

-- ----------------------------
-- Table structure for SMS_ENTRY
-- ----------------------------
DROP TABLE [dbo].[SMS_ENTRY]
GO
CREATE TABLE [dbo].[SMS_ENTRY] (
[ID] varchar(50) NOT NULL ,
[ENTRY_NO] varchar(50) NULL ,
[OPERATOR] varchar(255) NULL ,
[TOTAL_PRICE] decimal(18,2) NULL ,
[ENTRY_DATE] datetime NULL ,
[BATCH] int NULL DEFAULT ((1)) ,
[SUPPLIER_ID] varchar(50) NULL ,
[DESCRIPTION] varchar(255) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY', 
'COLUMN', N'ENTRY_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'入库编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'ENTRY_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'入库编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'ENTRY_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY', 
'COLUMN', N'OPERATOR')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY', 
'COLUMN', N'BATCH')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'批次'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'BATCH'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'批次'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'BATCH'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY', 
'COLUMN', N'SUPPLIER_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'SUPPLIER_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'SUPPLIER_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO

-- ----------------------------
-- Records of SMS_ENTRY
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_ENTRY_SKU
-- ----------------------------
DROP TABLE [dbo].[SMS_ENTRY_SKU]
GO
CREATE TABLE [dbo].[SMS_ENTRY_SKU] (
[ID] varchar(50) NOT NULL ,
[ENTRY_ID] varchar(50) NULL ,
[SKU_ID] varchar(50) NULL ,
[QUANTITY] int NULL ,
[PRICE] decimal(18,2) NULL ,
[TOTAL_PRICE] decimal(18,2) NULL ,
[STATUS] int NULL DEFAULT ((0)) ,
[OLD_PARTID] varchar(50) NULL ,
[ADDRESS_ID] varchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'ENTRY_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'入库单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'ENTRY_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'入库单'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'ENTRY_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'QUANTITY')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'TOTAL_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'总价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'总价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'0为新，1为旧'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'0为新，1为旧'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'OLD_PARTID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'如果是旧，绑定旧来源'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'OLD_PARTID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'如果是旧，绑定旧来源'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'OLD_PARTID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_ENTRY_SKU', 
'COLUMN', N'ADDRESS_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'ADDRESS_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_ENTRY_SKU'
, @level2type = 'COLUMN', @level2name = N'ADDRESS_ID'
GO

-- ----------------------------
-- Records of SMS_ENTRY_SKU
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_OUT
-- ----------------------------
DROP TABLE [dbo].[SMS_OUT]
GO
CREATE TABLE [dbo].[SMS_OUT] (
[ID] varchar(50) NOT NULL ,
[OUT_NO] varchar(50) NULL ,
[OPERATOR] varchar(255) NULL ,
[OUT_DATE] varchar(255) NULL ,
[TOTAL_PRICE] decimal(20,2) NULL ,
[BATCH] int NULL ,
[DESCRIPTION] varchar(1024) NULL ,
[CLIENT_ID] varchar(255) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'OUT_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'出库单号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OUT_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'出库单号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OUT_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'OPERATOR')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OPERATOR'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'OUT_DATE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'出库日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OUT_DATE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'出库日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'OUT_DATE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'TOTAL_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'BATCH')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'批次'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'BATCH'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'批次'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'BATCH'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT', 
'COLUMN', N'CLIENT_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'客户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'CLIENT_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'客户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT'
, @level2type = 'COLUMN', @level2name = N'CLIENT_ID'
GO

-- ----------------------------
-- Records of SMS_OUT
-- ----------------------------
INSERT INTO [dbo].[SMS_OUT] ([ID], [OUT_NO], [OPERATOR], [OUT_DATE], [TOTAL_PRICE], [BATCH], [DESCRIPTION], [CLIENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'446902cb3b8744c9b5fbb3c41b602f99', N'string', N'string', N'04 30 2020 12:00AM', N'2.00', N'1', N'string', N'string', null, N'2020-10-22 16:12:41.847', null, N'2020-10-22 16:12:41.847')
GO
GO
INSERT INTO [dbo].[SMS_OUT] ([ID], [OUT_NO], [OPERATOR], [OUT_DATE], [TOTAL_PRICE], [BATCH], [DESCRIPTION], [CLIENT_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'4544b43cc46d4e178a11d4f551581a28', N'20200430string06', N'string', N'04 30 2020 12:00AM', N'4.00', N'6', N'string', N'string', null, N'2020-10-22 16:18:10.170', null, N'2020-10-22 16:18:10.170')
GO
GO

-- ----------------------------
-- Table structure for SMS_OUT_SKU
-- ----------------------------
DROP TABLE [dbo].[SMS_OUT_SKU]
GO
CREATE TABLE [dbo].[SMS_OUT_SKU] (
[ID] varchar(50) NOT NULL ,
[OUT_ID] varchar(50) NULL ,
[SKU_ID] varchar(50) NULL ,
[QUANTITY] int NULL ,
[PRICE] decimal(18,2) NULL ,
[TOTAL_PRICE] decimal(18,2) NULL ,
[TOOL] int NULL ,
[ADDRESS_ID] varchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'OUT_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'出库单ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'OUT_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'出库单ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'OUT_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'QUANTITY')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'出库单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'出库单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'TOTAL_PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'总金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_OUT_SKU', 
'COLUMN', N'TOOL')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'0是配件，1是工具'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'TOOL'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'0是配件，1是工具'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_OUT_SKU'
, @level2type = 'COLUMN', @level2name = N'TOOL'
GO

-- ----------------------------
-- Records of SMS_OUT_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_OUT_SKU] ([ID], [OUT_ID], [SKU_ID], [QUANTITY], [PRICE], [TOTAL_PRICE], [TOOL], [ADDRESS_ID]) VALUES (N'0d618c611342444484adeb95522caea5', N'446902cb3b8744c9b5fbb3c41b602f99', N'1', N'2', N'22.00', N'44.00', N'1', N'1')
GO
GO
INSERT INTO [dbo].[SMS_OUT_SKU] ([ID], [OUT_ID], [SKU_ID], [QUANTITY], [PRICE], [TOTAL_PRICE], [TOOL], [ADDRESS_ID]) VALUES (N'bd41125979f448f28c50e8b23384fe14', N'4544b43cc46d4e178a11d4f551581a28', N'2', N'2', N'22.00', N'44.00', N'1', N'1')
GO
GO

-- ----------------------------
-- Table structure for SMS_SKU
-- ----------------------------
DROP TABLE [dbo].[SMS_SKU]
GO
CREATE TABLE [dbo].[SMS_SKU] (
[ID] varchar(50) NOT NULL ,
[SKU_NO] varchar(50) NULL ,
[SKU_NAME] varchar(50) NULL ,
[SPU_ID] varchar(50) NULL ,
[BRAND] varchar(50) NULL ,
[PRICE] decimal(20,2) NULL ,
[UNIT] varchar(255) NULL ,
[TOTAL_COUNT] int NULL ,
[ALARM] int NULL ,
[DESCRIPTION] varchar(1024) NULL ,
[TOOL] int NULL ,
[STATUS] int NULL ,
[OLD_PARTID] varchar(50) NULL ,
[CATALOG2_ID] varchar(50) NULL ,
[OCU] varchar(255) NULL ,
[OCD] datetime NULL ,
[LUC] varchar(255) NULL ,
[LUD] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'主键哈希生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'主键哈希生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'SKU_NO')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_NO'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_NO'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'SKU_NAME')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存名(冗余，方便 操作)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_NAME'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存名(冗余，方便 操作)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SKU_NAME'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'SPU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联SPU'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SPU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联SPU'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'SPU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'BRAND')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'配件品牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'BRAND'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'配件品牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'BRAND'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'PRICE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'单价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'PRICE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'UNIT')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'单位'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'UNIT'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'单位'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'UNIT'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'TOTAL_COUNT')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'总数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_COUNT'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'总数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'TOTAL_COUNT'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'ALARM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'警报值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'ALARM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'警报值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'ALARM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'DESCRIPTION')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'DESCRIPTION'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'TOOL')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否是工具，0为配件，1为工具（自己用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'TOOL'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否是工具，0为配件，1为工具（自己用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'TOOL'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'STATUS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'状态，0为新，1为旧（回收配件）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'状态，0为新，1为旧（回收配件）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'STATUS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'OLD_PARTID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'绑定旧配件表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OLD_PARTID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'绑定旧配件表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OLD_PARTID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'CATALOG2_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'绑定二级分类'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'CATALOG2_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'绑定二级分类'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'CATALOG2_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'OCU')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OCU'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OCU'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'OCD')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OCD'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'OCD'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'LUC')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后更新账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'LUC'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后更新账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'LUC'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU', 
'COLUMN', N'LUD')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'LUD'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU'
, @level2type = 'COLUMN', @level2name = N'LUD'
GO

-- ----------------------------
-- Records of SMS_SKU
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU] ([ID], [SKU_NO], [SKU_NAME], [SPU_ID], [BRAND], [PRICE], [UNIT], [TOTAL_COUNT], [ALARM], [DESCRIPTION], [TOOL], [STATUS], [OLD_PARTID], [CATALOG2_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'1', N'no', N'name', N'spu', N'brand', N'22.00', N'unit', null, N'3', N'descr', N'0', N'0', N'oldpart', N'cata', null, N'2020-10-20 16:05:04.000', null, null)
GO
GO
INSERT INTO [dbo].[SMS_SKU] ([ID], [SKU_NO], [SKU_NAME], [SPU_ID], [BRAND], [PRICE], [UNIT], [TOTAL_COUNT], [ALARM], [DESCRIPTION], [TOOL], [STATUS], [OLD_PARTID], [CATALOG2_ID], [OCU], [OCD], [LUC], [LUD]) VALUES (N'2', N'no', N'string3', N'd7ed3c8162cb41bb87073530891717e5', N'brand', N'22.00', N'unit', N'3', N'3', N'descr', N'0', N'0', N'oldpart', N'cata', null, N'2020-10-24 16:05:09.000', null, null)
GO
GO

-- ----------------------------
-- Table structure for SMS_SKU_ADDRESS
-- ----------------------------
DROP TABLE [dbo].[SMS_SKU_ADDRESS]
GO
CREATE TABLE [dbo].[SMS_SKU_ADDRESS] (
[ID] varchar(50) NOT NULL ,
[SKU_ID] varchar(50) NULL ,
[ROOM] varchar(255) NULL ,
[SELF] varchar(255) NULL ,
[QUANTITY] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_ADDRESS', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关联sku'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ADDRESS'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关联sku'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ADDRESS'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_ADDRESS', 
'COLUMN', N'QUANTITY')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ADDRESS'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ADDRESS'
, @level2type = 'COLUMN', @level2name = N'QUANTITY'
GO

-- ----------------------------
-- Records of SMS_SKU_ADDRESS
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU_ADDRESS] ([ID], [SKU_ID], [ROOM], [SELF], [QUANTITY]) VALUES (N'1', N'2', N'd', N'd', N'0')
GO
GO
INSERT INTO [dbo].[SMS_SKU_ADDRESS] ([ID], [SKU_ID], [ROOM], [SELF], [QUANTITY]) VALUES (N'2', N'2', N'd', N'x', N'3')
GO
GO

-- ----------------------------
-- Table structure for SMS_SKU_ATTR_VALUE
-- ----------------------------
DROP TABLE [dbo].[SMS_SKU_ATTR_VALUE]
GO
CREATE TABLE [dbo].[SMS_SKU_ATTR_VALUE] (
[SKU_ID] varchar(50) NOT NULL ,
[SPU_ATTR_VALUE_ID] varchar(50) NULL ,
[ID] varchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_ATTR_VALUE', 
'COLUMN', N'SKU_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ATTR_VALUE'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ATTR_VALUE'
, @level2type = 'COLUMN', @level2name = N'SKU_ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_ATTR_VALUE', 
'COLUMN', N'SPU_ATTR_VALUE_ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'属性值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ATTR_VALUE'
, @level2type = 'COLUMN', @level2name = N'SPU_ATTR_VALUE_ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'属性值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_ATTR_VALUE'
, @level2type = 'COLUMN', @level2name = N'SPU_ATTR_VALUE_ID'
GO

-- ----------------------------
-- Records of SMS_SKU_ATTR_VALUE
-- ----------------------------
INSERT INTO [dbo].[SMS_SKU_ATTR_VALUE] ([SKU_ID], [SPU_ATTR_VALUE_ID], [ID]) VALUES (N'2', N'5f6786704aad4f59bfd73ce9cf068078', N'1')
GO
GO

-- ----------------------------
-- Table structure for SMS_SKU_LOG
-- ----------------------------
DROP TABLE [dbo].[SMS_SKU_LOG]
GO
CREATE TABLE [dbo].[SMS_SKU_LOG] (
[ID] varchar(50) NOT NULL ,
[SKU_ID] varchar(50) NULL ,
[OLD_ROOM] varchar(255) NULL ,
[OLD_SELF] varchar(255) NULL ,
[OLD_QUANTITY] int NULL ,
[OLD_ALARM] int NULL ,
[OLD_PRICE] decimal(20,2) NULL ,
[NEW_ROOM] varchar(255) NULL ,
[NEW_SELF] varchar(255) NULL ,
[NEW_QUANTITY] int NULL ,
[NEW_PRICE] decimal(20,2) NULL ,
[NEW_ALARM] int NULL ,
[TYPE] int NULL ,
[OCD] datetime NULL ,
[OCU] varchar(255) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
'COLUMN', N'OLD_ROOM')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改前的房间号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OLD_ROOM'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改前的房间号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OLD_ROOM'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
'COLUMN', N'OLD_SELF')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改前的架子号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OLD_SELF'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改前的架子号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OLD_SELF'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
'COLUMN', N'TYPE')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'0为更新，1为删除，2 为出库，3 为入库'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'TYPE'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'0为更新，1为删除，2 为出库，3 为入库'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'TYPE'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
'COLUMN', N'OCD')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间/配件修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OCD'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间/配件修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OCD'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SMS_SKU_LOG', 
'COLUMN', N'OCU')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作账号/配件修改账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OCU'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作账号/配件修改账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SMS_SKU_LOG'
, @level2type = 'COLUMN', @level2name = N'OCU'
GO

-- ----------------------------
-- Records of SMS_SKU_LOG
-- ----------------------------

-- ----------------------------
-- Table structure for ums_authority
-- ----------------------------
DROP TABLE [dbo].[ums_authority]
GO
CREATE TABLE [dbo].[ums_authority] (
[id] int NOT NULL IDENTITY(1,1) ,
[AuthorityName] varchar(30) NULL ,
[Description] varchar(200) NULL 
)


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
DROP TABLE [dbo].[ums_role]
GO
CREATE TABLE [dbo].[ums_role] (
[id] int NOT NULL IDENTITY(1,1) ,
[RoleName] varchar(30) NULL ,
[Description] varchar(200) NULL 
)


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
DROP TABLE [dbo].[ums_role_authority]
GO
CREATE TABLE [dbo].[ums_role_authority] (
[id] int NOT NULL IDENTITY(1,1) ,
[RoleId] int NULL ,
[AuthorityId] int NULL 
)


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
DROP TABLE [dbo].[ums_user]
GO
CREATE TABLE [dbo].[ums_user] (
[id] int NOT NULL IDENTITY(1,1) ,
[UserName] varchar(30) NOT NULL ,
[Pwd] varchar(30) NULL 
)


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
DROP TABLE [dbo].[ums_user_info]
GO
CREATE TABLE [dbo].[ums_user_info] (
[id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NULL ,
[Email] varchar(30) NULL ,
[Phone] varchar(20) NULL ,
[Sex] int NULL ,
[Photo] varchar(50) NULL 
)


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
DROP TABLE [dbo].[ums_user_role]
GO
CREATE TABLE [dbo].[ums_user_role] (
[id] int NOT NULL IDENTITY(1,1) ,
[RoleId] int NULL ,
[UserId] int NULL 
)


GO

-- ----------------------------
-- Records of ums_user_role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ums_user_role] ON
GO
SET IDENTITY_INSERT [dbo].[ums_user_role] OFF
GO

-- ----------------------------
-- Indexes structure for table BMMS_CATALOG_ATTR
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG_ATTR
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG_ATTR] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table BMMS_CATALOG1
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG1
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG1] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table BMMS_CATALOG2
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG2
-- ----------------------------
ALTER TABLE [dbo].[BMMS_CATALOG2] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table CMS_CLIENT
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CMS_CLIENT
-- ----------------------------
ALTER TABLE [dbo].[CMS_CLIENT] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table COMMON_TYPE
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table COMMON_TYPE
-- ----------------------------
ALTER TABLE [dbo].[COMMON_TYPE] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MMS_APPOINTMENT
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MMS_APPOINTMENT
-- ----------------------------
ALTER TABLE [dbo].[MMS_APPOINTMENT] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MMS_MAINTAIN
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MMS_MAINTAIN_OLDPART
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OLDPART
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_OLDPART] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MMS_MAINTAIN_OUT
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OUT
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_OUT] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table mms_maintain_sku
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table mms_maintain_sku
-- ----------------------------
ALTER TABLE [dbo].[mms_maintain_sku] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table MMS_MAINTAIN_TOOL
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_TOOL
-- ----------------------------
ALTER TABLE [dbo].[MMS_MAINTAIN_TOOL] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table PMS_SPU
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PMS_SPU
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table PMS_SPU_ATTR
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PMS_SPU_ATTR
-- ----------------------------
ALTER TABLE [dbo].[PMS_SPU_ATTR] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_CHECK
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_CHECK
-- ----------------------------
ALTER TABLE [dbo].[SMS_CHECK] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_CHECK_SKU
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_CHECK_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_CHECK_SKU] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_ENTRY
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_ENTRY
-- ----------------------------
ALTER TABLE [dbo].[SMS_ENTRY] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_ENTRY_SKU
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_ENTRY_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_ENTRY_SKU] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_OUT
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_OUT
-- ----------------------------
ALTER TABLE [dbo].[SMS_OUT] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_OUT_SKU
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_OUT_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_OUT_SKU] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_SKU
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_SKU
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_SKU_ADDRESS
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_SKU_ADDRESS
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ADDRESS] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_SKU_ATTR_VALUE
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_SKU_ATTR_VALUE
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_ATTR_VALUE] ADD PRIMARY KEY ([SKU_ID])
GO

-- ----------------------------
-- Indexes structure for table SMS_SKU_LOG
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SMS_SKU_LOG
-- ----------------------------
ALTER TABLE [dbo].[SMS_SKU_LOG] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table ums_authority
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_authority
-- ----------------------------
ALTER TABLE [dbo].[ums_authority] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ums_role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_role
-- ----------------------------
ALTER TABLE [dbo].[ums_role] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ums_role_authority
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_role_authority
-- ----------------------------
ALTER TABLE [dbo].[ums_role_authority] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ums_user
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_user
-- ----------------------------
ALTER TABLE [dbo].[ums_user] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ums_user_info
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_user_info
-- ----------------------------
ALTER TABLE [dbo].[ums_user_info] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ums_user_role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ums_user_role
-- ----------------------------
ALTER TABLE [dbo].[ums_user_role] ADD PRIMARY KEY ([id])
GO
