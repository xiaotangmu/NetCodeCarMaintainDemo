using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Common;

namespace ViewModel.Sku
{
    /// <summary>
    /// 出入库时用到的skuModel, 此时Id 是entrySku Id
    /// </summary>
    public class SkuEntryOrOutModel : SkuModel
    {
        /// <summary>
        /// 入库出库时用到
        /// </summary>
        public string AddressId { get; set; }
        public string SkuId { get; set; }

    }
    /// <summary>
    /// 出库时用到的skuModel, 此时Id 是entrySku Id
    /// </summary>
    public class SkuOutModel : SkuEntryOrOutModel
    {
       
        public SkuAddressModel AddressModel { get; set; } = new SkuAddressModel();

    }
    public class SkuModel: SkuAddModel
    {
        public string Id { get; set; }
        public string CatalogName { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string OCU { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OCD { get; set; }
        /// <summary>
        /// 最后更新用户
        /// </summary>
        public string LUC { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LUD { get; set; }
    }
    public class SkuAddModel
    {
        public string SpuId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string SkuNo { get; set; }
        /// <summary>
        /// 库存名
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 库存品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 警报值
        /// </summary>
        public int Alarm { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否是工具，工具不作库存报警，0为配件，1为工具
        /// </summary>
        public int Tool { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public string Catalog2Id { get; set; }

        /// <summary>
        /// 库存属性值
        /// </summary>
        public IEnumerable<SkuAttrModel> AttrList = new List<SkuAttrModel>();

        public IEnumerable<SkuAddressModel> addressList = new List<SkuAddressModel>();

    }

    public class SkuListWithPagingViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<SkuModel> Items { get; set; } = new List<SkuModel>();
    }

    /// <summary>
    /// 带条件分页查询的model，不用带条件的分页直接用BaseSearchModel
    /// </summary>
    public class SkuListSearchModel : BaseSearchModel
    {
        public string SearchStr { get; set; }

        public string Catalog2Id { get; set; }
    }

    public class DeleteSkuModel
    {
        public string Id;
        public string SkuName;
    }

    /// <summary>
    /// 库存属性值
    /// </summary>
    public class SkuAttrModel
    {
        public string Id { get; set; }
        public string SpuAttrValueId { get; set; }
        public string AttrName { get; set; }
        public string Value { get; set; }
    }

    public class SkuAddressModel
    {
        public string Id { get; set; }
        public string SpuId { get; set; }
        public string Room { get; set; }
        public string Self { get; set; }
        public int Quantity { get; set; }
   
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string OldPartId { get; set; }
    }

}
