using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image _image = null;
    [SerializeField] private Text _countText = null;

    private int _count = 0;

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        _countText.text = count.ToString();
    }

    public void Decrease()
    {
        _count--;
        _count = Mathf.Clamp(_count, 0, int.MaxValue);
        _countText.text = _count.ToString();
        if (_count == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
