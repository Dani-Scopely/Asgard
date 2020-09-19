using System.Collections.Generic;
using Shared.Models.Game;

namespace Shared.Protocol.Response.Game
{
    public class GetWorldsResponse : BaseResponse
    {
        public List<WorldDto> worlds;
        
        public GetWorldsResponse()
        {
            Type = ResponseType.GetWorldsResponse;
        }
    }
}