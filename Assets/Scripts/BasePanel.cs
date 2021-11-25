using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public virtual void Open()
    {
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}