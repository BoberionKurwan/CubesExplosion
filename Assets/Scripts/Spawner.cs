using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public bool isSplit { get; private set; }

    public List<Cube> SpawnCubes(Vector3 centerPosition, float scale, int count, float splitProbability)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_cube);
            cube.transform.position = centerPosition + Random.insideUnitSphere;
            cube.transform.localScale = Vector3.one * scale;
            cube.Initialize(splitProbability);
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody = cube.gameObject.AddComponent<Rigidbody>();
            }

            newCubes.Add(cube);
        }

        isSplit = true;
        return newCubes;
    }
}
