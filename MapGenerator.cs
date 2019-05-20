using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prevCeiling;
    public GameObject prevFloor;
    public GameObject ceiling;
    public GameObject floor;
    public GameObject plane;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstaclePrefab;
    public float minObstacleY;
    public float maxObastacleY;
    public float minObstacleSpacing;
    public float maxObstacleSpacing;
    public float minObstacleScaleY;
    public float maxObstacleScaleY;

    // Start is called before the first frame update
    void Start()
    {
        //setting up obstacles
        obstacle1 = GenerateObstacle(plane.transform.position.x + 10);
        obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
        obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
        obstacle4 = GenerateObstacle(obstacle3.transform.position.x);    
    }

    GameObject GenerateObstacle(float referenceX)
    {
        //generates obstacles
        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
        SetTransform(obstacle, referenceX);
        return obstacle;
    }

    void SetTransform(GameObject obstacle, float referenceX)
    {
        //generates physics and random placings of obstacles
        obstacle.transform.position = new Vector3(referenceX + 10f + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObastacleY), 0);
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObastacleY), obstacle.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        //sets boundaries on plane to how high or low it can go
        if (plane.transform.position.x > floor.transform.position.x)
        {
            var tempCeiling = prevCeiling;
            var tempFloor = prevFloor;
            prevCeiling = ceiling;
            prevFloor = floor;
            tempCeiling.transform.position += new Vector3(80, 0, 0);
            tempFloor.transform.position += new Vector3(80, 0, 0);
            ceiling = tempCeiling;
            floor = tempFloor;
        }

        if(plane.transform.position.x > obstacle2.transform.position.x)
        {
            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;

            SetTransform(tempObstacle, obstacle3.transform.position.x);
            obstacle4 = tempObstacle;
        }
    }
}
