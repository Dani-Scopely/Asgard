using System.Collections.Generic;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Modules.UI.Manager;
using Shared.Models.Game;
using Shared.Protocol.Request.Game;
using StateMachines;

namespace States
{
    public class OnRequestWorldsState : IUIState
    {
        private ServiceFactory _serviceFactory;
        private UIManager _uiManager;
        private SessionService _sessionService;
        
        public IUIState DoState(ref UIManager uiManager)
        {
            _uiManager = uiManager;
            _uiManager.loadingView.SetActive(true);
            _uiManager.authenticationView.SetActive(false);
            
            Initialize();
            
            return this;
        }

        private void Initialize()
        {
            _serviceFactory = ServiceFactory.Instance;
            _sessionService = _serviceFactory.Get<SessionService>();
            
            RequestWorlds();
        }

        private void RequestWorlds()
        {
            _serviceFactory.Get<WorldService>().GetWorlds(new GetWorldsRequest(), OnWorldsRequested);
        }

        private void OnWorldsRequested(List<WorldDto> worlds)
        {
            _sessionService.SetWorlds(worlds);
            _uiManager.SetState(new OnResponseWorldsState());
        }
    }
}
