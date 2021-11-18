using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Text _textCounter;
    [SerializeField] private Image _image;

    private int _count;

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        _textCounter.text = count.ToString();
    }

    public void Decrease()
    {
        if (--_count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _textCounter.text = _count.ToString();
        }
    }
}
