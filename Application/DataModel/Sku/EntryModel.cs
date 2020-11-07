using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Maintain;

namespace ViewModel.Sku
{
    public class EntryModel: EntryAddModel
    {
        public string Id { get; set; }
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

        public MaintainEntryShowModel maintainShowModel { get; set; } = new MaintainEntryShowModel();

        public IEnumerable<SkuEntryOrOutModel> skuList { get; set; } = new List<SkuEntryOrOutModel>();
    }
    public class EntryUpdateModel: EntryAddModel
    {
        public string Id { get; set; }
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

    public class EntryAddModel
    {
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        public string EntryNo { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime EntryDate { get; set; }
        public int Batch { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 是否为维修单配件入库 -- 0不是，1是
        /// </summary>
        public int IsMaintain { get; set; }
        /// <summary>
        /// 维修单配件入库时绑定入库单
        /// </summary>
        public string MaintainId { get; set; }
        public IEnumerable<EntrySkuAddModel> entrySkuList { get; set; } = new List<EntrySkuAddModel>(); 
    }

    public class EntrySkuAddModel
    {
        public string EntryId { get; set; }
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string AddressId { get; set; }
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 状态: 为0新，为1旧, 2为工具
        /// </summary>
        public int Status { get; set; }
        public string OldPartId { get; set; }
        public string ToolId { get; set; }
    }
    public class EntryListWithPagingModel
    {
        public int TotalCount { get; set; }
        public IEnumerable<EntryModel> Items { get; set; } = new List<EntryModel>();
    }
    public class EntryPageSearchModel : BaseSearchModel
    {
        /// <summary>
        /// 可以搜索：入库单号，库存名，供应商，操作员，
        /// </summary>
        public string SearchStr { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class EntryDeleteModel
    {
        public string Id { get; set; }
        public string EntryNo { get; set; }
    }
}
