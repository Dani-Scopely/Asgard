namespace Shared.Protocol.Request
{
    public class BaseRequest
    {
        public RequestType Type;
    }

    public enum RequestType
    {
        LoginRequest,
        JoinWorldRequest,
        GetWorldsRequest
    }
}