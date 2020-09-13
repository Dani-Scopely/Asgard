using System;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services.Network
{
    public interface INetworkTransport
    {
        BaseResponse Send(BaseRequest request);
        void Receive(Action<BaseResponse> response);
    }
}