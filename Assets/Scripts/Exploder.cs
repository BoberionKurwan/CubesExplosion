using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

            foreach (Collider collider in colliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
                }
            }
    }
}
