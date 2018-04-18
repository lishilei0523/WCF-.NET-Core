using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF.IAppService.Interfaces
{
    /// <summary>
    /// 集成服务接口
    /// </summary>
    [ServiceContract]
    public interface IIntegrationService
    {
        /// <summary>
        /// 同步物料
        /// </summary>
        [OperationContract]
        Task<string> SyncMaterials();
    }
}
