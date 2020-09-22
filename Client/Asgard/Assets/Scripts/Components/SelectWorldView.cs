using System;
using System.Collections;
using System.Collections.Generic;
using Asgard_SDK.SDK.Factories;
using Asgard_SDK.SDK.Services;
using Shared.Models.Game;
using Shared.Protocol.Request.Game;
using UnityEngine;

public class SelectWorldView : MonoBehaviour
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private GameObject _item;

    private List<GameObject> _itemList = new List<GameObject>();

    private List<WorldDto> _worlds;
 
    public void SetData(List<WorldDto> worlds)
    {
        _worlds = worlds;
        
        StartCoroutine(ClearItems());
        StartCoroutine(SetupItems());
    }
    
    IEnumerator ClearItems()
    {
        _itemList.ForEach(Destroy);
        _itemList.Clear();

        yield return new WaitForEndOfFrame();
    }
    
    IEnumerator SetupItems()
    {
        _worlds.ForEach(world =>
        {
            var item = Instantiate(_item, _content);
            item.GetComponent<SelectWorldItemView>().SetData(world);
            _itemList.Add(item);
        });
        
        yield return new WaitForEndOfFrame();
    }

}
