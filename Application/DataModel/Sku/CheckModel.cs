using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace ViewModel.Sku
{
    public class CheckModel: CheckAddModel
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

        public IEnumerable<CheckSkuModel> CheckSkuList { get; set; } = new List<CheckSkuModel>();
    }
    public class CheckWholeUpdateModel: CheckAddModel
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
    public class CheckAddModel
    {
        public string CheckNo { get; set; }
        public string Operator { get; set; }
        public DateTime CheckDate { get; set; }
        public decimal AccountPrice { get; set; }
        public decimal CheckPrice { get; set; }
        public decimal DifferencePrice { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public IEnumerable<CheckSkuAddModel> checkSkuAddList { get; set; } = new List<CheckSkuAddModel>();
    }
    public class CheckSkuAddModel
    {
        public string CheckId { get; set; }
        public string AddressId { get; set; }
        public int CheckNum { get; set; }
        public decimal CheckPrice { get; set; }
        public decimal Price { get; set; }
        public int AccountNum { get; set; }
        public decimal AccountPrice { get; set; }
        public int DifferenceNum { get; set; }
        public decimal DifferencePrice { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string SkuId { get; set; }
    }

    public class CheckSkuModel : CheckSkuAddModel
    {
        public String Id { get; set; }
        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
        public IEnumerable<SkuAttrModel> AttrList { get; set; } = new List<SkuAttrModel>();
        /// <summary>
        /// 位置
        /// </summary>
        public SkuAddressModel Address { get; set; } = new SkuAddressModel();
    }
    /// <summary>
    /// 可以是入库表的一键更新，也可以是单个或多个的更新
    /// </summary>
    public class CheckUpdateModel
    {
        public string Id { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否已经处理，0为处理，1未处理
        /// </summary>
        //public int status { get; set; }
    }
    public class CheckPageSearchModel : BaseSearchModel
    {
        /// <summary>
        /// 可以搜索：盘点单号，库存名，操作员
        /// </summary>
        public string SearchStr { get; set; }
        /// <summary>
        /// 是否有差错，0不开启，1有差错，2没有差错，再去看status; (0不开启,1差,2无差)
        /// </summary>
        public int Difference { get; set; }
        /// <summary>
        /// 是否处理，0处理，1没处理
        /// </summary>
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class CheckDeleteModel
    {
        public string Id { get; set; }
        public string CheckNo { get; set; }
    }
}
