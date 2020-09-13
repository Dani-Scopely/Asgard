using System.Data;
using Asgard.Configuration;
using MySqlConnector;

namespace Asgard.Providers.Base
{
    public class BaseProvider
    {
        protected readonly MySqlConnection _connection;
        
        protected BaseProvider(string url = null)
        {
            _connection = new MySqlConnection(url ?? DatabaseConfig.Url);
        }
        
        protected void Open()
        {
            if(_connection.State != ConnectionState.Open)
                _connection.Open();
        }

        protected void Close()
        {
            if(_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}