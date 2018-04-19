using Autofac;
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
            IContainer container = InitContainer();

            //Calling WCF
            IProductService productService = container.Resolve<IProductService>();
            string products = productService.GetProducts();

            Console.WriteLine(products);

            container.Dispose();
            Console.ReadKey();
        }

        static IContainer InitContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
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

                builder.RegisterType(proxyType).OnRelease(proxy => ((IDisposable)proxy).Dispose());
                builder.Register(container => propChannel.GetValue(container.Resolve(proxyType))).
                    As(type).
                    OnRelease(channel => channel.CloseChannel());
            }

            return builder.Build();
        }
    }
}
