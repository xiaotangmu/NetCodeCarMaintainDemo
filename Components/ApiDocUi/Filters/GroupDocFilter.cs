using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ApiDocUi.Filters
{
    /// <summary>
    /// 通过特性描述 api分组
    /// <para>
    /// 满足如下路由规则格式：api/modulename/controller/action
    /// </para>
    /// </summary>
    public class GroupDocFilter: IDocumentFilter
    {

        string _strXmlPath = string.Empty;
        public GroupDocFilter() { }

        public GroupDocFilter(string strXmlPath)
        {
            _strXmlPath = strXmlPath;
        }

        /// <summary>
        /// 获取模块信息（及分组信息）
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //承载模块分组名称的容器（分组列表）
            HashSet<string> moduleList = new HashSet<string>();

            //控制器描述（分组列表描述）
            //ConcurrentDictionary<string, string> controllerDescDict = new ConcurrentDictionary<string, string>();
            List<Tag> tags = new List<Tag>();

            //获取控制器分组及分组列表描述
            if (File.Exists(this._strXmlPath))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(this._strXmlPath);
                string type = String.Empty, path = String.Empty, controllerName = String.Empty;
                string[] arrPath;
                int length = -1, cCount = "Controller".Length;
                XmlNode summaryNode = null;
                foreach (XmlNode node in xmldoc.SelectNodes("//member"))
                {
                    type = node.Attributes["name"].Value;
                    if (type.StartsWith("T:"))
                    {
                        //控制器
                        arrPath = type.Split('.');
                        length = arrPath.Length;
                        controllerName = arrPath[length - 1];
                        if (controllerName.EndsWith("Controller"))
                        {
                            //模块信息
                            var moduleName = arrPath[length - 2];
                            moduleList.Add(moduleName);

                            //获取控制器注释
                            summaryNode = node.SelectSingleNode("summary");
                            string key = controllerName.Remove(controllerName.Length - cCount, cCount);
                            if (summaryNode != null && !String.IsNullOrEmpty(summaryNode.InnerText)
                                && !tags.Exists(new Predicate<Tag>((x)=> {
                                    return x.Name.Equals(key);
                                }))
                                //&& !controllerDescDict.ContainsKey(key)
                                )
                            {
                                tags.Add(new Tag { Name = key, Description = summaryNode.InnerText.Trim() });
                                //controllerDescDict.TryAdd(key, summaryNode.InnerText.Trim());
                            }
                        }
                    }
                }
            }
            //swaggerDoc.Extensions.Add("ControllerDesc", controllerDescDict);

            swaggerDoc.Tags = tags;
            swaggerDoc.Extensions.Add("AreaDescription", moduleList);

        }
    }
}
