using System;
using System.Collections.Generic;
using Asgard.Commands.Game;
using Asgard.Providers.User;
using Fleck;
using Newtonsoft.Json;
using Shared.Protocol.Request;
using Shared.Protocol.Request.Game;

namespace Asgard.Commands
{
    public class CommandMapping
    {
        private Dictionary<RequestType, IBaseCommand> _commands;
        private UserProvider _userProvider;
        private IWebSocketConnection _connection;
        
        public CommandMapping(IWebSocketConnection connection)
        {
            _connection = connection;
            
            _userProvider = new UserProvider();
            
            _commands = new Dictionary<RequestType, IBaseCommand>();
            
            _commands.Add(RequestType.LoginRequest, new LoginRequestCommand(ref _userProvider));
            _commands.Add(RequestType.JoinWorldRequest, new JoinWorldCommand());
            _commands.Add(RequestType.GetWorldsRequest, new GetWorldsCommand());
        }

        public void Do(string id, string data)
        {
            var baseRequest = JsonConvert.DeserializeObject<BaseRequest>(data);

            if (_commands.ContainsKey(baseRequest.Type))
            {
                _commands[baseRequest.Type].Execute(id, data);
            }
        }
    }
}