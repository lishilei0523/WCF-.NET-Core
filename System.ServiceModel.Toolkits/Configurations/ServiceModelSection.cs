using System.Configuration;
using System.ServiceModel.Toolkits.Configurations;

// ReSharper disable once CheckNamespace
namespace System.ServiceModel
{
    /// <summary>
    /// WCF配置
    /// </summary>
    public class ServiceModelSection : ConfigurationSection
    {
        #region # 字段及构造器

        /// <summary>
        /// 单例
        /// </summary>
        private static readonly ServiceModelSection _Setting;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static ServiceModelSection()
        {
            ServiceModelSection._Setting = (ServiceModelSection)ConfigurationManager.GetSection("system.serviceModel");

            #region # 非空验证

            if (ServiceModelSection._Setting == null)
            {
                throw new ApplicationException("WCF节点未配置，请检查程序！");
            }

            #endregion
        }

        #endregion

        #region # 访问器 —— static RedisConfiguration Setting
        /// <summary>
        /// 访问器
        /// </summary>
        public static ServiceModelSection Setting
        {
            get { return ServiceModelSection._Setting; }
        }
        #endregion

        #region # 终节点列表 —— EndpointElementCollection EndpointElementCollection
        /// <summary>
        /// 终节点列表
        /// </summary>
        [ConfigurationProperty("client")]
        [ConfigurationCollection(typeof(EndpointElementCollection), AddItemName = "endpoint")]
        internal EndpointElementCollection EndpointElementCollection
        {
            get
            {
                EndpointElementCollection collection = this["client"] as EndpointElementCollection;
                return collection ?? new EndpointElementCollection();
            }
            set { this["client"] = value; }
        }
        #endregion
    }
}
