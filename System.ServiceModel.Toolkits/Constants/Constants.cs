using System.Collections.Generic;
using System.ServiceModel.Channels;

// ReSharper disable once CheckNamespace
namespace System.ServiceModel.Toolkits
{
    public static class Constants
    {
        /// <summary>
        /// BasicHttp绑定名
        /// </summary>
        public const string BasicHttpBindingName = "basicHttpBinding";

        /// <summary>
        /// NetTcp绑定名
        /// </summary>
        public const string NetTcpBindingName = "netTcpBinding";

        /// <summary>
        /// BasicHttp绑定实例
        /// </summary>
        public static BasicHttpBinding BasicHttpBinding
        {
            get
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MaxBufferPoolSize = 2147483647;
                binding.MaxReceivedMessageSize = 2147483647;

                TimeSpan defaultSpan = new TimeSpan(0, 10, 0);
                binding.CloseTimeout = defaultSpan;
                binding.OpenTimeout = defaultSpan;
                binding.ReceiveTimeout = defaultSpan;
                binding.SendTimeout = defaultSpan;

                return binding;
            }
        }

        /// <summary>
        /// NetTcp绑定实例
        /// </summary>
        public static NetTcpBinding NetTcpBinding
        {
            get
            {
                NetTcpBinding binding = new NetTcpBinding();
                binding.MaxBufferPoolSize = 2147483647;
                binding.MaxReceivedMessageSize = 2147483647;

                TimeSpan defaultSpan = new TimeSpan(0, 10, 0);
                binding.CloseTimeout = defaultSpan;
                binding.OpenTimeout = defaultSpan;
                binding.ReceiveTimeout = defaultSpan;
                binding.SendTimeout = defaultSpan;

                return binding;
            }
        }

        /// <summary>
        /// 绑定字典
        /// </summary>
        public static readonly IDictionary<string, Binding> AvailableBindings = new Dictionary<string, Binding>
        {
            {"basicHttpBinding", Constants.BasicHttpBinding},
            {"netTcpBinding", Constants.NetTcpBinding}
        };
    }
}
