using System.ServiceModel.Toolkits.Configurations;
using System.ServiceModel.Toolkits.Toolkits;

namespace System.ServiceModel.Toolkits.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (EndpointElement endpoint in ConfigMediator.EndpointElements.Values)
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
