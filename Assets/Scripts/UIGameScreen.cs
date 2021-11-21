using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _contentContainer = null;
    [SerializeField] private GameObject _itemPrefab = null;

    private Dictionary<string, UIItem> _uiItems = new Dictionary<string, UIItem>();

    public void Initialize(Level level)
    {
        foreach(var key in _uiItems.Keys)
        {
            Destroy(_uiItems[key].gameObject);
        }
        _uiItems.Clear();

        GenerateList(level.GetItemDictionary());
        level.OnItemListChanged += ItemListChanged;
    }

    private void GenerateList(Dictionary<string, GameItemData> items)
    {
        foreach(var key in items.Keys)
        {
            GameObject newItem = Instantiate(_itemPrefab, _contentContainer);
            UIItem uiItem = newItem.GetComponent<UIItem>();

            uiItem.SetSprite(items[key].ItemSprite);
            uiItem.SetCount(items[key].Amount);

            _uiItems.Add(key, uiItem);
        }
    }

    private void ItemListChanged(string name)
    {
        if (_uiItems.ContainsKey(name))
        {
            _uiItems[name].Decrease();
        }
    }
}
