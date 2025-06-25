using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Deleter _deleter;

    private float _scaleMultiplier = 2f;
    private int _minCubesCount = 2;
    private int _maxCubesCount = 7;
    private int _chanceMultiplier = 2;

    private void OnEnable()
    {
        _raycaster.CubeClicked += CubeClicked;
    }

    private void OnDisable()
    {
        _raycaster.CubeClicked -= CubeClicked;
    }

    private void CubeClicked(Cube cube)
    {
        Vector3 position = cube.transform.position;
        float scale = cube.transform.localScale.x / _scaleMultiplier;

        _deleter.DeleteCube(cube);

        int newCubesCount = Random.Range(_minCubesCount, _maxCubesCount);
        List<Cube> newCubes = _spawner.SpawnCubes(position, scale, newCubesCount, cube.SplitChance / _chanceMultiplier);

        _exploder.Explode(position);
    }
}
