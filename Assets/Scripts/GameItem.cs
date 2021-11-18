using System;
using UnityEngine;
using DG.Tweening;

public class GameItem: MonoBehaviour
{

    [Header("General"), Space]
    [SerializeField] private string name = string.Empty;

    [Header("References"), Space]
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [Header("Settings"), Space]
    [SerializeField, Tooltip("Модификатор увеличения найденного объекта")] private float targetScaleModification = 1.2f;
    [SerializeField] private float scaleDuration = 0.5f;
    [SerializeField] private float fadeDuration = 0.5f;

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