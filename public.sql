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

 Date: 06/11/2020 15:42:07
*/


-- ----------------------------
-- Table structure for bmms_catalog1
-- ----------------------------
DROP TABLE IF EXISTS "public"."bmms_catalog1";
CREATE TABLE "public"."bmms_catalog1" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "catalog_name" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."bmms_catalog1"."catalog_name" IS '一级分类名';
COMMENT ON COLUMN "public"."bmms_catalog1"."description" IS '描述';

-- ----------------------------
-- Records of bmms_catalog1
-- ----------------------------

-- ----------------------------
-- Table structure for bmms_catalog2
-- ----------------------------
DROP TABLE IF EXISTS "public"."bmms_catalog2";
CREATE TABLE "public"."bmms_catalog2" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "catalog_name" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "parent_id" varchar(50) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."bmms_catalog2"."catalog_name" IS '二级分类名';
COMMENT ON COLUMN "public"."bmms_catalog2"."description" IS '分类描述';
COMMENT ON COLUMN "public"."bmms_catalog2"."parent_id" IS '绑定一级分类';

-- ----------------------------
-- Records of bmms_catalog2
-- ----------------------------

-- ----------------------------
-- Table structure for bmms_catalog_attr
-- ----------------------------
DROP TABLE IF EXISTS "public"."bmms_catalog_attr";
CREATE TABLE "public"."bmms_catalog_attr" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "attr_name" varchar(255) COLLATE "pg_catalog"."default",
  "catalog_id" varchar(50) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(0),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(0)
)
;
COMMENT ON COLUMN "public"."bmms_catalog_attr"."id" IS 'ID';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."attr_name" IS '属性名';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."catalog_id" IS '二级分类ID';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."ocu" IS '创建账号';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."ocd" IS '创建时间';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."luc" IS '最后更新账号';
COMMENT ON COLUMN "public"."bmms_catalog_attr"."lud" IS '最后更新时间';

-- ----------------------------
-- Records of bmms_catalog_attr
-- ----------------------------

-- ----------------------------
-- Table structure for cms_client
-- ----------------------------
DROP TABLE IF EXISTS "public"."cms_client";
CREATE TABLE "public"."cms_client" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "company" varchar(255) COLLATE "pg_catalog"."default",
  "address" varchar(255) COLLATE "pg_catalog"."default",
  "phone" varchar(255) COLLATE "pg_catalog"."default",
  "contact" varchar(255) COLLATE "pg_catalog"."default",
  "email" varchar(255) COLLATE "pg_catalog"."default",
  "type" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" varchar(255) COLLATE "pg_catalog"."default",
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."cms_client"."company" IS '公司名称';
COMMENT ON COLUMN "public"."cms_client"."address" IS '公司地址';
COMMENT ON COLUMN "public"."cms_client"."phone" IS '联系电话';
COMMENT ON COLUMN "public"."cms_client"."contact" IS '联系人';
COMMENT ON COLUMN "public"."cms_client"."email" IS '联系邮箱';
COMMENT ON COLUMN "public"."cms_client"."type" IS '车型';
COMMENT ON COLUMN "public"."cms_client"."description" IS '描述/备注';

-- ----------------------------
-- Records of cms_client
-- ----------------------------

-- ----------------------------
-- Table structure for common_type
-- ----------------------------
DROP TABLE IF EXISTS "public"."common_type";
CREATE TABLE "public"."common_type" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "type_no" varchar(50) COLLATE "pg_catalog"."default",
  "title" varchar(255) COLLATE "pg_catalog"."default",
  "type_name" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."common_type"."type_no" IS '字段编号';
COMMENT ON COLUMN "public"."common_type"."title" IS '主题';
COMMENT ON COLUMN "public"."common_type"."type_name" IS '字段名';
COMMENT ON COLUMN "public"."common_type"."description" IS '描述';

-- ----------------------------
-- Records of common_type
-- ----------------------------

-- ----------------------------
-- Table structure for mms_appointment
-- ----------------------------
DROP TABLE IF EXISTS "public"."mms_appointment";
CREATE TABLE "public"."mms_appointment" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "appointment_no" varchar(50) COLLATE "pg_catalog"."default",
  "company_id" varchar(50) COLLATE "pg_catalog"."default",
  "car_license" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "appointment_date" timestamp(6),
  "type" varchar(255) COLLATE "pg_catalog"."default",
  "phone" varchar(255) COLLATE "pg_catalog"."default",
  "contact" varchar(255) COLLATE "pg_catalog"."default",
  "status" int4,
  "remark" varchar(255) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."mms_appointment"."appointment_no" IS '预约编号: 预约年月日+公司编号(三位后三位（不足补）)+车牌后两位+当天公司维修次序（三位）';
