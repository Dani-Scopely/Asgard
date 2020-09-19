using System;
using System.Diagnostics;
using Asgard.Commands;
using Asgard.Factories;
using Asgard.Queue;
using Asgard.Systems;
using Fleck;
using MongoDB.Driver;

namespace Asgard.Handlers
{
    public class ClientHandler
    {
        private ClientHandler _instance;
        private readonly IWebSocketConnection _connection;
        private readonly Action<IWebSocketConnectionInfo> _clientHandler;
        private readonly CommandMapping _commandMapping;

        //private CommandService _commandService;
        
        private bool _isConnected;
        
        public bool IsConnected => _isConnected;

        private string _clientId;

        public string ClientId
        {
            get { return _clientId; }
        }

        public ClientHandler(IWebSocketConnection connection, Action<IWebSocketConnectionInfo> clientHandler)
        {
            connection.OnClose += Close;
            
            _clientId = connection.ConnectionInfo.Id.ToString();
            
            _instance = this;

            _connection = connection;
            _clientHandler = clientHandler;
            _commandMapping = new CommandMapping(_connection);
            
            _isConnected = true;
            
            _connection.OnMessage += OnMessage;
            
            Console.WriteLine("New socket! : "+_clientId);
          
            //WorldFactory.Instance.Register(_clientId);
            
            CommandQueueService.Instance.Register(_clientId, _connection);
        }
 
        private void Close()
        {
            Console.WriteLine("Closing connection with "+_clientId);
            
            CommandQueueService.Instance.Unregister(_clientId);
            WorldFactory.Instance.Unregister(_clientId);
            
            _clientHandler(_connection.ConnectionInfo);
            _connection.Close();
            _isConnected = false;
        }

        public void Send(string response)
        {
            _connection.Send(response);
        }

        public void Send(byte[] response)
        {
            _connection.Send(response);
        }

        private void OnMessage(string message)
        {
            _commandMapping.Do(_clientId, message);
        }
    }
}