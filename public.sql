/*
 Navicat Premium Data Transfer

 Source Server         : MyLocalPostgre
 Source Server Type    : PostgreSQL
 Source Server Version : 100014
 Source Host           : localhost:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 100014
 File Encoding         : 65001

 Date: 05/11/2020 17:28:05
*/


-- ----------------------------
-- Table structure for BMMS_CATALOG1
-- ----------------------------
DROP TABLE IF EXISTS "public"."BMMS_CATALOG1";
CREATE TABLE "public"."BMMS_CATALOG1" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CATALOG_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."BMMS_CATALOG1"."CATALOG_NAME" IS '一级分类名';
COMMENT ON COLUMN "public"."BMMS_CATALOG1"."DESCRIPTION" IS '描述';

-- ----------------------------
-- Records of BMMS_CATALOG1
-- ----------------------------
INSERT INTO "public"."BMMS_CATALOG1" VALUES ('1', NULL, NULL, NULL, '2020-11-05 14:07:23', NULL, NULL);

-- ----------------------------
-- Table structure for BMMS_CATALOG2
-- ----------------------------
DROP TABLE IF EXISTS "public"."BMMS_CATALOG2";
CREATE TABLE "public"."BMMS_CATALOG2" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CATALOG_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "PARENT_ID" varchar(50) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."BMMS_CATALOG2"."CATALOG_NAME" IS '二级分类名';
COMMENT ON COLUMN "public"."BMMS_CATALOG2"."DESCRIPTION" IS '分类描述';
COMMENT ON COLUMN "public"."BMMS_CATALOG2"."PARENT_ID" IS '绑定一级分类';

-- ----------------------------
-- Records of BMMS_CATALOG2
-- ----------------------------

-- ----------------------------
-- Table structure for BMMS_CATALOG_ATTR
-- ----------------------------
DROP TABLE IF EXISTS "public"."BMMS_CATALOG_ATTR";
CREATE TABLE "public"."BMMS_CATALOG_ATTR" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "ATTR_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "CATALOG_ID" varchar(50) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(0),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(0)
)
;
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."ID" IS 'ID';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."ATTR_NAME" IS '属性名';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."CATALOG_ID" IS '二级分类ID';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."OCU" IS '创建账号';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."OCD" IS '创建时间';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."LUC" IS '最后更新账号';
COMMENT ON COLUMN "public"."BMMS_CATALOG_ATTR"."LUD" IS '最后更新时间';

-- ----------------------------
-- Records of BMMS_CATALOG_ATTR
-- ----------------------------

-- ----------------------------
-- Table structure for CMS_CLIENT
-- ----------------------------
DROP TABLE IF EXISTS "public"."CMS_CLIENT";
CREATE TABLE "public"."CMS_CLIENT" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "COMPANY" varchar(255) COLLATE "pg_catalog"."default",
  "ADDRESS" varchar(255) COLLATE "pg_catalog"."default",
  "PHONE" varchar(255) COLLATE "pg_catalog"."default",
  "CONTACT" varchar(255) COLLATE "pg_catalog"."default",
  "EMAIL" varchar(255) COLLATE "pg_catalog"."default",
  "TYPE" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" varchar(255) COLLATE "pg_catalog"."default",
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."CMS_CLIENT"."COMPANY" IS '公司名称';
COMMENT ON COLUMN "public"."CMS_CLIENT"."ADDRESS" IS '公司地址';
COMMENT ON COLUMN "public"."CMS_CLIENT"."PHONE" IS '联系电话';
COMMENT ON COLUMN "public"."CMS_CLIENT"."CONTACT" IS '联系人';
COMMENT ON COLUMN "public"."CMS_CLIENT"."EMAIL" IS '联系邮箱';
COMMENT ON COLUMN "public"."CMS_CLIENT"."TYPE" IS '车型';
COMMENT ON COLUMN "public"."CMS_CLIENT"."DESCRIPTION" IS '描述/备注';

