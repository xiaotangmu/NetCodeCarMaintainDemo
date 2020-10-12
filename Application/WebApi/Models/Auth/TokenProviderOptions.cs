namespace WebApi.Models.Auth
{
    /// <summary>
    /// token提供属性
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// 发行人（例如那台机器分发）
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 允许使用的角色
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间间隔
        /// </summary>
        public int Expiration { get; set; } = 30;
        /// <summary>
        /// 签名证书
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// reflesh_token过期时间
        /// </summary>
        public int ReExpiration { get; set; }
    }
}
