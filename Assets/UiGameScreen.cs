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
        foreach (var key in uiItems.Keys)
        {
            Destroy(uiItems[key].gameObject);
        }
        uiItems.Clear();

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
            GameObject newItem = Instantiate(prefab, content);
            UiItem uiItem = newItem.GetComponent<UiItem>();

            uiItem.SetSprite(dictionary[key].Sprite);
            uiItem.SetCount(dictionary[key].Amount);

            uiItems.Add(key, uiItem);
        }
    }
}