-- ----------------------------
-- Records of CMS_CLIENT
-- ----------------------------

-- ----------------------------
-- Table structure for COMMON_TYPE
-- ----------------------------
DROP TABLE IF EXISTS "public"."COMMON_TYPE";
CREATE TABLE "public"."COMMON_TYPE" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "TYPE_NO" varchar(50) COLLATE "pg_catalog"."default",
  "TITLE" varchar(255) COLLATE "pg_catalog"."default",
  "TYPE_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."COMMON_TYPE"."TYPE_NO" IS '字段编号';
COMMENT ON COLUMN "public"."COMMON_TYPE"."TITLE" IS '主题';
COMMENT ON COLUMN "public"."COMMON_TYPE"."TYPE_NAME" IS '字段名';
COMMENT ON COLUMN "public"."COMMON_TYPE"."DESCRIPTION" IS '描述';

-- ----------------------------
-- Records of COMMON_TYPE
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_APPOINTMENT
-- ----------------------------
DROP TABLE IF EXISTS "public"."MMS_APPOINTMENT";
CREATE TABLE "public"."MMS_APPOINTMENT" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "APPOINTMENT_NO" varchar(50) COLLATE "pg_catalog"."default",
  "COMPANY_ID" varchar(50) COLLATE "pg_catalog"."default",
  "CAR_LICENSE" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "APPOINTMENT_DATE" timestamp(6),
  "TYPE" varchar(255) COLLATE "pg_catalog"."default",
  "PHONE" varchar(255) COLLATE "pg_catalog"."default",
  "CONTACT" varchar(255) COLLATE "pg_catalog"."default",
  "STATUS" int4,
  "REMARK" varchar(255) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."APPOINTMENT_NO" IS '预约编号: 预约年月日+公司编号(三位后三位（不足补）)+车牌后两位+当天公司维修次序（三位）';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."COMPANY_ID" IS '客户公司';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."CAR_LICENSE" IS '车牌号';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."DESCRIPTION" IS '问题描述';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."APPOINTMENT_DATE" IS '预约时间';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."TYPE" IS '车型';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."PHONE" IS '联系电话';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."CONTACT" IS '联系人';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."STATUS" IS '是否处理，0未处理，1已处理，2取消';
COMMENT ON COLUMN "public"."MMS_APPOINTMENT"."REMARK" IS '备注';

-- ----------------------------
-- Records of MMS_APPOINTMENT
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN
-- ----------------------------
DROP TABLE IF EXISTS "public"."MMS_MAINTAIN";
CREATE TABLE "public"."MMS_MAINTAIN" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "MAINTAIN_ID" varchar(50) COLLATE "pg_catalog"."default",
  "STAFF" varchar(255) COLLATE "pg_catalog"."default",
  "APPOINTMENT_ID" varchar(50) COLLATE "pg_catalog"."default",
  "START_DATE" date,
  "STATUS" int4,
  "RETURN_DATE" date,
  "OPERATOR" varchar(255) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."MAINTAIN_ID" IS '维修编号';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."STAFF" IS '员工';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."APPOINTMENT_ID" IS '关联预约单';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."START_DATE" IS '开始时间';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."STATUS" IS '是否已签字，0没有，1处理完';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."RETURN_DATE" IS '归还日期';
COMMENT ON COLUMN "public"."MMS_MAINTAIN"."OPERATOR" IS '操作员';

-- ----------------------------
-- Records of MMS_MAINTAIN
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN_OLDPART
-- ----------------------------
DROP TABLE IF EXISTS "public"."MMS_MAINTAIN_OLDPART";
CREATE TABLE "public"."MMS_MAINTAIN_OLDPART" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "MAINTAIN_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "NUM" int4 DEFAULT 0,
  "PRICE" numeric(18,2) DEFAULT 0,
  "STATUS" int4 DEFAULT 0,
  "REMARK" varchar(1024) COLLATE "pg_catalog"."default",
  "DEAL_NUM" int4 DEFAULT 0
)
;
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."MAINTAIN_ID" IS '关联维修单';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."SKU_ID" IS '关联库存';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."NUM" IS '数量';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."PRICE" IS '收购价';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."STATUS" IS '是否已经入库，0没有，1入库';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."REMARK" IS '备注';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OLDPART"."DEAL_NUM" IS '已经处理的数量';

