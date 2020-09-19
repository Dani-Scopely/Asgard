using System;
using Asgard.Factories;
using Newtonsoft.Json;
using Shared.Protocol.Request.Game;

namespace Asgard.Commands.Game
{
    public class JoinWorldCommand : IBaseCommand
    {
        public void Execute(string id, string request)
        {
            var worldId = JsonConvert.DeserializeObject<JoinWorldRequest>(request).worldId;
            WorldFactory.Instance.Register(id, worldId);
        }
    }
}