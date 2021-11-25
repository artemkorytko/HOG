using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameScreen : BasePanel
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _prefab;

    private Dictionary<string, UiItem> uiItems = new Dictionary<string, UiItem>();

    public void Initialize(Level level)
    {
        foreach (var key in uiItems.Keys)
        {
            Destroy(uiItems[key].gameObject);
        }
        uiItems.Clear();
        GenerateList(level.GetItemDictionary());
        level.OnItemListChanged += OnItemListChange;
    }

    private void OnItemListChange(string name)
    {
        if (uiItems.ContainsKey(name))
        {
            uiItems[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> dictionary)
    {
        foreach (var item in dictionary.Keys)
        {
            UiItem newItem = Instantiate(_prefab, _content).GetComponent<UiItem>();
            
            newItem.SetSprite(dictionary[item].Sprite);
            newItem.SetCount(dictionary[item].Amount);

            uiItems.Add(item, newItem);
        }
    }
}
