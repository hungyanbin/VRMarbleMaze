using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private XRNode inputSource;

    [SerializeField]
    private GameObject marblePrefab;

    private Quaternion deviceRotation;
    private GameObject floorObject;
    private GameObject marbleObject;
    private float ground = -20f;
    private Maze maze;

    void Start()
    {
        //Maze maze = MazeGenerator.RandomMaze(10, 10);
        maze = MazeGenerator.StarterMaze();
        DrawMazeFloor(maze);
        DrawMaze(maze);
        AddMarble(maze);
    }

    private void AddMarble(Maze maze)
    {
        marbleObject = Instantiate(marblePrefab, transform);
        float transformX = floorObject.transform.position.x - maze.GetWidth() / 2f + maze.GetStartPosition().X;
        float transformY = floorObject.transform.position.z - maze.GetHeight() / 2f + maze.GetStartPosition().Y;
        marbleObject.transform.position = new Vector3(transformX, ground + 1f, transformY);
    }

    private void DrawMaze(Maze maze)
    {
        List<Wall> walls = maze.GetWalls();
        float yOffset = 0.5f + ground;
        walls.ForEach(wall =>
        {
            if (wall.IsVertical())
            {
                var wallObject = Instantiate(wallPrefab, transform); 
                int wallLenght = wall.EndY - wall.StartY;
                wallObject.transform.parent = floorObject.transform;
                wallObject.transform.position = new Vector3(wall.StartX, yOffset, (wall.StartY + wall.EndY) / 2f);
                wallObject.transform.localScale = new Vector3(wallObject.transform.localScale.x, wallObject.transform.localScale.y, wallLenght);
                MeshRenderer meshRenderer = wallObject.GetComponent<MeshRenderer>();
                meshRenderer.material.mainTextureScale = new Vector2(wallLenght, 1);
            }
            else if (wall.IsHorizontal())
            {
                var wallObject = Instantiate(wallPrefab, transform);
                int wallLenght = wall.EndX - wall.StartX;
                wallObject.transform.parent = floorObject.transform;
                wallObject.transform.position = new Vector3((wall.StartX + wall.EndX) / 2f, yOffset, wall.StartY);
                wallObject.transform.eulerAngles = new Vector3(0, 90, 0);
                wallObject.transform.localScale = new Vector3(wallObject.transform.localScale.x, wallObject.transform.localScale.y, wallLenght);
                MeshRenderer meshRenderer = wallObject.GetComponent<MeshRenderer>();
                meshRenderer.material.mainTextureScale = new Vector2(wallLenght, 1);
            }
        });
    }

    private void DrawMazeFloor(Maze maze)
    {
        floorObject = Instantiate(floorPrefab, transform) as GameObject;
        floorObject.transform.position = new Vector3(maze.GetWidth() / 2f, ground, maze.GetHeight() / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out deviceRotation);
        floorObject.GetComponent<Rigidbody>().MoveRotation(deviceRotation);

        CheckMarbleHeight();
    }

    private void CheckMarbleHeight()
    {
        if (marbleObject.transform.position.y < -1000)
        {
            AddMarble(maze);
        }
    }
}
