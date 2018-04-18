using System.Configuration;

namespace System.ServiceModel.Toolkits.Configurations
{
    /// <summary>
    /// 终节点
    /// </summary>
    public class EndpointElement : ConfigurationElement
    {
        #region # 名称 —— string Name
        /// <summary>
        /// 名称
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        #endregion

        #region # 契约 —— string Contract
        /// <summary>
        /// 契约
        /// </summary>
        [ConfigurationProperty("contract", IsRequired = true, IsKey = false)]
        public string Contract
        {
            get { return (string)this["contract"]; }
            set { this["contract"] = value; }
        }
        #endregion

        #region # 地址 —— string Address
        /// <summary>
        /// 地址
        /// </summary>
        [ConfigurationProperty("address", IsRequired = true, IsKey = false)]
        public string Address
        {
            get { return (string)this["address"]; }
            set { this["address"] = value; }
        }
        #endregion

        #region # 绑定 —— string Binding
        /// <summary>
        /// 绑定
        /// </summary>
        [ConfigurationProperty("binding", IsRequired = true, IsKey = false)]
        public string Binding
        {
            get { return (string)this["binding"]; }
            set { this["binding"] = value; }
        }
        #endregion

        #region # 消息头提供者 —— HeaderProviderElement HeaderProviderElement
        /// <summary>
        /// 消息头提供者
        /// </summary>
        [ConfigurationProperty("headerProvider", IsRequired = false, IsKey = false)]
        public HeaderProviderElement HeaderProviderElement
        {
            get { return (HeaderProviderElement)this["headerProvider"]; }
            set { this["headerProvider"] = value; }
        }
        #endregion
    }
}
