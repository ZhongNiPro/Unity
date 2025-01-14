using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += View;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= View;
    }

    private void View(float value)
    {
        _textCounter.text = value.ToString("");
    }
}
