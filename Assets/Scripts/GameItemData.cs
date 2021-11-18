using UnityEngine;

public class GameItemData
{
        private Sprite _sprite;
        private int _amount;

        public Sprite Sprite
        {
                get => _sprite;
        }

        public int Amount
        {
                get => _amount;
        }

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
                if (--_amount <= 0)
                {
                        return false;
                }
                else
                {
                        return true;
                }
        }
}