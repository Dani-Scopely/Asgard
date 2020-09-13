using System;
using System.Collections.Generic;
using Asgard_SDK.SDK.Services;
using Asgard_SDK.SDK.Services.Network;
using Asgard_SDK.SDK.Services.Network.GRPC;
using Asgard_SDK.SDK.Services.Network.HTTP;
using Asgard_SDK.SDK.Services.Network.Websockets;

namespace Asgard_SDK.SDK.Factories
{
    public enum NetworkTransport
    {
        HTTP,
        WEBSOCKETS,
        GRPC
    }
    
    public sealed class NetworkFactory
    {
        private static readonly Lazy<NetworkFactory> Lazy = new Lazy<NetworkFactory>( () => new NetworkFactory());

        public static NetworkFactory Instance => Lazy.Value;

        private readonly Dictionary<NetworkTransport, INetworkTransport> _transports = new Dictionary<NetworkTransport, INetworkTransport>();

        public NetworkFactory()
        {
            _transports.Add(NetworkTransport.HTTP, new HTTPTransport()); 
            _transports.Add(NetworkTransport.WEBSOCKETS, new WebsocketsTransport());
            _transports.Add(NetworkTransport.GRPC, new GRPCTransport());
        }
        
        public INetworkTransport GetTransport(NetworkTransport transport)
        {
            return _transports[transport];
        }
    }
}