using System;
using System.Collections.Generic;
using System.Timers;
using Asgard.Commands.Database;
using Asgard.Providers.Game.World;
using Asgard.Queue;
using Shared.Models.Game;
using Shared.Protocol.Response.Game;

namespace Asgard.Systems
{
    public class WorldSystem
    {
        private Timer _timer;
        private List<string> _clientIds;
        private WorldDto _world;
        private long _hour = 0;
        private UpdateWorldDatabaseCommand _updateWorldCommand;
        
        public WorldSystem(WorldDto world)
        {
            _world = world;
            _clientIds = new List<string>();
            _timer = new Timer {Interval = 2000};
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _updateWorldCommand = new UpdateWorldDatabaseCommand();
        }

        public void Register(string id)
        {
            _clientIds.Add(id);
            _world.numUsers = _clientIds.Count;
            _updateWorldCommand.Build(_world).Execute();
        }

        public void Unregister(string id)
        {
            _clientIds.Remove(id);
            _world.numUsers = _clientIds.Count;
            _updateWorldCommand.Build(_world).Execute();
        }

        public WorldDto GetWorld()
        {
            return _world;
        }
        
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            _hour += 1;
            
            if (_clientIds.Count == 0)
                return;
            
            _clientIds.ForEach( id => { CommandQueueService.Instance.Queue(id, new OnTimeResponse { Hours = _hour, WorldId =  _world.id }); });
        }
    }
}