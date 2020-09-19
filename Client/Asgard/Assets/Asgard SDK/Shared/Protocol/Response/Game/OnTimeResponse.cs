using System;

namespace Shared.Protocol.Response.Game
{
    public class OnTimeResponse : BaseResponse
    {
        public long Hours;
        public int WorldId;

        public OnTimeResponse()
        {
            Type = ResponseType.OnTimeResponse;
        }
    }
}