-- ----------------------------
-- Records of MMS_MAINTAIN_OLDPART
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN_OUT
-- ----------------------------
DROP TABLE IF EXISTS "public"."MMS_MAINTAIN_OUT";
CREATE TABLE "public"."MMS_MAINTAIN_OUT" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "MAINTAIN_ID" varchar(50) COLLATE "pg_catalog"."default",
  "OUT_ID" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OUT"."MAINTAIN_ID" IS '关联维修单';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_OUT"."OUT_ID" IS '关联出库单';

-- ----------------------------
-- Records of MMS_MAINTAIN_OUT
-- ----------------------------

-- ----------------------------
-- Table structure for MMS_MAINTAIN_TOOL
-- ----------------------------
DROP TABLE IF EXISTS "public"."MMS_MAINTAIN_TOOL";
CREATE TABLE "public"."MMS_MAINTAIN_TOOL" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "MAINTAIN_ID" varchar(50) COLLATE "pg_catalog"."default",
  "OUT_SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "DEAL_NUM" int4 DEFAULT 0,
  "STATUS" int4 DEFAULT 0,
  "REMARK" varchar(1024) COLLATE "pg_catalog"."default",
  "COMPENSATION" numeric(18,2) DEFAULT 0,
  "NUM" int4 DEFAULT 0
)
;
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."MAINTAIN_ID" IS '关联维修单';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."OUT_SKU_ID" IS '关联出库库存';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."DEAL_NUM" IS '归还数量';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."STATUS" IS '状态，0没有解决，1解决';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."REMARK" IS '备注';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."COMPENSATION" IS '赔偿金';
COMMENT ON COLUMN "public"."MMS_MAINTAIN_TOOL"."NUM" IS '数量';

-- ----------------------------
-- Records of MMS_MAINTAIN_TOOL
-- ----------------------------

-- ----------------------------
-- Table structure for PMS_SPU_ATTR
-- ----------------------------
DROP TABLE IF EXISTS "public"."PMS_SPU_ATTR";
CREATE TABLE "public"."PMS_SPU_ATTR" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "ATTR_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SPU_ID" varchar(50) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of PMS_SPU_ATTR
-- ----------------------------

-- ----------------------------
-- Table structure for PMS_SPU_ATTR_VALUE
-- ----------------------------
DROP TABLE IF EXISTS "public"."PMS_SPU_ATTR_VALUE";
CREATE TABLE "public"."PMS_SPU_ATTR_VALUE" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "SPU_ATTR_ID" varchar(50) COLLATE "pg_catalog"."default",
  "VALUE" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."PMS_SPU_ATTR_VALUE"."VALUE" IS '属性值';

-- ----------------------------
-- Records of PMS_SPU_ATTR_VALUE
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_CHECK
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_CHECK";
CREATE TABLE "public"."SMS_CHECK" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CHECK_NO" varchar(50) COLLATE "pg_catalog"."default",
  "OPERATOR" varchar(255) COLLATE "pg_catalog"."default",
  "CHECK_DATE" date,
  "ACCOUNT_PRICE" numeric(18,2) DEFAULT 0,
  "CHECK_PRICE" numeric(18,2) DEFAULT 0,
  "DIFFERENCE_PRICE" numeric(18,2) DEFAULT 0,
  "DESCRIPTION" varchar(1024) COLLATE "pg_catalog"."default",
  "STATUS" int4,
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."SMS_CHECK"."CHECK_NO" IS '盘点单号';
COMMENT ON COLUMN "public"."SMS_CHECK"."OPERATOR" IS '操作员';
COMMENT ON COLUMN "public"."SMS_CHECK"."CHECK_DATE" IS '盘点日期';
COMMENT ON COLUMN "public"."SMS_CHECK"."ACCOUNT_PRICE" IS '账面总金额';
COMMENT ON COLUMN "public"."SMS_CHECK"."CHECK_PRICE" IS '盘点总金额';
COMMENT ON COLUMN "public"."SMS_CHECK"."DIFFERENCE_PRICE" IS '相差总金额，正为多了，负为少了';
COMMENT ON COLUMN "public"."SMS_CHECK"."DESCRIPTION" IS '备注';
COMMENT ON COLUMN "public"."SMS_CHECK"."STATUS" IS '是否解决，0解决，1为解决';

