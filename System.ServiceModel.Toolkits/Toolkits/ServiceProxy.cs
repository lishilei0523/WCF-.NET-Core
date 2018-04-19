// ReSharper disable once CheckNamespace
namespace System.ServiceModel.Toolkits
{
    /// <summary>
    /// WCF服务客户端代理基类
    /// </summary>
    public abstract class ServiceProxy : IDisposable
    {
        #region # 信道实例属性名 —— string ChannelPropertyName
        /// <summary>
        /// 信道实例属性名
        /// </summary>
        public const string ChannelPropertyName = "Channel";
        #endregion

        #region # 释放资源 —— abstract void Dispose()
        /// <summary>
        /// 释放资源
        /// </summary>
        public abstract void Dispose();
        #endregion
    }

    /// <summary>
    /// WCF服务客户端代理
    /// </summary>
    /// <typeparam name="T">服务契约类型</typeparam>
    public sealed class ServiceProxy<T> : ServiceProxy
    {
        #region # 字段及构造器

        /// <summary>
        /// 信道实例
        /// </summary>
        private T _channel;

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object _Sync;

        /// <summary>
        /// 静态构造器
        /// </summary>
        static ServiceProxy()
        {
            ServiceProxy<T>._Sync = new object();
        }

        #endregion

        #region # 只读属性 - 信道 —— T Channel
        /// <summary>
        /// 只读属性 - 信道
        /// </summary>
        public T Channel
        {
            get
            {
                lock (ServiceProxy<T>._Sync)
                {
                    this.Close();

                    ChannelFactory<T> factory = ChannelFactoryManager.Current.GetFactory<T>();
                    this._channel = factory.CreateChannel();

                    return this._channel;
                }
            }
        }
        #endregion

        #region # 关闭客户端信道 —— void Close()
        /// <summary>
        /// 关闭客户端信道
        /// </summary>
        public void Close()
        {
            if (this._channel != null)
            {
                this._channel.CloseChannel();
            }
        }
        #endregion

        #region # 释放资源 —— void Dispose()
        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            this.Close();
        }
        #endregion
    }
}
