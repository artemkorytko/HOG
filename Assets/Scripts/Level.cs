using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    private List<GameItem> _gameItems = null;
    private int _itemsCount = 0;

    public Action OnComplete = null;
    public Action<string> OnItemListChanged = null;

    public void Initialize()
    {
        _gameItems = new List<GameItem>(GetComponentsInChildren<GameItem>());

        for (int i = 0; i < _gameItems.Count; i++)
        {
            _gameItems[i].OnFind += OnFindItem;
        }

        _itemsCount = _gameItems.Count;
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

        for (int i = 0; i < _gameItems.Count; i++)
        {
            if (itemsData.ContainsKey(_gameItems[i].Name))
            {
                itemsData[_gameItems[i].Name].IncreaseAmount();
            }
            else
            {
                itemsData.Add(_gameItems[i].Name, new GameItemData(_gameItems[i].ItemSprite));
            }
        }

        return itemsData;
    }

    private void OnFindItem(string name)
    {
        _itemsCount--;

        if (_itemsCount > 0)
        {
            OnItemListChanged?.Invoke(name);
        }
        else
        {
            OnComplete?.Invoke();
        }
    }
}
