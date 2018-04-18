using System.ServiceModel.Toolkits.Configurations;

namespace System.ServiceModel.Toolkits.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceModelSection wcfSetting = ServiceModelSection.Setting;

            foreach (EndpointElement endpoint in wcfSetting.EndpointElements.Values)
            {
                Console.WriteLine(endpoint.Name);
                Console.WriteLine(endpoint.Contract);
                Console.WriteLine(endpoint.Address);
                Console.WriteLine(endpoint.Binding);
                Console.WriteLine(endpoint.HeaderProviderElement.Type);
                Console.WriteLine(endpoint.HeaderProviderElement.Assembly);
            }

            Console.ReadKey();
        }
    }
}
