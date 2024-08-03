using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] List<Color> colors;

    public void Colorize(Cube[] cubes)
    {
        foreach (var cube in cubes)
        {
            if (cube.TryGetComponent(out Renderer renderer))
            {
                if (colors == null || colors.Count == 0)
                    renderer.material.color = Random.ColorHSV();
                else
                    renderer.material.color = GetRandomColor();
            }
        }
    }

    private Color GetRandomColor()
    {
        int index = Random.Range(0, colors.Count);
        return colors[index];
    }
}
