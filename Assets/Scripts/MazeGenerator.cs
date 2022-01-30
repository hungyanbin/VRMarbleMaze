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

    public static Maze StarterMaze()
    {
        List<Wall> walls = new List<Wall>();

        walls.Add(new Wall(0, 0, 0, 10));

        walls.Add(new Wall(1, 3, 1, 4));
        walls.Add(new Wall(1, 5, 1, 7));
        walls.Add(new Wall(1, 9, 1, 10));

        walls.Add(new Wall(2, 1, 2, 3));
        walls.Add(new Wall(2, 4, 2, 6));
        walls.Add(new Wall(2, 7, 2, 9));

        walls.Add(new Wall(3, 4, 3, 6));

        walls.Add(new Wall(4, 0, 4, 1));
        walls.Add(new Wall(4, 3, 4, 8));

        walls.Add(new Wall(5, 2, 5, 3));
        walls.Add(new Wall(5, 7, 5, 10));

        walls.Add(new Wall(6, 3, 6, 4));
        walls.Add(new Wall(6, 6, 6, 7));

        walls.Add(new Wall(7, 2, 7, 4));
        walls.Add(new Wall(7, 7, 7, 8));

        walls.Add(new Wall(8, 1, 8, 2));
        walls.Add(new Wall(8, 3, 8, 5));
        walls.Add(new Wall(8, 6, 8, 7));

        walls.Add(new Wall(9, 2, 9, 3));
        walls.Add(new Wall(9, 4, 9, 6));

        walls.Add(new Wall(10, 0, 10, 10));

        walls.Add(new Wall(0, 0, 10, 0));

        walls.Add(new Wall(1, 1, 2, 1));
        walls.Add(new Wall(3, 1, 4, 1));
        walls.Add(new Wall(5, 1, 9, 1));

        walls.Add(new Wall(0, 2, 1, 2));
        walls.Add(new Wall(2, 2, 7, 2));
        walls.Add(new Wall(8, 2, 9, 2));

        walls.Add(new Wall(1, 3, 3, 3));
        walls.Add(new Wall(5, 3, 6, 3));
        walls.Add(new Wall(7, 3, 8, 3));
        walls.Add(new Wall(9, 3, 10, 3));

        walls.Add(new Wall(1, 4, 2, 4));
        walls.Add(new Wall(4, 4, 5, 4));
        walls.Add(new Wall(8, 4, 9, 4));

        walls.Add(new Wall(5, 5, 8, 5));

        walls.Add(new Wall(2, 6, 3, 6));
        walls.Add(new Wall(4, 6, 5, 6));
        walls.Add(new Wall(6, 6, 9, 6));

        walls.Add(new Wall(0, 7, 4, 7));
        walls.Add(new Wall(5, 7, 6, 7));
        walls.Add(new Wall(8, 7, 9, 7));

        walls.Add(new Wall(1, 8, 2, 8));
        walls.Add(new Wall(3, 8, 4, 8));
        walls.Add(new Wall(6, 8, 10, 8));

        walls.Add(new Wall(2, 9, 3, 9));
        walls.Add(new Wall(4, 9, 9, 9));

        walls.Add(new Wall(0, 10, 5, 10));
        walls.Add(new Wall(6, 10, 10, 10));

        return new Maze(walls, 10, 10);
    }

}


