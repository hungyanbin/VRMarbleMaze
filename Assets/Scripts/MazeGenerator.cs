using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MazeGenerator
{

    public static Maze RandomMaze(int width, int height)
    {
        List<Wall> walls = new List<Wall>();

        for (int i = 0; i < width + 1; i++)
        {
            walls.Add(new Wall(i, 0, i, height));
        }

        for (int j = 0; j < height + 1; j++)
        {
            walls.Add(new Wall(0, j, width, j));
        }

        return new Maze(walls, width, height);
    }

}


