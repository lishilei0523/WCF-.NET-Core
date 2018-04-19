using System.ServiceModel.Channels;
using System.ServiceModel.Toolkits.Interfaces;

namespace WCF.Core.Client.HeaderProviders
{
    /// <summary>
    /// 消息头提供者
    /// </summary>
    public class MyHeaderProvider : IHeaderProvider
    {
        /// <summary>
        /// 获取消息头列表
        /// </summary>
        /// <returns>消息头列表</returns>
        public AddressHeader[] GetHeaders()
        {
            AddressHeader header = AddressHeader.CreateAddressHeader("headerName", "headerNs", "我是消息头");
            return new[] { header };
        }
    }
}
