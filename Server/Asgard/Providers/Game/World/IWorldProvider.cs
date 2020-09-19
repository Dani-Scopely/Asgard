using System.Collections.Generic;
using Shared.Models.Game;

namespace Asgard.Providers.Game.World
{
    public interface IWorldProvider
    {
        List<WorldDto> GetWorlds();
        void UpdateWorld(WorldDto worldDto);
    }
}