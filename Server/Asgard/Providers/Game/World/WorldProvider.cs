using System.Collections.Generic;
using Asgard.Providers.Base;
using Asgard.Systems;
using MySqlConnector;
using Shared.Models;
using Shared.Models.Game;

namespace Asgard.Providers.Game.World
{
    public class WorldProvider : BaseProvider, IWorldProvider
    {
        private const string SqlGetWorldsCommand = "SELECT w.id as id, w.name as name, wm.translationKey as translationKey, w.numUsers as numUsers FROM Worlds w, WorldMode wm WHERE w.worldModeId = wm.id";
        
        private List<WorldDto> _mockData;
        
        public WorldProvider()
        {
            MockData();
        }

        public List<WorldDto> GetWorlds()
        {
            Open();
            
            var cmd = new MySqlCommand(SqlGetWorldsCommand, _connection);
            var reader = cmd.ExecuteReader();

            var listWorlds = new List<WorldDto>();

            while (reader.Read())
            {
                listWorlds.Add(new WorldDto
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    translationKey = reader.GetString(2),
                    numUsers = reader.GetInt32(3)
                });
            }

            Close();
            
            return listWorlds;
        }

        public void UpdateWorld(WorldDto worldDto)
        {
            throw new System.NotImplementedException();
        }

        private void MockData()
        {
            _mockData = new List<WorldDto>();
            
            for (int i = 0; i < 10; i++)
            {
                _mockData.Add(new WorldDto
                {
                    id = i,
                    numUsers = 0,
                });
            }
        }
    }
}