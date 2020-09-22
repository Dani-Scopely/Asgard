using System;
using System.Collections.Generic;
using Managers;
using StateMachines;
using States;
using UnityEngine;

namespace Modules.UI.Manager
{
    public class UIManager : BaseManager, IStateMachine
    {
        private IUIState _currentState;
        private IUIState _newState;
        private UIManager _instance;
        
        [SerializeField]
        public GameObject authenticationView;
        [SerializeField]
        public GameObject selectWorldView;
        [SerializeField]
        public GameObject loadingView;
        [SerializeField]
        public GameObject topBarView;

        public OnStartAuthenticationState onStartAuthenticationState = new OnStartAuthenticationState();
        
        private void OnEnable()
        {
            _instance = this;
            _currentState = onStartAuthenticationState;
            _currentState.DoState(ref _instance);
        }

        public void SetState(IUIState state)
        {
            if (_currentState == state)
                return;
            
            _currentState = state;
            _currentState.DoState(ref _instance);
        }
    }
}