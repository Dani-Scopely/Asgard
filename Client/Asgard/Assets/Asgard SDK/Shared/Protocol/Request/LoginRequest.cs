using System;
using Shared.Models;

namespace Shared.Protocol.Request
{
    [Serializable]
    public class LoginRequest : BaseRequest
    {
        public UserDto User;
        
        public LoginRequest()
        {
            Type = RequestType.LoginRequest;
        }
    }
}