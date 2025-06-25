using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Vector3 position, List<Cube> cubes)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
            }
        }
    }
}
