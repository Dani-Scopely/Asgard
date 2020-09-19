namespace Shared.Protocol.Response
{
    public class BaseResponse
    {
        public ResponseType Type;
    }

    public enum ResponseType
    {
        LoginResponse,
        JoinWorldResponse,
        GetWorldsResponse,
        OnEconomyResponse,
        OnTimeResponse
    }
}