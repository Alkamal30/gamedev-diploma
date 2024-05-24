using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkShadow : MonoBehaviour
{
    public Sprite Sprite;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _opacity;

    private void Start()
    {
        if(Sprite != null)
        {
            _opacity = 0.4f;

            _spriteRenderer.sprite = Sprite;
            SetOpacity(_opacity);
        }
    }

    private void FixedUpdate()
    {
        _opacity -= 0.05f;

        if(_opacity <= 0f)
        {
            Destroy(gameObject);
        }

        SetOpacity(_opacity);
    }

    private void SetOpacity(float opacity)
    {
        _spriteRenderer.color = new Color(
            _spriteRenderer.color.r,
            _spriteRenderer.color.g,
            _spriteRenderer.color.b,
            opacity
        );
    }
}
