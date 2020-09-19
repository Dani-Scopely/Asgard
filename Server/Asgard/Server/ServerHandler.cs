using System.Collections.Generic;
using System.Threading;
using Asgard.Handlers;
using Fleck;

namespace Asgard.Server
{
    public class ServerHandler
    {
        private bool _isRunning = true;
        private WebSocketServer _server;
        
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private Dictionary<IWebSocketConnectionInfo,ClientHandler> _connections = new Dictionary<IWebSocketConnectionInfo, ClientHandler>();
        
        public void Start()
        {
            _isRunning = true;

            var t = new Thread(new ThreadStart(InitServer));

            t.Start();
        }

        private void InitServer()
        {
            _server = new WebSocketServer("ws://0.0.0.0:9000") {RestartAfterListenError = true};
            
            _server.Start(socket =>
            {
                _connections.Add(socket.ConnectionInfo,new ClientHandler(socket, OnConnectionClosed));
            });

            _isRunning = true;
        }

        private void OnConnectionClosed(IWebSocketConnectionInfo info)
        {
            _connections.Remove(info);

            if (_connections.Count == 0)
            {
                _isRunning = false;
            }
        }
    }
}