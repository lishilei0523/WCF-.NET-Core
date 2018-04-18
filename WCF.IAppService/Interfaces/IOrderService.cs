using System.ServiceModel;

namespace WCF.IAppService.Interfaces
{
    /// <summary>
    /// 订单管理服务接口
    /// </summary>
    [ServiceContract]
    public interface IOrderService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns>订单编号</returns>
        [OperationContract]
        void CreateOrder(string orderNo);
    }
}
