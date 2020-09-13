using Asgard_SDK.SDK.Factories;
using Shared.Protocol.Request;

namespace Asgard_SDK.SDK.Services.Network
{
    public class NetworkService : IBaseService
    {
        private INetworkTransport _transport;
        
        public NetworkService(NetworkTransport transport = NetworkTransport.WEBSOCKETS)
        {
            _transport = NetworkFactory.Instance.GetTransport(transport);
        }

        public void Send(BaseRequest request)
        {
            
        }
    }
}