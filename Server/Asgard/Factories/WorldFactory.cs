using System;
using System.Collections.Generic;
using System.Linq;
using Asgard.Providers.Game.World;
using Asgard.Systems;

namespace Asgard.Factories
{
    public sealed class WorldFactory
    {
        private static readonly Lazy<WorldFactory> Lazy = new Lazy<WorldFactory>( () => new WorldFactory());

        public static WorldFactory Instance => Lazy.Value;

        private List<WorldSystem> _worldList;
        private WorldProvider _worldProvider;
        
        private WorldFactory()
        {
            _worldList = new List<WorldSystem>();
            
            Init();
        }

        private void Init()
        {
            _worldProvider = new WorldProvider();
            
            _worldProvider.GetWorlds().ForEach(world =>
            {
                _worldList.Add(new WorldSystem(world));
            });
        }

        public void Register(string id, int worldId)
        {
            // If the client is already registered, it's unregistered from other worlds
            Unregister(id);
            
            _worldList.First( world => world.GetWorld().id == worldId).Register(id);
        }

        public void Unregister(string id)
        {
            _worldList.ForEach(world => world.Unregister(id));
        }
    }
}