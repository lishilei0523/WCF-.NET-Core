using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

// ReSharper disable once CheckNamespace
namespace WCFTools
{
    public static class Constants
    {
        public static readonly IDictionary<string, Binding> AvailableBindings = new Dictionary<string, Binding>
        {
            {"basicHttpBinding", new BasicHttpBinding()},
            {"netTcpBinding", new NetTcpBinding()}
        };
    }
}
