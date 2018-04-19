using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Toolkits.Configurations;
using System.ServiceModel.Toolkits.Interfaces;
using System.ServiceModel.Toolkits.Toolkits;

// ReSharper disable once CheckNamespace
namespace System.ServiceModel.Toolkits
{
    /// <summary>
    /// ChannelFactory管理者
    /// </summary>
    internal sealed class ChannelFactoryManager : IDisposable
    {
        #region # 字段及构造器

        /// <summary>
        /// 信道工厂幂等字典
        /// </summary>
        private static readonly IDictionary<Type, ChannelFactory> _Factories;

        /// <summary>
        /// 信道工厂管理者单例
        /// </summary>
        private static readonly ChannelFactoryManager _Current;

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object _Sync;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static ChannelFactoryManager()
        {
            ChannelFactoryManager._Factories = new Dictionary<Type, ChannelFactory>();
            ChannelFactoryManager._Current = new ChannelFactoryManager();
            ChannelFactoryManager._Sync = new object();
        }

        /// <summary>
        /// 私有化构造器
        /// </summary>
        private ChannelFactoryManager() { }

        #endregion


        //Public

        #region # 访问器 —— static ChannelFactoryManager Current
        /// <summary>
        /// 访问器
        /// </summary>
        public static ChannelFactoryManager Current
        {
            get { return ChannelFactoryManager._Current; }
        }
        #endregion

        #region # 获取给定服务契约类型的ChannelFactory实例 —— ChannelFactory<T> GetFactory<T>()
        /// <summary>
        /// 获取给定服务契约类型的ChannelFactory实例
        /// </summary>
        /// <typeparam name="T">服务契约类型</typeparam>
        /// <returns>给定服务契约类型的ChannelFactory实例</returns>
        public ChannelFactory<T> GetFactory<T>()
        {
            lock (ChannelFactoryManager._Sync)
            {
                ChannelFactory factory = null;
                try
                {
                    if (!ChannelFactoryManager._Factories.TryGetValue(typeof(T), out factory))
                    {
                        Binding binding = this.GetBinding<T>();
                        EndpointAddress address = this.GetEndpointAddress<T>();

                        factory = new ChannelFactory<T>(binding, address);
                        ChannelFactoryManager._Factories.Add(typeof(T), factory);
                    }

                    return factory as ChannelFactory<T>;
                }
                catch
                {
                    if (factory != null)
                    {
                        factory.CloseChannel();
                    }
                    throw;
                }

            }
        }
        #endregion

        #region # 释放资源 —— void Dispose()
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            lock (ChannelFactoryManager._Sync)
            {
                foreach (Type type in ChannelFactoryManager._Factories.Keys)
                {
                    ChannelFactory factory = ChannelFactoryManager._Factories[type];
                    if (factory != null)
                    {
                        factory.CloseChannel();
                    }
                }
                ChannelFactoryManager._Factories.Clear();
            }
        }
        #endregion


        //Private

        #region # 获取绑定实例 —— Binding GetBinding<T>()
        /// <summary>
        /// 获取绑定实例
        /// </summary>
        /// <returns>绑定实例</returns>
        private Binding GetBinding<T>()
        {
            string configName = typeof(T).FullName;

            if (!ConfigMediator.EndpointElements.ContainsKey(configName))
            {
                throw new NullReferenceException($"名称为\"{configName}\"的终结点未配置！");
            }

            EndpointElement endpointElement = ConfigMediator.EndpointElements[configName];

            if (!Constants.AvailableBindings.ContainsKey(endpointElement.Binding))
            {
                throw new InvalidOperationException($"目前不支持\"{endpointElement.Binding}\"绑定！");
            }

            Binding currentBinding = Constants.AvailableBindings[endpointElement.Binding];

            return currentBinding;
        }
        #endregion

        #region # 获取终结点地址 —— EndpointAddress GetEndpointAddress<T>()
        /// <summary>
        /// 获取终结点地址
        /// </summary>
        /// <returns>终结点地址</returns>
        private EndpointAddress GetEndpointAddress<T>()
        {
            string configName = typeof(T).FullName;

            if (!ConfigMediator.EndpointElements.ContainsKey(configName))
            {
                throw new NullReferenceException($"名称为\"{configName}\"的终结点未配置！");
            }

            EndpointElement endpointElement = ConfigMediator.EndpointElements[configName];
            Uri uri = new Uri(endpointElement.Address);
            AddressHeader[] addressHeaders = null;

            if (endpointElement.HeaderProviderElement != null &&
                !string.IsNullOrWhiteSpace(endpointElement.HeaderProviderElement.Type) &&
                !string.IsNullOrWhiteSpace(endpointElement.HeaderProviderElement.Assembly))
            {
                Assembly assembly = Assembly.Load(endpointElement.HeaderProviderElement.Assembly);
                Type type = assembly.GetType(endpointElement.HeaderProviderElement.Type);

                if (!typeof(IHeaderProvider).IsAssignableFrom(type))
                {
                    throw new InvalidOperationException($"类型\"{type.FullName}\"未实现接口\"IHeaderProvider\"！");
                }

                IHeaderProvider headerProvider = (IHeaderProvider)Activator.CreateInstance(type);
                addressHeaders = headerProvider.GetHeaders();
            }

            EndpointAddress address = new EndpointAddress(uri, addressHeaders ?? new AddressHeader[0]);

            return address;
        }
        #endregion
    }
}
