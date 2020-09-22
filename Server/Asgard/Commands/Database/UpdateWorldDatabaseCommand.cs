using Asgard.Providers.Game.World;
using Shared.Models.Game;

namespace Asgard.Commands.Database
{
    public class UpdateWorldDatabaseCommand
    {
        private WorldProvider _worldProvider;
        private WorldDto _world;
        
        public UpdateWorldDatabaseCommand Build(WorldDto world)
        {
            _worldProvider = new WorldProvider();
            _world = world;
            return this;
        }

        public void Execute()
        {
            _worldProvider.UpdateWorld(_world);
        }
    }
}