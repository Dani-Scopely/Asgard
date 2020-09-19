using System;
using Asgard.Providers.User;
using Asgard.Queue;
using Fleck;
using Newtonsoft.Json;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard.Commands
{
    public class LoginRequestCommand : IBaseCommand
    {
        private readonly UserProvider _userProvider;
        private readonly CommandQueueService _commandQueueService;
        
        public LoginRequestCommand(ref UserProvider userProvider)
        {
            _userProvider = userProvider;
            _commandQueueService = CommandQueueService.Instance;
        }

        public void Execute(string id, string request)
        {
            Console.WriteLine("Executing: "+GetType());
            
            var r = JsonConvert.DeserializeObject<LoginRequest>(request);

            var response = _userProvider.InsertUser(r.User);
            
            _commandQueueService.Queue(id, new LoginResponse { User = response });
        }
    }
}