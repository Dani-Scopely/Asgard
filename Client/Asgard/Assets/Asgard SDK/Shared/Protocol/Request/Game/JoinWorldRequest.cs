using System;
using Shared.Models;

namespace Shared.Protocol.Request.Game
{
    [Serializable]
    public class JoinWorldRequest : BaseRequest
    {
        public int worldId;
        
        public JoinWorldRequest()
        {
            Type = RequestType.JoinWorldRequest;
        }
    }
}