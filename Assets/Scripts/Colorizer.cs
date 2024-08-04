using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] List<Color> _colors;

    public void Colorize(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.TryGetComponent(out Renderer renderer))
            {
                if (_colors == null || _colors.Count == 0)
                    renderer.material.color = Random.ColorHSV();
                else
                    renderer.material.color = GetRandomColor();
            }
        }
    }

    private Color GetRandomColor()
    {
        int index = Random.Range(0, _colors.Count);
        return _colors[index];
    }
}
