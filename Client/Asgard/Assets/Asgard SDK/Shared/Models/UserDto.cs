using System;

namespace Shared.Models
{
    [Serializable]
    public class UserDto
    {
        public string Id;
        public string Username;
        public string Password;
        public DateTime Created;

        public UserDto()
        {
            
        }

        public UserDto(string id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}