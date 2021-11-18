using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameScreen : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject prefab;

    private Dictionary<string, UiItem> uiItems = new Dictionary<string, UiItem>();

    public void Initialize(Level level)
    {
        GenerateList(level.GetItemDataDictionary());
        level.OnItemListChanged += OnItemListChange;
    }

    private void OnItemListChange(string name)
    {
        if(uiItems.ContainsKey(name))
        {
            uiItems[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string,GameItemData> dictionary)
    {
        foreach (var key in dictionary.Keys)
        {
            UiItem newItem = Instantiate(prefab, content).GetComponent<UiItem>();

            newItem.SetSprite(dictionary[key].Sprite);
            newItem.SetCount(dictionary[key].Amount);

            uiItems.Add(key, newItem);
        }
    }
}
