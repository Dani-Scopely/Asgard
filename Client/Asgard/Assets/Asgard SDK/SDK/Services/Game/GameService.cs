using System.Collections.Generic;
using BestHTTP.JSON;
using Shared.Protocol.Response;
using Shared.Protocol.Response.Game;
using UnityEngine;

namespace Asgard_SDK.SDK.Services.Game
{
    public delegate void OnTimeResponseCallback(OnTimeResponse response);
    
    public class GameService : IBaseService
    {
        private NetworkService _networkService;

        private OnTimeResponseCallback _onTimeResponse;

        public OnTimeResponseCallback OnTimeResponse
        {
            get => _onTimeResponse;
            set => _onTimeResponse = value;
        }

        public IBaseService Init(ref NetworkService networkService)
        {
            _networkService = networkService;
            InitResponseMap(ref _networkService);
            return this;
        }
        
        private void InitResponseMap(ref NetworkService networkService)
        {
            var responseMapping = new Dictionary<ResponseType, IBaseService>
            {
                {ResponseType.LoginResponse, this}
            };

            _networkService.Register(responseMapping);
        }
        
        public void OnMessage(ResponseType type, string message)
        {
            var baseResponse = JsonUtility.FromJson<BaseResponse>(message);
            
            switch (baseResponse.Type)
            {
                case ResponseType.OnTimeResponse:
                    var response = JsonUtility.FromJson<OnTimeResponse>(message);
                    _onTimeResponse?.Invoke(response);
                    return;
                default:
                    Debug.Log("ss");
                    return;
            }
        }
    }
}