-- ----------------------------
-- Records of SMS_CHECK
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_CHECK_SKU
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_CHECK_SKU";
CREATE TABLE "public"."SMS_CHECK_SKU" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CHECK_ID" varchar(50) COLLATE "pg_catalog"."default",
  "ADDRESS_ID" varchar(50) COLLATE "pg_catalog"."default",
  "CHECK_NUM" int4 DEFAULT 0,
  "CHECK_PRICE" numeric(18,2) DEFAULT 0,
  "PRICE" numeric(18,2) DEFAULT 0,
  "ACCOUNT_PRICE" numeric(18,2),
  "ACCOUNT_NUM" int4 DEFAULT 0,
  "DIFFERENCE_NUM" int4 DEFAULT 0,
  "DESCRIPTION" varchar(1024) COLLATE "pg_catalog"."default",
  "STATUS" int4 DEFAULT 1,
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "DIFFERENCE_PRICE" numeric(18,2)
)
;
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."CHECK_ID" IS '关联盘点表';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."ADDRESS_ID" IS '关联库存（位置）';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."CHECK_NUM" IS '盘点数量';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."CHECK_PRICE" IS '盘点总金额';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."PRICE" IS '当时单价';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."ACCOUNT_PRICE" IS '账面总金额';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."ACCOUNT_NUM" IS '账面数量';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."DIFFERENCE_NUM" IS '相差数量，正多，负少';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."DESCRIPTION" IS '备注';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."STATUS" IS '0已处理，1未处理';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."SKU_ID" IS '预留字段';
COMMENT ON COLUMN "public"."SMS_CHECK_SKU"."DIFFERENCE_PRICE" IS '相差金额，正多，负少';

-- ----------------------------
-- Records of SMS_CHECK_SKU
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_ENTRY
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_ENTRY";
CREATE TABLE "public"."SMS_ENTRY" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "ENTRY_NO" varchar(50) COLLATE "pg_catalog"."default",
  "OPERATOR" varchar(255) COLLATE "pg_catalog"."default",
  "TOTAL_PRICE" numeric(18,2),
  "ENTRY_DATE" date,
  "BATCH" int4,
  "SUPPER_ID" int4,
  "DESCRIPTION" varchar(1024) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."SMS_ENTRY"."ENTRY_NO" IS '入库编号';
COMMENT ON COLUMN "public"."SMS_ENTRY"."OPERATOR" IS '操作员';
COMMENT ON COLUMN "public"."SMS_ENTRY"."BATCH" IS '批次';
COMMENT ON COLUMN "public"."SMS_ENTRY"."SUPPER_ID" IS '关联供应商';
COMMENT ON COLUMN "public"."SMS_ENTRY"."DESCRIPTION" IS '备注';

-- ----------------------------
-- Records of SMS_ENTRY
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_ENTRY_SKU
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_ENTRY_SKU";
CREATE TABLE "public"."SMS_ENTRY_SKU" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "ENTRY_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "QUANTITY" int4,
  "PRICE" numeric(18,2),
  "TOTAL_PRICE" numeric(18,2),
  "STATUS" int4,
  "OLD_PARTID" varchar(50) COLLATE "pg_catalog"."default",
  "ADDRESS_ID" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."ENTRY_ID" IS '关联入库单';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."SKU_ID" IS '关联库存';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."QUANTITY" IS '数量';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."PRICE" IS '单价';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."TOTAL_PRICE" IS '总价';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."STATUS" IS '0为新，1为旧';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."OLD_PARTID" IS '如果是旧，绑定旧来源';
