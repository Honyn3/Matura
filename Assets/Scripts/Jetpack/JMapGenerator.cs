using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMapGenerator : MonoBehaviour
{
    public GameObject ceiling;
    public GameObject prevCeiling;
    public GameObject floor;
    public GameObject prevFloor;

    public GameObject player;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public GameObject obstaclePrefab;

    public float minObstacleY;
    public float maxObstacleY;
    public float minObstacleLength;
    public float maxObstacleLength;
    public float minObstacleSpace;
    public float maxObstacleSpace;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > floor.transform.position.x)
        {
            var tempFloor = prevFloor;
            var tempCeiling = prevCeiling;
            prevCeiling = ceiling;
            prevFloor = floor;
            tempCeiling.transform.position += new Vector3(80, 0,0);
            tempFloor.transform.position += new Vector3(80, 0,0);
            ceiling = tempCeiling;
            floor = tempFloor;
        }
    }
}
