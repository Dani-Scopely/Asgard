using System;
using System.Collections.Generic;
using BestHTTP.WebSocket;
using Shared.Protocol.Request;
using Shared.Protocol.Response;
using UnityEngine;

namespace Asgard_SDK.SDK.Services
{
    public class NetworkService
    {
        private Dictionary<ResponseType, IBaseService> _servicesMapping = new Dictionary<ResponseType, IBaseService>();
        
        private WebSocket _webSocket;

        private void OnWebsocketOpen(WebSocket websocket)
        {
            Debug.Log("WebSocket connected: "+websocket);
        }

        private void OnWebsocketMessageReceived(WebSocket webSocket, string message)
        {
            Debug.Log("Message recieived: " + message);
            
            var t = JsonUtility.FromJson<BaseResponse>(message).Type;
            
            if (_servicesMapping.ContainsKey(t))
            {
                _servicesMapping[t].OnMessage(t, message);
            }
            else
            {
                Debug.Log("Unknown key: "+message);
            }
        }

        public void Init()
        {
            _webSocket = new WebSocket(new Uri("ws://127.0.0.1:9000"));
            _webSocket.OnOpen += OnWebsocketOpen;
            _webSocket.OnMessage += OnWebsocketMessageReceived;
            _webSocket.Open();    
        }
        
        public void Send(BaseRequest request)
        {
            _webSocket.Send(JsonUtility.ToJson(request));
        }

        public void Register(Dictionary<ResponseType, IBaseService> mapping)
        {
            foreach (var map in mapping)
            {
               _servicesMapping.Add(map.Key,map.Value); 
            }
        }
    }
}