COMMENT ON COLUMN "public"."mms_appointment"."company_id" IS '客户公司';
COMMENT ON COLUMN "public"."mms_appointment"."car_license" IS '车牌号';
COMMENT ON COLUMN "public"."mms_appointment"."description" IS '问题描述';
COMMENT ON COLUMN "public"."mms_appointment"."appointment_date" IS '预约时间';
COMMENT ON COLUMN "public"."mms_appointment"."type" IS '车型';
COMMENT ON COLUMN "public"."mms_appointment"."phone" IS '联系电话';
COMMENT ON COLUMN "public"."mms_appointment"."contact" IS '联系人';
COMMENT ON COLUMN "public"."mms_appointment"."status" IS '是否处理，0未处理，1已处理，2取消';
COMMENT ON COLUMN "public"."mms_appointment"."remark" IS '备注';

-- ----------------------------
-- Records of mms_appointment
-- ----------------------------

-- ----------------------------
-- Table structure for mms_maintain
-- ----------------------------
DROP TABLE IF EXISTS "public"."mms_maintain";
CREATE TABLE "public"."mms_maintain" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "maintain_id" varchar(50) COLLATE "pg_catalog"."default",
  "staff" varchar(255) COLLATE "pg_catalog"."default",
  "appointment_id" varchar(50) COLLATE "pg_catalog"."default",
  "start_date" date,
  "status" int4,
  "return_date" date,
  "operator" varchar(255) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."mms_maintain"."maintain_id" IS '维修编号';
COMMENT ON COLUMN "public"."mms_maintain"."staff" IS '员工';
COMMENT ON COLUMN "public"."mms_maintain"."appointment_id" IS '关联预约单';
COMMENT ON COLUMN "public"."mms_maintain"."start_date" IS '开始时间';
COMMENT ON COLUMN "public"."mms_maintain"."status" IS '是否已签字，0没有，1处理完';
COMMENT ON COLUMN "public"."mms_maintain"."return_date" IS '归还日期';
COMMENT ON COLUMN "public"."mms_maintain"."operator" IS '操作员';

-- ----------------------------
-- Records of mms_maintain
-- ----------------------------

-- ----------------------------
-- Table structure for mms_maintain_oldpart
-- ----------------------------
DROP TABLE IF EXISTS "public"."mms_maintain_oldpart";
CREATE TABLE "public"."mms_maintain_oldpart" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "maintain_id" varchar(50) COLLATE "pg_catalog"."default",
  "sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "num" int4 DEFAULT 0,
  "price" numeric(18,2) DEFAULT 0,
  "status" int4 DEFAULT 0,
  "remark" varchar(1024) COLLATE "pg_catalog"."default",
  "deal_num" int4 DEFAULT 0
)
;
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."maintain_id" IS '关联维修单';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."sku_id" IS '关联库存';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."num" IS '数量';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."price" IS '收购价';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."status" IS '是否已经入库，0没有，1入库';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."remark" IS '备注';
COMMENT ON COLUMN "public"."mms_maintain_oldpart"."deal_num" IS '已经处理的数量';

-- ----------------------------
-- Records of mms_maintain_oldpart
-- ----------------------------

-- ----------------------------
-- Table structure for mms_maintain_out
-- ----------------------------
DROP TABLE IF EXISTS "public"."mms_maintain_out";
CREATE TABLE "public"."mms_maintain_out" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "maitain_id" varchar(50) COLLATE "pg_catalog"."default",
  "out_id" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."mms_maintain_out"."maitain_id" IS '关联维修单';
COMMENT ON COLUMN "public"."mms_maintain_out"."out_id" IS '关联出库单';

-- ----------------------------
-- Records of mms_maintain_out
-- ----------------------------

