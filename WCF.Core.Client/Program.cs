using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Toolkits;
using WCF.IAppService.Interfaces;

namespace WCF.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init Container
            IServiceProvider serviceProvider = InitServiceProvider();

            //Calling WCF
            IProductService productService = serviceProvider.GetService<IProductService>();
            string products = productService.GetProducts();

            Console.WriteLine(products);
            Console.ReadKey();
        }

        static IServiceProvider InitServiceProvider()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            Assembly wcfInterfaceAssembly = Assembly.Load("WCF.IAppService");

            //获取WCF接口类型集
            IEnumerable<Type> types = wcfInterfaceAssembly.GetTypes().Where(type => type.IsInterface);

            //获取服务代理泛型类型
            Type proxyGenericType = typeof(ServiceProxy<>);

            //注册WCF接口
            foreach (Type type in types)
            {
                Type proxyType = proxyGenericType.MakeGenericType(type);
                PropertyInfo propChannel = proxyType.GetProperty(ServiceProxy.ChannelPropertyName, type);

                serviceCollection.AddTransient(proxyType, proxyType);
                serviceCollection.AddTransient(type, factory => propChannel.GetValue(factory.GetService(proxyType)));
            }

            return serviceCollection.BuildServiceProvider();
        }
    }
}
