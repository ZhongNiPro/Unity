using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _directionSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scalarSpeed;

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * _scalarSpeed, Time.deltaTime);
        transform.Translate(Vector3.forward * _directionSpeed * Time.deltaTime);
    }
}
