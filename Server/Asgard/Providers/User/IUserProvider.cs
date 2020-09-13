using System.Collections.Generic;
using Shared.Models;

namespace Asgard.Providers.User
{
    public interface IUserProvider
    {
        List<UserDto> GetUsers();
        UserDto GetUser(UserDto user);
        UserDto InsertUser(UserDto user);
        void DeleteUser(UserDto user);
        UserDto UpdateUser(UserDto user);
    }
}