using Asgard_SDK.SDK.Factories;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services.Network
{
    public delegate void OnMessageDelegate(BaseResponse response);
    
    public class NetworkService : IBaseService
    {
        private INetworkTransport _transport;
        private OnMessageDelegate _onMessage;
        
        public OnMessageDelegate OnMessage
        {
            get { return _onMessage; }
            set { _onMessage = value; }
        }
        
        public NetworkService(NetworkTransport transport = NetworkTransport.WEBSOCKETS)
        {
            _transport = NetworkFactory.Instance.GetTransport(transport);
        }

        public void Send(BaseRequest request)
        {
            
        }
    }
}