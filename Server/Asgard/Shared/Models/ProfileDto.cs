using System;
using MySqlConnector;

namespace Shared.Models
{
    [Serializable]
    public class ProfileDto
    {
        public string UserId;
        public int Level;
        public bool Sound;
        public bool Music;

        public ProfileDto()
        {
            
        }
        
        public ProfileDto(string userId, int level = 1, bool sound = true, bool music = true)
        {
            UserId = userId;
            Level = level;
            Sound = sound;
            Music = music;
        }

        public ProfileDto Build(MySqlDataReader reader)
        {
            var profile = new ProfileDto
            {
                UserId = reader.GetString(0),
                Level = reader.GetInt32(1),
                Sound = reader.GetBoolean(2),
                Music = reader.GetBoolean(3)
            };

            return profile;
        }
    }
}