-- ----------------------------
-- Table structure for mms_maintain_tool
-- ----------------------------
DROP TABLE IF EXISTS "public"."mms_maintain_tool";
CREATE TABLE "public"."mms_maintain_tool" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "maintain_id" varchar(50) COLLATE "pg_catalog"."default",
  "out_sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "deal_num" int4 DEFAULT 0,
  "status" int4 DEFAULT 0,
  "remark" varchar(1024) COLLATE "pg_catalog"."default",
  "compensation" numeric(18,2) DEFAULT 0,
  "num" int4 DEFAULT 0
)
;
COMMENT ON COLUMN "public"."mms_maintain_tool"."maintain_id" IS '关联维修单';
COMMENT ON COLUMN "public"."mms_maintain_tool"."out_sku_id" IS '关联出库库存';
COMMENT ON COLUMN "public"."mms_maintain_tool"."deal_num" IS '归还数量';
COMMENT ON COLUMN "public"."mms_maintain_tool"."status" IS '状态，0没有解决，1解决';
COMMENT ON COLUMN "public"."mms_maintain_tool"."remark" IS '备注';
COMMENT ON COLUMN "public"."mms_maintain_tool"."compensation" IS '赔偿金';
COMMENT ON COLUMN "public"."mms_maintain_tool"."num" IS '数量';

-- ----------------------------
-- Records of mms_maintain_tool
-- ----------------------------

-- ----------------------------
-- Table structure for pms_spu
-- ----------------------------
DROP TABLE IF EXISTS "public"."pms_spu";
CREATE TABLE "public"."pms_spu" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "catalog2_id" varchar(50) COLLATE "pg_catalog"."default",
  "spu_no" varchar(50) COLLATE "pg_catalog"."default",
  "product_name" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."pms_spu"."catalog2_id" IS '关联二级分类';
COMMENT ON COLUMN "public"."pms_spu"."spu_no" IS '产品编号';
COMMENT ON COLUMN "public"."pms_spu"."product_name" IS '产品名';
COMMENT ON COLUMN "public"."pms_spu"."description" IS '描述';

-- ----------------------------
-- Records of pms_spu
-- ----------------------------

-- ----------------------------
-- Table structure for pms_spu_attr
-- ----------------------------
DROP TABLE IF EXISTS "public"."pms_spu_attr";
CREATE TABLE "public"."pms_spu_attr" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "attr_id" varchar(50) COLLATE "pg_catalog"."default",
  "spu_id" varchar(50) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of pms_spu_attr
-- ----------------------------

-- ----------------------------
-- Table structure for pms_spu_attr_value
-- ----------------------------
DROP TABLE IF EXISTS "public"."pms_spu_attr_value";
CREATE TABLE "public"."pms_spu_attr_value" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "spu_attr_id" varchar(50) COLLATE "pg_catalog"."default",
  "value" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."pms_spu_attr_value"."value" IS '属性值';

-- ----------------------------
-- Records of pms_spu_attr_value
-- ----------------------------

-- ----------------------------
-- Table structure for sms_check
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_check";
CREATE TABLE "public"."sms_check" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "check_no" varchar(50) COLLATE "pg_catalog"."default",
  "operator" varchar(255) COLLATE "pg_catalog"."default",
  "check_date" date,
  "account_price" numeric(18,2) DEFAULT 0,
  "check_price" numeric(18,2) DEFAULT 0,
  "difference_price" numeric(18,2) DEFAULT 0,
  "description" varchar(1024) COLLATE "pg_catalog"."default",
  "status" int4,
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."sms_check"."check_no" IS '盘点单号';
COMMENT ON COLUMN "public"."sms_check"."operator" IS '操作员';
COMMENT ON COLUMN "public"."sms_check"."check_date" IS '盘点日期';
COMMENT ON COLUMN "public"."sms_check"."account_price" IS '账面总金额';
COMMENT ON COLUMN "public"."sms_check"."check_price" IS '盘点总金额';
COMMENT ON COLUMN "public"."sms_check"."difference_price" IS '相差总金额，正为多了，负为少了';
COMMENT ON COLUMN "public"."sms_check"."description" IS '备注';
COMMENT ON COLUMN "public"."sms_check"."status" IS '是否解决，0解决，1为解决';

-- ----------------------------
-- Records of sms_check
-- ----------------------------

