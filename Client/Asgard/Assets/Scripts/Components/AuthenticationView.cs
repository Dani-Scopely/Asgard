using System;
using Asgard_SDK.SDK.Factories;
using Modules.UI.Manager;
using Shared.Models;
using States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class AuthenticationView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _userName;
        [SerializeField]
        private Button _btnPlay;
        
        private UIManager _uiManager;

        private void OnEnable()
        {
            _btnPlay.onClick.AddListener(OnClick);
        }

        public void Init(ref UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void SetData(UserDto userDto)
        {
            var format = _userName.text;
            _userName.text = string.Format(format, userDto.Username);
        }

        private void OnClick()
        {
            _uiManager.SetState(new OnRequestWorldsState());
        }

        private void OnDisable()
        {
            _btnPlay.onClick.RemoveListener(OnClick);
        }
    }
}
