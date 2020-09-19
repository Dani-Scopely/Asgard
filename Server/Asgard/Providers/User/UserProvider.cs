using System;
using System.Collections.Generic;
using Asgard.Providers.Base;
using MySqlConnector;
using Shared.Models;

namespace Asgard.Providers.User
{
    public class UserProvider : BaseProvider, IUserProvider
    {
        private const string SqlGetUsersCommand   = "SELECT * FROM Users";
        private const string SqlGetUserCommand    = "SELECT * FROM Users WHERE id = @id";
        private const string SqlInsertUserCommand = "INSERT INTO Users (id,username,password) VALUES (@id,@username,@password)";
        private const string SqlDeleteUserCommand = "DELETE FROM Users WHERE id = @id";
        private const string SqlUpdateUserCommand = "UPDATE Users SET username = @username, password = @password WHERE id = @id";

        public List<UserDto> GetUsers()
        {
            Open();
            
            var cmd = new MySqlCommand(SqlGetUsersCommand, _connection);
            var reader = cmd.ExecuteReader();

            var listUsers = new List<UserDto>();

            while (reader.Read())
            {
                listUsers.Add(new UserDto
                {
                    Id = reader.GetString(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Created = reader.GetDateTime(3)
                });
            }

            Close();
            
            return listUsers;
        }

        public UserDto GetUser(UserDto user)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlGetUserCommand, _connection);
            cmd.Parameters.AddWithValue("id", user.Id);
            var reader = cmd.ExecuteReader();
            
            if (!reader.HasRows)
                return null;

            reader.Read();

            var result = new UserDto
            {
                Id = reader.GetString(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                Created = reader.GetDateTime(3)
            };
            
            Close();
            
            return result;
        }

        public UserDto InsertUser(UserDto user)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlInsertUserCommand, _connection);
            
            cmd.Parameters.AddWithValue("id", user.Id);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("password", user.Password);

            var result = 0;
            
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (!e.Message.Contains("Duplicate entry"))
                    return null;
            }

            Close();
            
            return result == -1 ? null : GetUser(user);
        }

        public void DeleteUser(UserDto user)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlDeleteUserCommand, _connection);
            cmd.Parameters.AddWithValue("id", user.Id);
            cmd.ExecuteNonQuery();
            
            Close();
        }

        public UserDto UpdateUser(UserDto user)
        {
            Open();
            
            var cmd = new MySqlCommand(SqlUpdateUserCommand, _connection);
            cmd.Parameters.AddWithValue("id", user.Id);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("password", user.Password);
            var result = cmd.ExecuteNonQuery();

            Close();
            
            return result == -1 ? null : user;
        }
    }
}