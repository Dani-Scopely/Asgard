using System.Collections.Generic;
using Asgard.Providers.Game.World;
using Shared.Models.Game;

namespace Asgard.Commands.Database
{
    public class GetWorldsDatabaseCommand
    {
        private WorldProvider _worldProvider;
        
        public GetWorldsDatabaseCommand Build()
        {
            _worldProvider = new WorldProvider();
            return this;
        }

        public List<WorldDto> Execute()
        {
            return _worldProvider.GetWorlds();
        }
    }
}