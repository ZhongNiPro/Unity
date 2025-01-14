using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _currentValue;
    private bool _isActive;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    public event Action<float> ValueChanged;

    private void Start()
    {
        _currentValue = 0f;
        _wait = new WaitForSeconds(.5f);
        _isActive = true;
    }

    public void Increase()
    {
        if (_isActive)
        {
            _coroutine = StartCoroutine(IncreaseValue());
            _isActive = false;
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _isActive = true;
        }
    }

    private IEnumerator IncreaseValue()
    {
        while (true)
        {
            _currentValue++;
            ValueChanged.Invoke(_currentValue);

            yield return _wait;
        }
    }
}
