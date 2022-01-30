using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    private readonly List<Wall> walls;
    private readonly int width;
    private readonly int height;
    private readonly Position startPosition;

    public Maze(List<Wall> walls, int width, int height, Position start)
    {
        this.walls = walls;
        this.width = width;
        this.height = height;
        this.startPosition = start;
    }

    public List<Wall> GetWalls()
    {
        return walls;
    }

    public int GetWidth() { return width; }
    public int GetHeight() { return height; }
    public Position GetStartPosition() { return startPosition; }
}

public readonly struct Position
{
    public Position(float x, float y)
    {
        X = x;
        Y = y;
    }

    public float X { get; }
    public float Y { get; }
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

