using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Modules.UI.Manager;
using Shared.Models;
using StateMachines;
using UnityEngine;

namespace States
{
    public class OnStartAuthenticationState : IUIState
    {
        private ServiceFactory _serviceFactory;
        private UIManager _uiManager;
        
        public IUIState DoState(ref UIManager uiManager)
        {
            _uiManager = uiManager;
            _uiManager.loadingView.SetActive(true);

            Initialize();
            
            return this;
        }

        private void Initialize()
        {
            _serviceFactory = ServiceFactory.Instance;
            
            _serviceFactory.Init(OnReady);
        }

        private void OnReady(bool isReady)
        {
            _serviceFactory.Get<LoginService>().Login(CreateUser(), OnLoginResponse);
        }

        private void OnLoginResponse(UserDto userDto)
        {
            _serviceFactory.Get<SessionService>().SetUserDto(userDto);
            
            _uiManager.SetState(new OnEndAuthenticationState());
        }
        
        private UserDto CreateUser()
        {
            return new UserDto(SystemInfo.deviceUniqueIdentifier, "myuser1", "mypass2");
        }
    }
}
