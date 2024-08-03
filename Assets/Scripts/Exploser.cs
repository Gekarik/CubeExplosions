using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float explosionForce = 700f;
    [SerializeField] private float explosionRadius = 5f;

    public void ApplyExplosionForce(Cube[] createdCubes)
    {
        foreach (Cube cube in createdCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(explosionForce, cube.transform.position, explosionRadius);
        }
    }
}
