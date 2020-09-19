using System;

namespace Shared.Protocol.Request.Game
{
    [Serializable]
    public class GetWorldsRequest : BaseRequest
    {
        public GetWorldsRequest()
        {
            Type = RequestType.GetWorldsRequest;
        }
    }
}