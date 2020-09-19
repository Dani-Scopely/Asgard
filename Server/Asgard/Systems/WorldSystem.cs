using System;
using System.Collections.Generic;
using System.Timers;
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
        
        public WorldSystem(WorldDto world)
        {
            _world = world;
            _clientIds = new List<string>();
            _timer = new Timer {Interval = 2000};
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        public void Register(string id)
        {
            Console.WriteLine("R _clientIds: "+_clientIds.Count);
            _clientIds.Add(id);
            Console.WriteLine("R _clientIds: "+_clientIds.Count);
        }

        public void Unregister(string id)
        {
            Console.WriteLine("UNR _clientIds: "+_clientIds.Count);
            _clientIds.Remove(id);
            Console.WriteLine("UNR _clientIds: "+_clientIds.Count);
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