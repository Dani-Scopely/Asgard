using System.Collections.Generic;
using Shared.Models;
using Shared.Models.Game;
using Shared.Protocol.Response;

namespace Asgard_SDK.SDK.Services
{
    public class SessionService : IBaseService
    {
        private UserDto _userDto;
        private List<WorldDto> _worldsDto;
        
        public void OnMessage(ResponseType type, string message){}

        public IBaseService Init(ref NetworkService networkService)
        {
            return this;
        }

        public void SetUserDto(UserDto userDto)
        {
            _userDto = userDto;
        }

        public UserDto GetUserDto()
        {
            return _userDto;
        }

        public List<WorldDto> GetWorlds()
        {
            return _worldsDto;
        }

        public void SetWorlds(List<WorldDto> worlds)
        {
            _worldsDto = worlds;
        }
    }
}