-- ----------------------------
-- Table structure for sms_check_sku
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_check_sku";
CREATE TABLE "public"."sms_check_sku" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "check_id" varchar(50) COLLATE "pg_catalog"."default",
  "address_id" varchar(50) COLLATE "pg_catalog"."default",
  "check_num" int4 DEFAULT 0,
  "check_price" numeric(18,2) DEFAULT 0,
  "price" numeric(18,2) DEFAULT 0,
  "account_price" numeric(18,2),
  "account_num" int4 DEFAULT 0,
  "difference_num" int4 DEFAULT 0,
  "description" varchar(1024) COLLATE "pg_catalog"."default",
  "status" int4 DEFAULT 1,
  "sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "difference_price" numeric(18,2)
)
;
COMMENT ON COLUMN "public"."sms_check_sku"."check_id" IS '关联盘点表';
COMMENT ON COLUMN "public"."sms_check_sku"."address_id" IS '关联库存（位置）';
COMMENT ON COLUMN "public"."sms_check_sku"."check_num" IS '盘点数量';
COMMENT ON COLUMN "public"."sms_check_sku"."check_price" IS '盘点总金额';
COMMENT ON COLUMN "public"."sms_check_sku"."price" IS '当时单价';
COMMENT ON COLUMN "public"."sms_check_sku"."account_price" IS '账面总金额';
COMMENT ON COLUMN "public"."sms_check_sku"."account_num" IS '账面数量';
COMMENT ON COLUMN "public"."sms_check_sku"."difference_num" IS '相差数量，正多，负少';
COMMENT ON COLUMN "public"."sms_check_sku"."description" IS '备注';
COMMENT ON COLUMN "public"."sms_check_sku"."status" IS '0已处理，1未处理';
COMMENT ON COLUMN "public"."sms_check_sku"."sku_id" IS '预留字段';
COMMENT ON COLUMN "public"."sms_check_sku"."difference_price" IS '相差金额，正多，负少';

-- ----------------------------
-- Records of sms_check_sku
-- ----------------------------

-- ----------------------------
-- Table structure for sms_entry
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_entry";
CREATE TABLE "public"."sms_entry" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "entry_no" varchar(50) COLLATE "pg_catalog"."default",
  "operator" varchar(255) COLLATE "pg_catalog"."default",
  "total_price" numeric(18,2),
  "entry_date" date,
  "batch" int4,
  "supplier_id" varchar(50) COLLATE "pg_catalog"."default",
  "description" varchar(1024) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."sms_entry"."entry_no" IS '入库编号';
COMMENT ON COLUMN "public"."sms_entry"."operator" IS '操作员';
COMMENT ON COLUMN "public"."sms_entry"."batch" IS '批次';
COMMENT ON COLUMN "public"."sms_entry"."supplier_id" IS '关联供应商';
COMMENT ON COLUMN "public"."sms_entry"."description" IS '备注';

-- ----------------------------
-- Records of sms_entry
-- ----------------------------

-- ----------------------------
-- Table structure for sms_entry_sku
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_entry_sku";
CREATE TABLE "public"."sms_entry_sku" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "entry_id" varchar(50) COLLATE "pg_catalog"."default",
  "sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "quantity" int4,
  "price" numeric(18,2),
  "total_price" numeric(18,2),
  "status" int4,
  "old_partid" varchar(50) COLLATE "pg_catalog"."default",
  "address_id" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."sms_entry_sku"."entry_id" IS '关联入库单';
COMMENT ON COLUMN "public"."sms_entry_sku"."sku_id" IS '关联库存';
COMMENT ON COLUMN "public"."sms_entry_sku"."quantity" IS '数量';
COMMENT ON COLUMN "public"."sms_entry_sku"."price" IS '单价';
COMMENT ON COLUMN "public"."sms_entry_sku"."total_price" IS '总价';
COMMENT ON COLUMN "public"."sms_entry_sku"."status" IS '0为新，1为旧';
COMMENT ON COLUMN "public"."sms_entry_sku"."old_partid" IS '如果是旧，绑定旧来源';
COMMENT ON COLUMN "public"."sms_entry_sku"."address_id" IS '地址';

-- ----------------------------
-- Records of sms_entry_sku
-- ----------------------------

-- ----------------------------
-- Table structure for sms_out
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_out";
CREATE TABLE "public"."sms_out" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "out_no" varchar(50) COLLATE "pg_catalog"."default",
  "operator" varchar(255) COLLATE "pg_catalog"."default",
  "out_date" date,
  "total_date" numeric(10,2),
  "batch" int2,
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "client_id" varchar(50) COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."sms_out"."out_no" IS '出库单号';
COMMENT ON COLUMN "public"."sms_out"."operator" IS '操作员';
COMMENT ON COLUMN "public"."sms_out"."out_date" IS '出库日期';
COMMENT ON COLUMN "public"."sms_out"."total_date" IS '总金额';
COMMENT ON COLUMN "public"."sms_out"."batch" IS '批次';
COMMENT ON COLUMN "public"."sms_out"."description" IS '备注';
COMMENT ON COLUMN "public"."sms_out"."client_id" IS '关联客户';

-- ----------------------------
-- Records of sms_out
-- ----------------------------

