using System;
using System.Collections.Generic;
using Shared.Models.Game;

namespace Shared.Protocol.Response.Game
{
    [Serializable]
    public class GetWorldsResponse : BaseResponse
    {
        public List<WorldDto> worlds;
        
        public GetWorldsResponse()
        {
            Type = ResponseType.GetWorldsResponse;
        }
    }
}