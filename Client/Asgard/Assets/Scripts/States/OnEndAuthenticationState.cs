using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Components;
using Modules.UI.Manager;
using StateMachines;

namespace States
{
    public class OnEndAuthenticationState : IUIState
    {
        private ServiceFactory _serviceFactory;
        private SessionService _sessionService;
        private UIManager _uiManager;
        
        public IUIState DoState(ref UIManager uiManager)
        {
            _serviceFactory = ServiceFactory.Instance;
            _sessionService = _serviceFactory.Get<SessionService>();
            _uiManager = uiManager;
            
            Initialize();
            
            return this;
        }

        private void Initialize()
        {
            var userDto = _sessionService.GetUserDto();
            
            _uiManager.loadingView.SetActive(false);
            _uiManager.authenticationView.GetComponent<AuthenticationView>().Init(ref _uiManager);
            _uiManager.authenticationView.GetComponent<AuthenticationView>().SetData(userDto);
            _uiManager.authenticationView.SetActive(true);
        }
    }
}
