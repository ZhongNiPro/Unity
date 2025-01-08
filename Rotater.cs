using UnityEngine;

public class Rotor : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, _speed, 0);
    }
}
