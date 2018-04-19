using System;
using System.ServiceModel.Toolkits;
using WCF.IAppService.Interfaces;

namespace WCF.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //信道工厂
            ServiceProxy<IProductService> serviceProxy = new ServiceProxy<IProductService>();
            IProductService productService = serviceProxy.Channel;

            //调用
            string products = productService.GetProducts();

            Console.WriteLine(products);
            Console.ReadKey();
        }
    }
}
