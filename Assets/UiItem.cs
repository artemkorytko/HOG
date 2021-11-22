using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text counterText;

    private int count;

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void SetCount(int count)
    {
        this.count = count;
        counterText.text = count.ToString();
    }

    public void Decrease()
    {
       
      /*  if(--count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            counterText.text = count.ToString();
        }*/

        count--;
        count = Mathf.Clamp(count, 0, int.MaxValue);
        counterText.text = count.ToString();
        if (count == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
