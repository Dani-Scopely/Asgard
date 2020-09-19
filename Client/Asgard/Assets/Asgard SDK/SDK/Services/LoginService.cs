using System;
using System.Collections.Generic;
using BestHTTP.JSON;
using Shared.Models;
using Shared.Protocol.Request;
using Shared.Protocol.Response;
using UnityEngine;

namespace Asgard_SDK.SDK.Services
{
    public class LoginService : IBaseService
    {
        private NetworkService _networkService;
        private Action<UserDto> _onLoginResponse;
        
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
                case ResponseType.LoginResponse:
                    OnLoginResponse(JsonUtility.FromJson<LoginResponse>(message));
                    return;
                default:
                    Debug.Log("ss");
                    return;
            }
        }
        
        public void Login(UserDto user, Action<UserDto> response)
        {
            _onLoginResponse = response;
            _networkService.Send(new LoginRequest { User =  user}); 
        }

        private void OnLoginResponse(LoginResponse response)
        {
            _onLoginResponse?.Invoke(response.User);
        }
    }
}