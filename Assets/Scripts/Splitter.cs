using UnityEngine;

public class Splitter : MonoBehaviour
{
    public Cube[] Split(Cube cube, int partAmount)
    {
        Cube[] createdCubes = new Cube[partAmount];

        for (int i = 0; i < partAmount; i++)
        {
            var partOfCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            partOfCube.transform.localScale /= 2;
            partOfCube.LowerChance(cube.CurrentChance);
            createdCubes[i] = partOfCube;
        }

        return createdCubes;
    }
}