COMMENT ON COLUMN "public"."SMS_ENTRY_SKU"."ADDRESS_ID" IS '地址';

-- ----------------------------
-- Records of SMS_ENTRY_SKU
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_OUT
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_OUT";
CREATE TABLE "public"."SMS_OUT" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "OUT_NO" varchar(50) COLLATE "pg_catalog"."default",
  "OPERATOR" varchar(255) COLLATE "pg_catalog"."default",
  "OUT_DATE" date,
  "TOTAL_PRICE" numeric(10,2),
  "BATCH" int2,
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "CLIENT_ID" varchar(50) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."SMS_OUT"."OUT_NO" IS '出库单号';
COMMENT ON COLUMN "public"."SMS_OUT"."OPERATOR" IS '操作员';
COMMENT ON COLUMN "public"."SMS_OUT"."OUT_DATE" IS '出库日期';
COMMENT ON COLUMN "public"."SMS_OUT"."TOTAL_PRICE" IS '总金额';
COMMENT ON COLUMN "public"."SMS_OUT"."BATCH" IS '批次';
COMMENT ON COLUMN "public"."SMS_OUT"."DESCRIPTION" IS '备注';
COMMENT ON COLUMN "public"."SMS_OUT"."CLIENT_ID" IS '关联客户';

-- ----------------------------
-- Records of SMS_OUT
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_OUT_SKU
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_OUT_SKU";
CREATE TABLE "public"."SMS_OUT_SKU" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "OUT_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "QUANTITY" int4,
  "PRICE" numeric(18,2),
  "TOTAL_PRICE" numeric(18,2),
  "TOOL" int4 DEFAULT 0,
  "ADDRESS_ID" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."OUT_ID" IS '出库单ID';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."SKU_ID" IS '库存ID';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."QUANTITY" IS '数量';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."PRICE" IS '出库单价';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."TOTAL_PRICE" IS '总金额';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."TOOL" IS '0是配件，1是工具';
COMMENT ON COLUMN "public"."SMS_OUT_SKU"."ADDRESS_ID" IS '关联具体库存';

-- ----------------------------
-- Records of SMS_OUT_SKU
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_SKU
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_SKU";
CREATE TABLE "public"."SMS_SKU" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "SKU_NO" varchar(50) COLLATE "pg_catalog"."default",
  "SKU_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "SPU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "BRAND" varchar(255) COLLATE "pg_catalog"."default",
  "PRICE" numeric(18,2),
  "UNIT" varchar(255) COLLATE "pg_catalog"."default",
  "TOTAL_COUNT" int4,
  "ALARM" int4,
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "TOOL" int4,
  "CATALOG2_ID" varchar COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."SMS_SKU"."SKU_NO" IS '库存编号';
COMMENT ON COLUMN "public"."SMS_SKU"."SKU_NAME" IS '库存名（冗余方便操作，实质SpuName）';
COMMENT ON COLUMN "public"."SMS_SKU"."SPU_ID" IS '关联SPU';
COMMENT ON COLUMN "public"."SMS_SKU"."BRAND" IS '配件品牌';
COMMENT ON COLUMN "public"."SMS_SKU"."PRICE" IS '参考单价';
COMMENT ON COLUMN "public"."SMS_SKU"."UNIT" IS '单位';
COMMENT ON COLUMN "public"."SMS_SKU"."TOTAL_COUNT" IS '总数量';
COMMENT ON COLUMN "public"."SMS_SKU"."ALARM" IS '警报值';
COMMENT ON COLUMN "public"."SMS_SKU"."DESCRIPTION" IS '备注';
COMMENT ON COLUMN "public"."SMS_SKU"."TOOL" IS '是否是工具，0为配件，1为工具';
COMMENT ON COLUMN "public"."SMS_SKU"."CATALOG2_ID" IS '绑定二级分类';

