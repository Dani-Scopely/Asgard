using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services
{
    public interface IBaseService
    {
        void OnMessage(ResponseType type, string message);
        IBaseService Init(ref NetworkService _networkService);
    }
}