using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGen : MonoBehaviour
{
    [SerializeField] private MaseSeil _maseSeilPrefab;
    [SerializeField] private int width;
    [SerializeField] private int depth;

    private MaseSeil[,] _mazeGrid;

    void Start()
    {
        StartCoroutine(RegenerateMazeRoutine());
    }

    IEnumerator RegenerateMazeRoutine()
    {
        while (true)
        {
            GenerateMaze();
            yield return new WaitForSeconds(10f);
        }
    }

    void GenerateMaze()
    {
        DestroyOldMaze();
        _mazeGrid = new MaseSeil[width, depth];

        for (int x = 0; x < width; x++) 
        {
            for (int z = 0; z < depth; z++)
            {
                _mazeGrid[x, z] = Instantiate(_maseSeilPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);
    }

    private void GenerateMaze(MaseSeil previousCell, MaseSeil currentCell)
    {
        currentCell.visit();

        ClearWalls(previousCell, currentCell);

        MaseSeil nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MaseSeil GetNextUnvisitedCell(MaseSeil currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MaseSeil> GetUnvisitedCells(MaseSeil currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < width)
        {
            var cellToRight = _mazeGrid[x + 1, z];

            if (!cellToRight.Isvisited)
            {
                yield return cellToRight;
            }
        }
        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if (!cellToLeft.Isvisited)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < depth)
        {
            var cellTofront = _mazeGrid[x, z + 1];

            if (!cellTofront.Isvisited)
            {
                yield return cellTofront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellTobehind = _mazeGrid[x, z - 1];

            if (!cellTobehind.Isvisited)
            {
                yield return cellTobehind;
            }
        }
    }

    private void ClearWalls(MaseSeil previousCell, MaseSeil currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

    void DestroyOldMaze()
    {
        if (_mazeGrid != null)
        {
            for (int x = 0; x < width; x++) 
            {
                for (int z = 0; z < depth; z++)
                {
                    Destroy(_mazeGrid[x, z].gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