-- ----------------------------
-- Table structure for sms_out_sku
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_out_sku";
CREATE TABLE "public"."sms_out_sku" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "out_id" varchar(50) COLLATE "pg_catalog"."default",
  "sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "quantity" int4,
  "price" numeric(18,2),
  "total_price" numeric(18,2),
  "tool" int4 DEFAULT 0,
  "address_id" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."sms_out_sku"."out_id" IS '出库单ID';
COMMENT ON COLUMN "public"."sms_out_sku"."sku_id" IS '库存ID';
COMMENT ON COLUMN "public"."sms_out_sku"."quantity" IS '数量';
COMMENT ON COLUMN "public"."sms_out_sku"."price" IS '出库单价';
COMMENT ON COLUMN "public"."sms_out_sku"."total_price" IS '总金额';
COMMENT ON COLUMN "public"."sms_out_sku"."tool" IS '0是配件，1是工具';
COMMENT ON COLUMN "public"."sms_out_sku"."address_id" IS '关联具体库存';

-- ----------------------------
-- Records of sms_out_sku
-- ----------------------------

-- ----------------------------
-- Table structure for sms_sku
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_sku";
CREATE TABLE "public"."sms_sku" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "sku_no" varchar(50) COLLATE "pg_catalog"."default",
  "sku_name" varchar(255) COLLATE "pg_catalog"."default",
  "spu_id" varchar(50) COLLATE "pg_catalog"."default",
  "brand" varchar(255) COLLATE "pg_catalog"."default",
  "price" numeric(18,2),
  "unit" varchar(255) COLLATE "pg_catalog"."default",
  "total_count" int4,
  "alarm" int4,
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "tool" int4,
  "catalog2_id" varchar COLLATE "pg_catalog"."default",
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "luc" varchar(255) COLLATE "pg_catalog"."default",
  "lud" timestamp(6)
)
;
COMMENT ON COLUMN "public"."sms_sku"."sku_no" IS '库存编号';
COMMENT ON COLUMN "public"."sms_sku"."sku_name" IS '库存名（冗余方便操作，实质SpuName）';
COMMENT ON COLUMN "public"."sms_sku"."spu_id" IS '关联SPU';
COMMENT ON COLUMN "public"."sms_sku"."brand" IS '配件品牌';
COMMENT ON COLUMN "public"."sms_sku"."price" IS '参考单价';
COMMENT ON COLUMN "public"."sms_sku"."unit" IS '单位';
COMMENT ON COLUMN "public"."sms_sku"."total_count" IS '总数量';
COMMENT ON COLUMN "public"."sms_sku"."alarm" IS '警报值';
COMMENT ON COLUMN "public"."sms_sku"."description" IS '备注';
COMMENT ON COLUMN "public"."sms_sku"."tool" IS '是否是工具，0为配件，1为工具';
COMMENT ON COLUMN "public"."sms_sku"."catalog2_id" IS '绑定二级分类';

-- ----------------------------
-- Records of sms_sku
-- ----------------------------

-- ----------------------------
-- Table structure for sms_sku_address
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_sku_address";
CREATE TABLE "public"."sms_sku_address" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "sku_id" varchar(50) COLLATE "pg_catalog"."default",
  "room" varchar(255) COLLATE "pg_catalog"."default",
  "self" varchar(255) COLLATE "pg_catalog"."default",
  "quantity" int4,
  "status" int4,
  "old_partid" varchar(50) COLLATE "pg_catalog"."default",
  "price" numeric(18,2)
)
;
COMMENT ON COLUMN "public"."sms_sku_address"."sku_id" IS '关联sku';
COMMENT ON COLUMN "public"."sms_sku_address"."quantity" IS '数量';
COMMENT ON COLUMN "public"."sms_sku_address"."status" IS '记录新旧，0新，1旧';
COMMENT ON COLUMN "public"."sms_sku_address"."old_partid" IS '绑定旧来源';

-- ----------------------------
-- Records of sms_sku_address
-- ----------------------------

-- ----------------------------
-- Table structure for sms_sku_attr_value
-- ----------------------------
DROP TABLE IF EXISTS "public"."sms_sku_attr_value";
CREATE TABLE "public"."sms_sku_attr_value" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "spu_attr_value_id" varchar(50) COLLATE "pg_catalog"."default",
  "sku_id" varchar(50) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."sms_sku_attr_value"."spu_attr_value_id" IS '属性值';
COMMENT ON COLUMN "public"."sms_sku_attr_value"."sku_id" IS '库存';

