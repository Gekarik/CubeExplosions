using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 700f;
    [SerializeField] private float _explosionRadius = 2.5f;
    [SerializeField] private LayerMask _cubeLayer;

    public void ApplyExplosionForce(Cube[] createdCubes)
    {
        foreach (Cube cube in createdCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }

    public void ApplyExplosionForce(Cube cube)
    {
        Vector3 explosionCenter = cube.transform.position;
        float radiusSquared = _explosionRadius * _explosionRadius;
        float explosionForceMultiplier = _explosionForce;
        int multiplier = cube.CubeRank;

        Collider[] colliders = Physics.OverlapSphere(explosionCenter, _explosionRadius, _cubeLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Cube otherCube) &&
                otherCube.TryGetComponent(out Rigidbody rigidbody))
            {
                Vector3 direction = otherCube.transform.position - explosionCenter;
                float distanceSquared = direction.sqrMagnitude;

                if (distanceSquared <= radiusSquared)
                {
                    float distance = Mathf.Sqrt(distanceSquared);
                    float force = explosionForceMultiplier * (1 - (distance / _explosionRadius));

                    rigidbody.AddExplosionForce(multiplier * force, explosionCenter, multiplier * _explosionRadius);
                }
            }
        }
    }

}
