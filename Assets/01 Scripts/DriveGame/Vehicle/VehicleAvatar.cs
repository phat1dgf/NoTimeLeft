
using System;
using UnityEngine;

public class VehicleAvatar : M_MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _flashColor = Color.red;
    [SerializeField] private float _flashSpeed = 10f;

    private Color _originalColor;
    private bool _isFlashing;

    protected override void Reset()
    {
        base.Reset();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpriteRenderer();
    }

    private void LoadSpriteRenderer()
    {
        if (this._spriteRenderer != null) return;
        this._spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _originalColor = _spriteRenderer.color;
    }
    public void StartFlashing()
    {
        _isFlashing = true;
    }

    public void StopFlashing()
    {
        _isFlashing = false;
        _spriteRenderer.color = _originalColor;
    }

    private void Update()
    {
        if (_isFlashing)
        {
            float t = Mathf.PingPong(Time.time * _flashSpeed, 1f);
            _spriteRenderer.color = Color.Lerp(_originalColor, _flashColor, t);
        }
    }
}
