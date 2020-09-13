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
            Id = Guid.NewGuid().ToString();
        }

        public UserDto(string username, string password)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
            Password = password;
        }
    }
}