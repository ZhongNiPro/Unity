using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spliter : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject[] _walls;

    private List<GameObject> _newCubes;

    private void Start()
    {
        _newCubes = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                GameObject cube = hit.transform.gameObject;
                float scaleValue = hit.transform.localScale.x;

                if (_walls.Contains(cube))
                    return;

                Split(cube, scaleValue);
                Destroy(cube);
            }
        }
    }

    private void Split(GameObject currentCube, float scaleValue)
    {
        int minCount = 2;
        int maxCount = 6;
        int scaleRate = 2;
        float correctionRate = 0.5f;

        int randomCount = Random.Range(minCount, maxCount + 1);

        Vector3 explodePosition = currentCube.transform.position;

        List<GameObject> splitedCubes = new List<GameObject>();

        if (scaleValue >= Random.value)
        {
            scaleValue /= scaleRate;

            for (int i = 0; i < randomCount; i++)
            {
                float randomX = Random.value + currentCube.transform.position.x - correctionRate;
                float randomY = Random.value + currentCube.transform.position.y;
                float randomZ = Random.value + currentCube.transform.position.z - correctionRate;

                Vector3 position = new Vector3(randomX, randomY, randomZ);

                GameObject newCube = Instantiate(_cube, position, Quaternion.identity);

                newCube.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
                newCube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);

                splitedCubes.Add(newCube);
            }
        }

        Explode(splitedCubes, explodePosition);
        _newCubes.AddRange(splitedCubes);
    }

    private void Explode(List<GameObject> cubes, Vector3 position)
    {
        float explosionForce = 1000;
        float explosionRadius = 10;

        foreach (GameObject cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, position, explosionRadius);
        }
    }
}
