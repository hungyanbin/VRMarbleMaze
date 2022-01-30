using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    private readonly List<Wall> walls;
    private readonly int width;
    private readonly int height;

    public Maze(List<Wall> walls, int width, int height)
    {
        this.walls = walls;
        this.width = width;
        this.height = height;
    }

    public List<Wall> GetWalls()
    {
        return walls;
    }

    public int GetWidth() { return width; }
    public int GetHeight() { return height; }
}

public readonly struct Wall
{
    public Wall(int startX, int startY, int endX, int endY)
    {
        StartX = startX;
        StartY = startY;
        EndX = endX;
        EndY = endY;
    }

    public int StartX { get; }
    public int StartY { get; }
    public int EndX { get; }
    public int EndY { get; }

    public bool IsVertical()
    {
        return StartX == EndX;
    }

    public bool IsHorizontal()
    {
        return StartY == EndY;
    }
}

