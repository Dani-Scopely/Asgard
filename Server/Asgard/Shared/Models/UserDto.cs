using System;
using System.Text.Json.Serialization;
using MySqlConnector;
using Newtonsoft.Json;

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
        
        public UserDto Build(MySqlDataReader reader)
        {
            Id = reader.GetString(0);
            Username = reader.GetString(1);
            Password = reader.GetString(2);
            Created = reader.GetDateTime(3);
            
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}