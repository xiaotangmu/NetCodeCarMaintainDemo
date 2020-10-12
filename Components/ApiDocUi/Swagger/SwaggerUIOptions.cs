using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Swashbuckle.AspNetCore.SwaggerUI
{
    /// <summary>
    /// SwaggerUI的配置项
    /// <para>
    /// 以下为默认项
    /// </para>
    /// </summary>
    public class SwaggerUIOptions
    {
        /// <summary>
        /// Gets or sets a route prefix for accessing the swagger-ui
        /// <para>
        /// 访问Api文档的默认路径
        /// </para>
        /// </summary>
        public string RoutePrefix { get; set; } = "api/doc";

        /// <summary>
        /// Gets or sets a Stream function for retrieving the swagger-ui page
        /// </summary>
        public Func<Stream> IndexStream { get; set; } = () => typeof(SwaggerUIOptions).GetTypeInfo().Assembly
            .GetManifestResourceStream("ApiDocUi.Browser.dist.index.html");

        /// <summary>
        /// Gets or sets a title for the swagger-ui page
        /// </summary>
        public string DocumentTitle { get; set; } = "Api Document";

        /// <summary>
        /// Gets or sets additional content to place in the head of the swagger-ui page
        /// <para>
        /// 在<head></head>之间插入内容
        /// </para>
        /// </summary>
        public string HeadContent { get; set; } = "";

        /// <summary>
        /// Gets the JavaScript config object, represented as JSON, that will be passed to the SwaggerUI
        /// </summary>
        public JObject ConfigObject { get; } = JObject.FromObject(new
        {
            urls = new object[] { },
            validatorUrl = JValue.CreateNull()
        });

        /// <summary>
        /// Gets the JavaScript config object, represented as JSON, that will be passed to the initOAuth method
        /// </summary>
        public JObject OAuthConfigObject { get; } = JObject.FromObject(new
        {
        });
    }
}