using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _impulseMultiplier = 0.3f;

    public void Explode(Vector3 position, List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
                Vector3 randomDirection = Random.insideUnitSphere.normalized;
                rigidbody.AddForce(randomDirection * _explosionForce * _impulseMultiplier, ForceMode.Impulse);
            }
        }
    }
}