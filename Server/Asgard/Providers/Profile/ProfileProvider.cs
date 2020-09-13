using Asgard.Providers.Base;
using MySqlConnector;
using Shared.Models;

namespace Asgard.Providers.Profile
{
    public class ProfileProvider : BaseProvider, IProfileProvider
    {
        private const string SqlGetProfileCommand = "SELECT * FROM Profile WHERE userId = @userId";
        private const string SqlInsertProfileCommand = "INSERT INTO Profile (userId,level,sound,music) VALUES (@userId,@level,sound,music)";
        private const string SqlDeleteProfileCommand = "DELETE FROM Profile WHERE userId = @userId";
        private const string SqlUpdateProfileCommand = "UPDATE Profile SET level = @level, sound = @sound, music = @music WHERE userId = @userId";
        
        public ProfileDto GetProfile(ProfileDto profile)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlGetProfileCommand, _connection);
            cmd.Parameters.AddWithValue("userId", profile.UserId);
            var reader = cmd.ExecuteReader();
            
            if (!reader.HasRows)
                return null;

            reader.Read();

            var result = new ProfileDto().Build(reader);
            
            Close();

            return result;
        }

        public ProfileDto InsertProfile(ProfileDto profile)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlInsertProfileCommand, _connection);
            cmd.Parameters.AddWithValue("userId", profile.UserId);
            cmd.Parameters.AddWithValue("level", profile.Level );
            cmd.Parameters.AddWithValue("sound", profile.Sound);
            cmd.Parameters.AddWithValue("music", profile.Music);
            
            var result = cmd.ExecuteNonQuery();

            Close();
            
            return result == -1 ? null : GetProfile(profile);
        }

        public ProfileDto UpdateProfile(ProfileDto profile)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlUpdateProfileCommand, _connection);
            cmd.Parameters.AddWithValue("userId",profile.UserId);
            cmd.Parameters.AddWithValue("level", profile.Level);
            cmd.Parameters.AddWithValue("sound", profile.Sound);
            cmd.Parameters.AddWithValue("music", profile.Music);
            var result = cmd.ExecuteNonQuery();

            Close();
            
            return result == -1 ? null : profile;
        }

        public void DeleteProfile(ProfileDto profile)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlDeleteProfileCommand, _connection);
            cmd.Parameters.AddWithValue("userId", profile.UserId);
            cmd.ExecuteNonQuery();
            
            Close();
        }
    }
}