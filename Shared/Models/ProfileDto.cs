using System;

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
    }
}