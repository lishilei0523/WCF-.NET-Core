using System;
using System.ServiceModel;
using WCF.AppService.Implements;

namespace WCF.Host
{
    class Program
    {
        static void Main()
        {
            ServiceHost productSvcHost = new ServiceHost(typeof(ProductService));
            ServiceHost orderSvcHost = new ServiceHost(typeof(OrderService));
            ServiceHost integrationHost = new ServiceHost(typeof(IntegrationService));

            productSvcHost.Open();
            orderSvcHost.Open();
            integrationHost.Open();

            Console.WriteLine("服务已启动...");
            Console.ReadLine();
        }
    }
}
