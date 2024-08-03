using UnityEngine;

[RequireComponent(typeof(Exploser), typeof(Splitter))]
public class Clicker : MonoBehaviour
{
    private const float MinTotalChance = 0.0f;
    private const float MaxTotalChance = 1.0f;
    [SerializeField] private int _cubeAmountBotBound = 2;
    [SerializeField] private int _cubeAmountTopBound = 6;

    private Ray _ray;
    private Splitter _splitter;
    private Exploser _exploser;
    private Colorizer _colorizer;
    private InputReader _inputReader = new();

    private void Start()
    {
        _exploser = GetComponent<Exploser>();
        _splitter = GetComponent<Splitter>();
        _colorizer = GetComponent<Colorizer>();
    }

    private void Update()
    {
        if (_inputReader.LeftClick() && TryGetCube(out Cube cube))
        {
            if (cube.CurrentChance >= GetRandomValue())
                ExploseCube(cube);

            Destroy(cube.gameObject);
        }
    }

    private bool TryGetCube(out Cube cube)
    {
        cube = null;
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit))
            return hit.collider.TryGetComponent(out cube);

        return false;
    }

    private float GetRandomValue() => Random.Range(MinTotalChance, MaxTotalChance);

    private int GetCubeAmountRandomly() => Random.Range(_cubeAmountBotBound, _cubeAmountTopBound);

    private void ExploseCube(Cube cube)
    {
        int partAmount = GetCubeAmountRandomly();
        Cube[] _createdCubes = _splitter.Split(cube, partAmount);
        _exploser.ApplyExplosionForce(_createdCubes);
        _colorizer.Colorize(_createdCubes);
    }
}
