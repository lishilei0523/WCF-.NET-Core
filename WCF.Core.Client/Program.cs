using System;
using System.ServiceModel;
using WCF.IAppService.Interfaces;

namespace WCF.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //绑定
            NetTcpBinding binding = new NetTcpBinding();
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;

            TimeSpan defaultSpan = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = defaultSpan;
            binding.OpenTimeout = defaultSpan;
            binding.ReceiveTimeout = defaultSpan;
            binding.SendTimeout = defaultSpan;


            //地址
            Uri uri = new Uri(ServiceModelSection.Setting.EndpointElements[typeof(IProductService).FullName].Address);
            EndpointAddress address = new EndpointAddress(uri);


            //信道工厂
            ChannelFactory<IProductService> channelFactory = new ChannelFactory<IProductService>(binding, address);
            IProductService productService = channelFactory.CreateChannel();


            //调用
            string products = productService.GetProducts();

            Console.WriteLine(products);
            Console.ReadKey();
        }
    }
}
