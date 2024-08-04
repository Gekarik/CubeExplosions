using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private const float DivideValue = 2.0f;
    [SerializeField] private float _startChance = 1.0f;
    public int CubeRank { get; private set; } = 1;
    public float CurrentChance { get; private set; }

    private void Awake()
    {
        CurrentChance = _startChance;
    }

    public void InitSmallerCube(float currentChance)
    {
        currentChance /= DivideValue;
        CurrentChance = currentChance;
        CubeRank++;
    }
}
