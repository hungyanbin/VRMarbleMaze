using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private Transform wallPrefab;

    [SerializeField]
    private Transform floorPrefab;
    void Start()
    {
        //Maze maze = MazeGenerator.RandomMaze(10, 10);
        Maze maze = MazeGenerator.StarterMaze();
        DrawMazeFloor(maze);
        DrawMaze(maze);
    }

    private void DrawMaze(Maze maze)
    {
        List<Wall> walls = maze.GetWalls();
        float yOffset = 0.5f;
        walls.ForEach(wall =>
        {
            if (wall.IsVertical())
            {
                var wallObject = Instantiate(wallPrefab, transform);
                int wallLenght = wall.EndY - wall.StartY;
                wallObject.position = new Vector3(wall.StartX, yOffset, (wall.StartY + wall.EndY) / 2f);
                wallObject.localScale = new Vector3(wallObject.localScale.x, wallObject.localScale.y, wallLenght);
                MeshRenderer meshRenderer = wallObject.GetComponent<MeshRenderer>();
                meshRenderer.material.mainTextureScale = new Vector2(wallLenght, 1);
            }
            else if (wall.IsHorizontal())
            {
                var wallObject = Instantiate(wallPrefab, transform);
                int wallLenght = wall.EndX - wall.StartX;
                wallObject.position = new Vector3((wall.StartX + wall.EndX) / 2f, yOffset, wall.StartY);
                wallObject.eulerAngles = new Vector3(0, 90, 0);
                wallObject.localScale = new Vector3(wallObject.localScale.x, wallObject.localScale.y, wallLenght);
                MeshRenderer meshRenderer = wallObject.GetComponent<MeshRenderer>();
                meshRenderer.material.mainTextureScale = new Vector2(wallLenght, 1);
            }
        });
    }

    private void DrawMazeFloor(Maze maze)
    {
        var floorObject = Instantiate(floorPrefab, transform);
        floorObject.position = new Vector3(maze.GetWidth() / 2, 0, maze.GetHeight() / 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
