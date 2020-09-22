using System;
using System.Collections;
using System.Collections.Generic;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Shared.Models;
using Shared.Protocol.Request.Game;
using UnityEngine;

namespace Asgard_SDK.SDK
{
    public class AsgardSDK : MonoBehaviour
    {
        private void Awake()
        {
            //_bootstrap = new AsgardBootstrap(); 
            //Debug.Log("Asgard SDK Loaded");
        }

        private void Init()
        {
            
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                ServiceFactory.Instance.Get<LoginService>().Login(new UserDto(SystemInfo.deviceUniqueIdentifier, "myuser1","mypass2"),
                    dto =>
                    {
                        Debug.Log("identified!");
                    });
            }

            /*
            if (Input.GetKeyUp(KeyCode.A))
            {
                ServiceFactory.Instance.Get<WorldService>().GetWorlds(new GetWorldsRequest());
            }
            */

            if (Input.GetKeyUp(KeyCode.B))
            {
                ServiceFactory.Instance.Get<WorldService>().JoinWorld(new JoinWorldRequest
                {
                    worldId = 3
                });
            }
            
        }
    }
}