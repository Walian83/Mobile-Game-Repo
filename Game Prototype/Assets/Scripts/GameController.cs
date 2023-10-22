using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Reference to the tile we want to spawn
    public Transform tile;

    public Transform obstacle;
    // Position of the first tile
    public Vector3 startPoint = new Vector3(0, 0, -5);
    // How many tiles to create in the beginning
    public int initSpawnNum = 10;

    public int initNoObstacles = 4;
    // Where the next tile should spawn
    private Vector3 nextTileLocation;
    // The next tile's rotation
    private Quaternion nextTileRotation;

    // Start is called before the first frame update
    private void Start()
    {
        // Set starting point
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }
    // Will spawn a tile at a certain location and setup the next position
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);
        //the next item
        var nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        var obstacleSpawnPoints = new List<GameObject>();

        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                obstacleSpawnPoints.Add(child.gameObject);

                if (obstacleSpawnPoints.Count > 0)
                {
                    var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

                    var spawnPos = spawnPoint.transform.position;

                    var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

                    newObstacle.SetParent(spawnPoint.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
