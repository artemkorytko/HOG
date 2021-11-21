using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

internal class GameItem : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private new string name = string.Empty;
    [Header("Settings"), Space]
    [SerializeField] private float targetScaleModification = 1.2f;
    [SerializeField] private float scaleDuration = 0.5f;
    [SerializeField] private float fadeDuration = .5f;
    
    private BoxCollider2D _boxCollider2D;

    public Action<string> OnFind;

    public string Name => name;
    public Sprite ItemSprite => spriteRenderer.sprite;

    private void Awake()
    {
        _boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        transform.DOScale(transform.localScale * targetScaleModification, scaleDuration).OnComplete(() =>
        {
            spriteRenderer.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                OnFind?.Invoke(Name);
                gameObject.SetActive(false);
            });
        });
    }
    
}