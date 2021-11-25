using UnityEngine;

public class GameItemData
{
    private Sprite sprite;
    private int amount;

    public Sprite Sprite { get => sprite; }
    public int Amount { get => amount; }

    public GameItemData(Sprite sprite)
    {
        this.sprite = sprite;
        amount = 1;
    }

    public void IncreaseAmount()
    {
        amount++;
    }

    public bool DecreaseAmount()
    {
        return --amount > 0;
    }
}
