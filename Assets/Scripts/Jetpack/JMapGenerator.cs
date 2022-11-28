using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography;
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

    public List<string[]> otazky;


    // Start is called before the first frame update
    void Start()
    {
        obstacle1 = GameObject.Instantiate(obstaclePrefab);
        obstacle1 = generateObstacle(player.transform.position.x + 20);

        obstacle2 = generateObstacle(obstacle1.transform.position.x);
        obstacle3 = generateObstacle(obstacle2.transform.position.x);
        obstacle4 = generateObstacle(obstacle3.transform.position.x);
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

        if (player.transform.position.x > obstacle2.transform.position.x)
        {
            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;

            setTransform(tempObstacle, obstacle3.transform.position.x);
            obstacle4 = tempObstacle;
        }
    }

    GameObject generateObstacle(float referenceX)
    {
        
        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
        setTransform(obstacle, referenceX);
        return obstacle;

        
    }

    void setTransform(GameObject obstacle, float referenceX)
    {
        obstacle.transform.position = new Vector2(referenceX + Random.Range(minObstacleSpace, maxObstacleSpace), Random.Range(minObstacleY, maxObstacleY));
        obstacle.transform.localScale = new Vector2(obstacle.transform.localScale.x, Random.Range(minObstacleLength, maxObstacleLength));
        int randomR = (Random.Range(0, 4));
        float rotate = 0;
        switch (randomR)
        {
            case 0:
                rotate = 0;
                break;
            case 1:
                rotate = 45;
                break;
            case 2:
                rotate = 90;
                break;
            case 3:
                rotate = 135;
                break;
        }
        obstacle.transform.Rotate(obstacle.transform.localRotation.x, obstacle.transform.localRotation.y, rotate);
    }

    public void GetQuestions(List<string[]> quest)
    {
        otazky = quest;
    }
}
