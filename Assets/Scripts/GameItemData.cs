using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemData
{
    private Sprite _sprite = null;
    private int _amount = 0;

    public Sprite ItemSprite => _sprite;
    public int Amount => _amount;

    public GameItemData(Sprite sprite)
    {
        _sprite = sprite;
        _amount = 1;
    }

    public void IncreaseAmount()
    {
        _amount++;
    }

    public bool DecreaseAmount()
    {
        _amount--;

        if (_amount <= 0)
        {
            return false;
        }

        return true;
    }
}
