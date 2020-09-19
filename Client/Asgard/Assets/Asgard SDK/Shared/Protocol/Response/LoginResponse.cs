using System;
using Shared.Models;

namespace Shared.Protocol.Response
{
    [Serializable]
    public class LoginResponse : BaseResponse
    {
        public UserDto User;
        
        public LoginResponse()
        {
            Type = ResponseType.LoginResponse;
            Console.WriteLine("TO: "+Type.ToString());
        }
    }
}