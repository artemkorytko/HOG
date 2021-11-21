using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class GameItem : MonoBehaviour
{
    [Header("Genaral")]
    [SerializeField] private string _name = string.Empty;

    [Header("Settings")]
    [SerializeField] private float _scalingTime = 0.5f;
    [SerializeField] private float _scaleMultiplier = 1.3f;
    [SerializeField] private float _disapearTime = 0.5f;

    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer = null;

    public Sprite ItemSprite => _spriteRenderer.sprite;
    public string Name => _name;
    public Action<string> OnFind = null;

    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        transform.DOScale(transform.localScale * _scaleMultiplier, _scalingTime).OnComplete(() =>
        {
            _spriteRenderer.DOFade(0f, _disapearTime).OnComplete(() =>
            {
                OnFind?.Invoke(_name);
                gameObject.SetActive(false);
            });
        });
    }
}
