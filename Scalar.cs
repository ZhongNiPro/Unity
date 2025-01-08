using UnityEngine;

public class Scalar : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * _speed, Time.deltaTime);
    }
}
