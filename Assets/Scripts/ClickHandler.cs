using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Deleter _deleter;

    private float _scaleMultiplier = 2f;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 7;

    private float _splitChance = 100;
    private float _chanceMultiplier = 0.5f;
    private bool _isSplit = true;

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

        int newCubesCount = Random.Range(_minCubesCount, _maxCubesCount);
        float newSplitChance = cube.SplitChance * _chanceMultiplier;

        if (Random.value >= newSplitChance /100)
        {
            List<Cube> newCubes = _spawner.SpawnCubes(position, scale, newCubesCount, newSplitChance);

            _exploder.Explode(position, newCubes);
            _deleter.DeleteCube(cube);
        }
    }
}
