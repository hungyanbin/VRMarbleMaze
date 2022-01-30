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

    private Quaternion deviceRotation;
    private GameObject floorObject;
    private float ground = -20f;
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
        floorObject.transform.position = new Vector3(maze.GetWidth() / 2, ground, maze.GetHeight() / 2);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out deviceRotation);
        floorObject.GetComponent<Rigidbody>().MoveRotation(deviceRotation);
    }
}
