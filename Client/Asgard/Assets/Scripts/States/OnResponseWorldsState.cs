using System.Collections.Generic;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Modules.UI.Manager;
using Shared.Models.Game;
using StateMachines;

namespace States
{
    public class OnResponseWorldsState : IUIState
    {
        private List<WorldDto> _worlds;
        private UIManager _uiManager;
        private SessionService _sessionService;
        private ServiceFactory _serviceFactory;

        public IUIState DoState(ref UIManager uiManager)
        {
            _uiManager = uiManager;
            _serviceFactory = ServiceFactory.Instance;
            _sessionService = _serviceFactory.Get<SessionService>();
            
            Initialize();
            
            return this;
        }

        private void Initialize()
        {
            _worlds = _sessionService.GetWorlds();
            
            _uiManager.selectWorldView.SetActive(true);
            
            _uiManager.selectWorldView.GetComponent<SelectWorldView>().SetData(_worlds);

            _uiManager.loadingView.SetActive(false);
        }
    }
}