-- ----------------------------
-- Records of SMS_SKU
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_SKU_ADDRESS
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_SKU_ADDRESS";
CREATE TABLE "public"."SMS_SKU_ADDRESS" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default",
  "ROOM" varchar(255) COLLATE "pg_catalog"."default",
  "SELF" varchar(255) COLLATE "pg_catalog"."default",
  "QUANTITY" int4,
  "STATUS" int4,
  "OLD_PARTID" varchar(50) COLLATE "pg_catalog"."default",
  "PRICE" numeric(18,2)
)
;
COMMENT ON COLUMN "public"."SMS_SKU_ADDRESS"."SKU_ID" IS '关联sku';
COMMENT ON COLUMN "public"."SMS_SKU_ADDRESS"."QUANTITY" IS '数量';
COMMENT ON COLUMN "public"."SMS_SKU_ADDRESS"."STATUS" IS '记录新旧，0新，1旧';
COMMENT ON COLUMN "public"."SMS_SKU_ADDRESS"."OLD_PARTID" IS '绑定旧来源';

-- ----------------------------
-- Records of SMS_SKU_ADDRESS
-- ----------------------------

-- ----------------------------
-- Table structure for SMS_SKU_ATTR_VALUE
-- ----------------------------
DROP TABLE IF EXISTS "public"."SMS_SKU_ATTR_VALUE";
CREATE TABLE "public"."SMS_SKU_ATTR_VALUE" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "SPU_ATTR_VALUE_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SKU_ID" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."SMS_SKU_ATTR_VALUE"."SPU_ATTR_VALUE_ID" IS '属性值';
COMMENT ON COLUMN "public"."SMS_SKU_ATTR_VALUE"."SKU_ID" IS '库存';

-- ----------------------------
-- Records of SMS_SKU_ATTR_VALUE
-- ----------------------------

-- ----------------------------
-- Table structure for UMS_USER
-- ----------------------------
DROP TABLE IF EXISTS "public"."UMS_USER";
CREATE TABLE "public"."UMS_USER" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "USER_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "PWD" varchar(255) COLLATE "pg_catalog"."default",
  "SALT" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUD" timestamp(6),
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "LUC" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."UMS_USER"."USER_NAME" IS '用户名';
COMMENT ON COLUMN "public"."UMS_USER"."PWD" IS '密码';
COMMENT ON COLUMN "public"."UMS_USER"."SALT" IS '盐值';

-- ----------------------------
-- Records of UMS_USER
-- ----------------------------

-- ----------------------------
-- Table structure for pms_spu
-- ----------------------------
DROP TABLE IF EXISTS "public"."pms_spu";
CREATE TABLE "public"."pms_spu" (
  "ID" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "CATALOG2_ID" varchar(50) COLLATE "pg_catalog"."default",
  "SPU_NO" varchar(50) COLLATE "pg_catalog"."default",
  "PRODUCT_NAME" varchar(255) COLLATE "pg_catalog"."default",
  "DESCRIPTION" varchar(255) COLLATE "pg_catalog"."default",
  "OCU" varchar(255) COLLATE "pg_catalog"."default",
  "OCD" timestamp(6),
  "LUC" varchar(255) COLLATE "pg_catalog"."default",
  "LUD" timestamp(6)
)
;
COMMENT ON COLUMN "public"."pms_spu"."CATALOG2_ID" IS '关联二级分类';
COMMENT ON COLUMN "public"."pms_spu"."SPU_NO" IS '产品编号';
COMMENT ON COLUMN "public"."pms_spu"."PRODUCT_NAME" IS '产品名';
COMMENT ON COLUMN "public"."pms_spu"."DESCRIPTION" IS '描述';