-- ----------------------------
-- Records of sms_sku_attr_value
-- ----------------------------

-- ----------------------------
-- Table structure for ums_user
-- ----------------------------
DROP TABLE IF EXISTS "public"."ums_user";
CREATE TABLE "public"."ums_user" (
  "id" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "user_name" varchar(255) COLLATE "pg_catalog"."default",
  "pwd" varchar(255) COLLATE "pg_catalog"."default",
  "salt" varchar(255) COLLATE "pg_catalog"."default",
  "ocd" timestamp(6),
  "lud" timestamp(6),
  "ocu" varchar(255) COLLATE "pg_catalog"."default",
  "luc" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."ums_user"."user_name" IS '用户名';
COMMENT ON COLUMN "public"."ums_user"."pwd" IS '密码';
COMMENT ON COLUMN "public"."ums_user"."salt" IS '盐值';

-- ----------------------------
-- Records of ums_user
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table bmms_catalog1
-- ----------------------------
ALTER TABLE "public"."bmms_catalog1" ADD CONSTRAINT "BMMS_CATALOG1_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table bmms_catalog2
-- ----------------------------
ALTER TABLE "public"."bmms_catalog2" ADD CONSTRAINT "BMMS_CATALOG2_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table bmms_catalog_attr
-- ----------------------------
ALTER TABLE "public"."bmms_catalog_attr" ADD CONSTRAINT "BMMS_CATALOG_ATTR_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table cms_client
-- ----------------------------
ALTER TABLE "public"."cms_client" ADD CONSTRAINT "CMS_CLIENT_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table common_type
-- ----------------------------
ALTER TABLE "public"."common_type" ADD CONSTRAINT "COMMON_TYPE_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table mms_appointment
-- ----------------------------
ALTER TABLE "public"."mms_appointment" ADD CONSTRAINT "MMS_APPOINTMENT_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table mms_maintain
-- ----------------------------
ALTER TABLE "public"."mms_maintain" ADD CONSTRAINT "MMS_MAINTAIN_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table mms_maintain_oldpart
-- ----------------------------
ALTER TABLE "public"."mms_maintain_oldpart" ADD CONSTRAINT "MMS_MAINTAIN_OLDPART_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table mms_maintain_out
-- ----------------------------
ALTER TABLE "public"."mms_maintain_out" ADD CONSTRAINT "MMS_MAINTAIN_OUT_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table mms_maintain_tool
-- ----------------------------
ALTER TABLE "public"."mms_maintain_tool" ADD CONSTRAINT "MMS_MAINTAIN_TOOL_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table pms_spu
-- ----------------------------
ALTER TABLE "public"."pms_spu" ADD CONSTRAINT "PMS_SPU_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table pms_spu_attr
-- ----------------------------
ALTER TABLE "public"."pms_spu_attr" ADD CONSTRAINT "PMS_SPU_ATTR_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table pms_spu_attr_value
-- ----------------------------
ALTER TABLE "public"."pms_spu_attr_value" ADD CONSTRAINT "PMS_SPU_ATTR_VALUE_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_check
-- ----------------------------
ALTER TABLE "public"."sms_check" ADD CONSTRAINT "SMS_CHECK_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_check_sku
-- ----------------------------
ALTER TABLE "public"."sms_check_sku" ADD CONSTRAINT "SMS_CHECK_SKU_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_entry
-- ----------------------------
ALTER TABLE "public"."sms_entry" ADD CONSTRAINT "SMS_ENTRY_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_entry_sku
-- ----------------------------
ALTER TABLE "public"."sms_entry_sku" ADD CONSTRAINT "SMS_ENTRY_SKU_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_out
-- ----------------------------
ALTER TABLE "public"."sms_out" ADD CONSTRAINT "SMS_OUT_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_out_sku
-- ----------------------------
ALTER TABLE "public"."sms_out_sku" ADD CONSTRAINT "SMS_OUT_SKU_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_sku
-- ----------------------------
ALTER TABLE "public"."sms_sku" ADD CONSTRAINT "SMS_SKU_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_sku_address
-- ----------------------------
ALTER TABLE "public"."sms_sku_address" ADD CONSTRAINT "SMS_SKU_ADDRESS_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sms_sku_attr_value
-- ----------------------------
ALTER TABLE "public"."sms_sku_attr_value" ADD CONSTRAINT "SMS_SKU_ATTR_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table ums_user
-- ----------------------------
ALTER TABLE "public"."ums_user" ADD CONSTRAINT "UMS_USER_pkey" PRIMARY KEY ("id");
