using DG.Tweening;
using System;
using UnityEngine;

public  class GameItem : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private new string name = string.Empty;

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [Header("Animation settings")]
    [SerializeField] private float targetScaleModification = 1.2f;
    [SerializeField] private float scaleDuration = .5f;
    [SerializeField] private float fadeDuration = .5f;

    private BoxCollider2D boxCollider = null;

    public Sprite ItemSprite => spriteRenderer.sprite;

    public string Name => name;
    public Action<string> OnFind = null;

    private void Awake()
    {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        OnFind?.Invoke(Name);
        gameObject.SetActive(false);
        transform.DOScale(transform.localScale * targetScaleModification, scaleDuration).OnComplete(() =>
        {
            spriteRenderer.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                
            });
        });
    }
}