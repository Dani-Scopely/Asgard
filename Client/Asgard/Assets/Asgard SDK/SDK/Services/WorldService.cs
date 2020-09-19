using System;
using System.Collections.Generic;
using Shared.Protocol.Request.Game;
using Shared.Protocol.Response;
using Shared.Protocol.Response.Game;
using UnityEngine;

namespace Asgard_SDK.SDK.Services
{
    public class WorldService : IBaseService
    {
        private NetworkService _networkService;

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
                {ResponseType.OnTimeResponse, this},
                {ResponseType.JoinWorldResponse, this},
                {ResponseType.GetWorldsResponse, this},
                {ResponseType.OnEconomyResponse, this}
            };

            _networkService.Register(responseMapping);
        }
        
        public void OnMessage(ResponseType type, string message)
        {
            var baseResponse = JsonUtility.FromJson<BaseResponse>(message);
            
            switch (baseResponse.Type)
            {
                case ResponseType.GetWorldsResponse:
                    OnGetWorldsResponse(JsonUtility.FromJson<GetWorldsResponse>(message));
                    return;
                case ResponseType.JoinWorldResponse:
                    OnJoinWorldResponse(JsonUtility.FromJson<JoinWorldResponse>(message));
                    return;
                default:
                    Debug.Log("ss");
                    return;
            }
        }

        public void JoinWorld(JoinWorldRequest request)
        {
            _networkService.Send(request);
        }

        public void GetWorlds(GetWorldsRequest request)
        {
            _networkService.Send(request);
        }

        private void OnJoinWorldResponse(JoinWorldResponse response)
        {
            Debug.Log("Join world response: "+response);
        }

        private void OnGetWorldsResponse(GetWorldsResponse response)
        {
            Debug.Log("Get worlds response: "+response);
        }
    }
}