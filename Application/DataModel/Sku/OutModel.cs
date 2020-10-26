using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Sku
{
    public class OutModel : OutAddModel
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

        public IEnumerable<SkuModel> skuList { get; set; } = new List<SkuModel>();
    }
    public class OutUpdateModel : OutAddModel
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
    public class OutAddModel
    {
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        public string OutNo { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OutDate { get; set; }
        public int Batch { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public IEnumerable<OutSkuAddModel> outSkuList { get; set; } = new List<OutSkuAddModel>();
    }
    public class OutSkuAddModel
    {
        public string OutId { get; set; }
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string AddressId { get; set; }
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 状态: 为0新，为1旧
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否是工具，0是配件，1是工具
        /// </summary>
        public int Tool { get; set; }
    }
    public class OutListWithPagingModel
    {
        public int TotalCount { get; set; }
        public IEnumerable<OutModel> Items { get; set; } = new List<OutModel>();
    }
    public class OutPageSearchModel : BaseSearchModel
    {
        /// <summary>
        /// 可以搜索：入库单号，库存名，供应商，操作员，
        /// </summary>
        public string SearchStr { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class OutDeleteModel
    {
        public string Id { get; set; }
        public string OutNo { get; set; }
    }
}