-- ----------------------------
-- Records of pms_spu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG1
-- ----------------------------
ALTER TABLE "public"."BMMS_CATALOG1" ADD CONSTRAINT "BMMS_CATALOG1_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG2
-- ----------------------------
ALTER TABLE "public"."BMMS_CATALOG2" ADD CONSTRAINT "BMMS_CATALOG2_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table BMMS_CATALOG_ATTR
-- ----------------------------
ALTER TABLE "public"."BMMS_CATALOG_ATTR" ADD CONSTRAINT "BMMS_CATALOG_ATTR_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table CMS_CLIENT
-- ----------------------------
ALTER TABLE "public"."CMS_CLIENT" ADD CONSTRAINT "CMS_CLIENT_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table COMMON_TYPE
-- ----------------------------
ALTER TABLE "public"."COMMON_TYPE" ADD CONSTRAINT "COMMON_TYPE_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table MMS_APPOINTMENT
-- ----------------------------
ALTER TABLE "public"."MMS_APPOINTMENT" ADD CONSTRAINT "MMS_APPOINTMENT_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN
-- ----------------------------
ALTER TABLE "public"."MMS_MAINTAIN" ADD CONSTRAINT "MMS_MAINTAIN_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OLDPART
-- ----------------------------
ALTER TABLE "public"."MMS_MAINTAIN_OLDPART" ADD CONSTRAINT "MMS_MAINTAIN_OLDPART_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_OUT
-- ----------------------------
ALTER TABLE "public"."MMS_MAINTAIN_OUT" ADD CONSTRAINT "MMS_MAINTAIN_OUT_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table MMS_MAINTAIN_TOOL
-- ----------------------------
ALTER TABLE "public"."MMS_MAINTAIN_TOOL" ADD CONSTRAINT "MMS_MAINTAIN_TOOL_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table PMS_SPU_ATTR
-- ----------------------------
ALTER TABLE "public"."PMS_SPU_ATTR" ADD CONSTRAINT "PMS_SPU_ATTR_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table PMS_SPU_ATTR_VALUE
-- ----------------------------
ALTER TABLE "public"."PMS_SPU_ATTR_VALUE" ADD CONSTRAINT "PMS_SPU_ATTR_VALUE_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_CHECK
-- ----------------------------
ALTER TABLE "public"."SMS_CHECK" ADD CONSTRAINT "SMS_CHECK_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_CHECK_SKU
-- ----------------------------
ALTER TABLE "public"."SMS_CHECK_SKU" ADD CONSTRAINT "SMS_CHECK_SKU_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_ENTRY
-- ----------------------------
ALTER TABLE "public"."SMS_ENTRY" ADD CONSTRAINT "SMS_ENTRY_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_ENTRY_SKU
-- ----------------------------
ALTER TABLE "public"."SMS_ENTRY_SKU" ADD CONSTRAINT "SMS_ENTRY_SKU_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_OUT
-- ----------------------------
ALTER TABLE "public"."SMS_OUT" ADD CONSTRAINT "SMS_OUT_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_OUT_SKU
-- ----------------------------
ALTER TABLE "public"."SMS_OUT_SKU" ADD CONSTRAINT "SMS_OUT_SKU_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_SKU
-- ----------------------------
ALTER TABLE "public"."SMS_SKU" ADD CONSTRAINT "SMS_SKU_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_SKU_ADDRESS
-- ----------------------------
ALTER TABLE "public"."SMS_SKU_ADDRESS" ADD CONSTRAINT "SMS_SKU_ADDRESS_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table SMS_SKU_ATTR_VALUE
-- ----------------------------
ALTER TABLE "public"."SMS_SKU_ATTR_VALUE" ADD CONSTRAINT "SMS_SKU_ATTR_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table UMS_USER
-- ----------------------------
ALTER TABLE "public"."UMS_USER" ADD CONSTRAINT "UMS_USER_pkey" PRIMARY KEY ("ID");

-- ----------------------------
-- Primary Key structure for table pms_spu
-- ----------------------------
ALTER TABLE "public"."pms_spu" ADD CONSTRAINT "PMS_SPU_pkey" PRIMARY KEY ("ID");
