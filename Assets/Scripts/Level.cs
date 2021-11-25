using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private List<GameItem> gameItems = null;
    private int _itemCount = 0;

    public Action OnComplete = null;
    public Action<string> OnItemListChanged = null;

    public void Initialize()
    {
        gameItems = new List<GameItem>(GetComponentsInChildren<GameItem>());
        
        for (int i = 0; i < gameItems.Count; i++)
        {
            gameItems[i].OnFind += OnFindItem;
        }
        _itemCount = gameItems.Count;
    }

    private void OnFindItem(string name)
    {
        if (--_itemCount > 0)
        {
            OnItemListChanged?.Invoke(name);
        }
        else
        {
            OnComplete?.Invoke();
            GameManager.Instance.ChangeGameState(GameState.Win);
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> item = new Dictionary<string, GameItemData>();

        for (int i = 0; i < gameItems.Count; i++)
        {
            var name = gameItems[i].Name;
            if (item.ContainsKey(name))
            {
                item[name].IncreaseAmount();
            }
            else
            {
                item.Add(name, new GameItemData(gameItems[i].ItemSprite));
            }
        }

        return item;
    }
}
