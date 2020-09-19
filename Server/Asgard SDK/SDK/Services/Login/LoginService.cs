using System;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services.Network;
using Shared.Models;
using Shared.Protocol.Request;

namespace Asgard_SDK.SDK.Services.Login
{
    public class LoginService : IBaseService
    {
        private readonly NetworkService _network;
        private Action<UserDto> _callback;
        
        public LoginService()
        {
            _network = ServiceFactory.Instance.Get<NetworkService>();
        }
        
        public void Login(UserDto user, Action<UserDto> response)
        {
            _network.Send(new LoginRequest { User = user });
        }
    }
}