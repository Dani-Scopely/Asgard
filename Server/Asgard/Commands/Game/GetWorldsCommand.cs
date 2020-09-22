using System;
using Asgard.Commands.Database;
using Asgard.Providers.Game.World;
using Asgard.Queue;
using Shared.Protocol.Response.Game;

namespace Asgard.Commands.Game
{
    public class GetWorldsCommand : IBaseCommand
    {
        private readonly CommandQueueService _commandQueueService;
        
        public GetWorldsCommand()
        {
            _commandQueueService = CommandQueueService.Instance;
        }
        
        public void Execute(string id, string request)
        {
            var worlds = new GetWorldsDatabaseCommand().Build().Execute();
            _commandQueueService.Queue(id, new GetWorldsResponse { worlds = worlds});
        }
    }
}