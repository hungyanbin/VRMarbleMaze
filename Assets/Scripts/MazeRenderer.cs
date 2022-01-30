using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int length;

    [SerializeField]
    private Transform wallPrefab;
    void Start()
    {
        for(int i = 0; i<length; i++)
        {
            var wall = Instantiate(wallPrefab, transform) as Transform;
            wall.position = new Vector3(i, 0.5f, 0);
            wall.localScale = new Vector3(wall.localScale.x, wall.localScale.y, wall.localScale.z);

            var topWall = Instantiate(wallPrefab, transform) as Transform;
            topWall.position = new Vector3(0.5f + i, 0.5f, 0);
            topWall.eulerAngles = new Vector3(0, 90, 0);
            topWall.localScale = new Vector3(wall.localScale.x, wall.localScale.y, wall.localScale.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
