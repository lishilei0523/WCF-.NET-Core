using System.Collections.Generic;
using System.ServiceModel.Toolkits.Configurations;

namespace System.ServiceModel.Toolkits.Toolkits
{
    /// <summary>
    /// 配置中介者
    /// </summary>
    public static class ConfigMediator
    {
        /// <summary>
        /// 终结点配置字典字段
        /// </summary>
        private static readonly IDictionary<string, EndpointElement> _EndpointElements;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static ConfigMediator()
        {
            _EndpointElements = new Dictionary<string, EndpointElement>();

            foreach (EndpointElement endpoint in ServiceModelSection.Setting.EndpointElementCollection)
            {
                _EndpointElements.Add(endpoint.Name, endpoint);
            }

        }

        /// <summary>
        /// 终结点配置字典
        /// </summary>
        public static IDictionary<string, EndpointElement> EndpointElements
        {
            get
            {
                return _EndpointElements;
            }
        }
    }
}
