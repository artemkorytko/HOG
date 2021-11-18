using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _prefab;
    
    private Dictionary<string, UIItem> _uiItems = new Dictionary<string, UIItem>();

    public void Initialize(Levels levels)
    {
        GenerateList(levels.GetItemDictionary());
        levels.OnItemListChanged += OnItemListChange;
    }

    private void OnItemListChange(string name)
    {
        if (_uiItems.ContainsKey(name))
        {
            _uiItems[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> dictionary)
    {
        foreach (var key in dictionary.Keys)
        {
            UIItem newItem = Instantiate(_prefab, _content).GetComponent<UIItem>();
            
            newItem.SetSprite(dictionary[key].Sprite);
            newItem.SetCount(dictionary[key].Amount);
            
            _uiItems.Add(key, newItem);
        }
    }
}
