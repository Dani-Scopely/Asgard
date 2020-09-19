using System;
using System.Collections.Generic;
using Asgard.Handlers;
using Fleck;
using Newtonsoft.Json;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard.Queue
{
    public sealed class CommandQueueService
    {
        private static readonly Lazy<CommandQueueService> Lazy = new Lazy<CommandQueueService>  (() => new CommandQueueService());

        public static CommandQueueService Instance => Lazy.Value;

        private Dictionary<string, IWebSocketConnection> _clientHandlers;
        
        private CommandQueueService()
        {
            _clientHandlers = new Dictionary<string, IWebSocketConnection>();    
        }

        public void Register(string id, IWebSocketConnection connection)
        {
            _clientHandlers.Add(id, connection);
        }

        public void Unregister(string id)
        {
            _clientHandlers.Remove(id);
        }

        public void Queue(string id, BaseResponse response)
        {
            Console.WriteLine("Enqueing : "+response.GetType());
            if(!_clientHandlers.ContainsKey(id))
                throw new Exception("This client is not registered");

            _clientHandlers[id].Send(JsonConvert.SerializeObject(response));
        }
    }
}