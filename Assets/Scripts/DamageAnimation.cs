using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _xAxisCurve;
    [SerializeField] private AnimationCurve _yAxisCurve;

    [SerializeField] private bool _useXAxis;
    [SerializeField] private bool _useYAxis;
    [SerializeField] private bool _loop;
    [SerializeField] private float _duration;

    private float _elapsedTime;
    private Vector2 _initialScale;

    public void Play()
    {
        _elapsedTime = _duration;
        _initialScale = transform.localScale;
    }

    private void Update()
    {
        if(_elapsedTime > 0f)
        {
            _elapsedTime -= Time.deltaTime;
            UpdateScaleValues();
        }
        else if(_loop)
        {
            _elapsedTime = _duration;
            _initialScale = transform.localScale;
        }
    }
    
    private void UpdateScaleValues()
    {
        float coeff = Mathf.Clamp01(1 - _elapsedTime / _duration);

        float xScaleValue = _useXAxis ? _xAxisCurve.Evaluate(coeff) : 1f;
        float yScaleValue = _useYAxis ? _yAxisCurve.Evaluate(coeff) : 1f;

        transform.localScale = new Vector3(
            _initialScale.x * xScaleValue,
            _initialScale.y * yScaleValue
        );
    }
}
