using System;
using System.ServiceModel;

namespace WCF.Server.Interfaces
{
    /// <summary>
    /// 商品管理服务接口
    /// </summary>
    [ServiceContract]
    public interface IProductService
    {
        /// <summary>
        /// 获取商品集
        /// </summary>
        /// <returns>商品集</returns>
        [OperationContract]
        string GetProducts();

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="productName">商品名称</param>
        /// <returns>商品Id</returns>
        [OperationContract]
        Guid CreateProduct(string productName);
    }
}
