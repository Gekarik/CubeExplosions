using UnityEngine;

public class Splitter : MonoBehaviour
{
    public Cube[] Split(Cube cube, int _partAmount)
    {
        Cube[] _createdCubes = new Cube[_partAmount];

        for (int i = 0; i < _partAmount; i++)
        {
            var partOfCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            partOfCube.transform.localScale /= 2;
            partOfCube.LowerChance(cube.CurrentChance);
            _createdCubes[i] = partOfCube;
        }

        return _createdCubes;
    }
}
