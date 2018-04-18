using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using WCF.IAppService.Interfaces;

namespace WCF.AppService.Implements
{
    /// <summary>
    /// 集成服务实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class IntegrationService : IIntegrationService
    {
        /// <summary>
        /// 同步物料
        /// </summary>
        public async Task<string> SyncMaterials()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            return "物料列表";
        }
    }
}
