using UnityEngine;

[RequireComponent(typeof(Exploser), typeof(Splitter),typeof(Colorizer))]
public class Clicker : MonoBehaviour
{
    private const float MinTotalChance = 0.0f;
    private const float MaxTotalChance = 1.0f;

    [SerializeField] private int _cubeAmountBotBound = 2;
    [SerializeField] private int _cubeAmountTopBound = 6;

    private Splitter _splitter;
    private Exploser _exploser;
    private Colorizer _colorizer;
    private InputReader _inputReader = new();
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _exploser = GetComponent<Exploser>();
        _splitter = GetComponent<Splitter>();
        _colorizer = GetComponent<Colorizer>();
    }

    private void Update()
    {
        if (_inputReader.IsLeftMouseButtonClick() && TryGetCube(out Cube cube))
        {
            if (cube.CurrentChance >= GetRandomValue())
                ExploseCube(cube);
            else
                _exploser.ApplyExplosionForce(cube);

            Destroy(cube.gameObject);
        }
    }

    private bool TryGetCube(out Cube cube)
    {
        cube = null;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            return hit.collider.TryGetComponent(out cube);

        return false;
    }

    private float GetRandomValue() => Random.Range(MinTotalChance, MaxTotalChance);

    private int GetCubeAmountRandomly() => Random.Range(_cubeAmountBotBound, _cubeAmountTopBound);

    private void ExploseCube(Cube cube)
    {
        int partAmount = GetCubeAmountRandomly();
        Cube[] createdCubes = _splitter.Split(cube, partAmount);
        _exploser.ApplyExplosionForce(createdCubes);
        _colorizer.Colorize(createdCubes);
    }
}
