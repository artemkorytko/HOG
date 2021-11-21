using System;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Action OnComplete;
    public Action<string> OnItemListChanged;
        
    private List<GameItem> _gameItems = null;
    private int _itemCount = 0;
    public void Initialize()
    {
        _gameItems = new List<GameItem>(GetComponentsInChildren<GameItem>());

        foreach (var gameItem in _gameItems)
        {
            gameItem.OnFind += OnFindItem;
        }
        
        _itemCount = _gameItems.Count;
    }

    private void OnFindItem(string name)
    {
        if (--_itemCount > 0)
        {
            OnItemListChanged?.Invoke(name);
        }
        else
        {
            OnItemListChanged?.Invoke(name);
            OnComplete?.Invoke();
        }
    }
    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> item = new Dictionary<string, GameItemData>();

        for (int i = 0; i < _gameItems.Count; i++)
        {
            if (item.ContainsKey(_gameItems[i].Name))
            {
                item[_gameItems[i].Name].IncreaseAmount();
            }
            else
            {
                item.Add(_gameItems[i].Name, new GameItemData(_gameItems[i].ItemSprite));
            }
        }
        
        return item;
    }

}

