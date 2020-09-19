using System;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services.Network.HTTP
{
    public class HTTPTransport : INetworkTransport
    {
        public HTTPTransport()
        {
            
        }
        
        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
        
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