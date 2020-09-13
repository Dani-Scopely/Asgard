using System;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services.Network.Websockets
{
    public class WebsocketsTransport : INetworkTransport
    {
        public BaseResponse Send(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public void Receive(Action<BaseResponse> response)
        {
            throw new NotImplementedException();
        }
    }
}