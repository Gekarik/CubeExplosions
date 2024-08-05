using UnityEngine;

public class Splitter : MonoBehaviour
{
    public Cube[] Split(Cube cube, int partAmount)
    {
        Cube[] createdCubes = new Cube[partAmount];

        for (int i = 0; i < partAmount; i++)
        {
            var partOfCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            partOfCube.InitSmallerCube(cube.CurrentChance);
            createdCubes[i] = partOfCube;
        }

        return createdCubes;
    }
}
