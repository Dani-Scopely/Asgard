using Shared.Models;

namespace Asgard.Providers.Profile
{
    public interface IProfileProvider
    {
        ProfileDto GetProfile(ProfileDto user);
        ProfileDto InsertProfile(ProfileDto profile);
        ProfileDto UpdateProfile(ProfileDto profile);
        void DeleteProfile(ProfileDto profile);
    }
}