using UnityEngine;


public class GameItemData
{
    private Sprite sprite;
    private int amount;

    public GameItemData(Sprite sprite)
    {
        this.sprite = sprite;
        amount = 1;
    }

    public Sprite Sprite { get => sprite;}
    public int Amount { get => amount;}

   public void IncreaseAmount()
    {
        amount++;
    }

    public bool DecreaseAmount()
    {
        if(--amount <= 0)
        {
            return false;
        }
        return true;
    }

}

