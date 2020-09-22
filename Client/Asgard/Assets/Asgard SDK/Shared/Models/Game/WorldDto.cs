using System;

namespace Shared.Models.Game
{
    [Serializable]
    public class WorldDto
    {
        public int id;
        public string name;
        public string translationKey;
        public int numUsers;
    }
}