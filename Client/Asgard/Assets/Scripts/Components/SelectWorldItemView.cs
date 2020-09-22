using System;
using System.Collections;
using System.Collections.Generic;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Shared.Models.Game;
using Shared.Protocol.Request.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWorldItemView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name;
    
    [SerializeField]
    private Button _btnJoin;

    private WorldDto _worldDto;
    
    private void OnEnable()
    {
        _btnJoin.onClick.AddListener(OnClickJoin);
    }

    private void OnDisable()
    {
        _btnJoin.onClick.RemoveListener(OnClickJoin);
    }

    public void SetData(WorldDto world)
    {
        _worldDto = world;
        _name.text = _worldDto.name;
    }

    private void OnClickJoin()
    {
        ServiceFactory.Instance.Get<WorldService>().JoinWorld(new JoinWorldRequest { worldId = _worldDto.id });
    }
}
