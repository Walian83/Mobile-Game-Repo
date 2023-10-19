using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform tile;

    public Vector3 startPoint = new Vector3(0, 0, -5);

    public int initSpawnNum = 10;

    private Vector3 nextTileLocation;

    private Quaternion nextTileRotation;

    // Start is called before the first frame update
    void Start()
    {
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile();
        }
    }

    public void SpawnNextTile()
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        var nextTile = newTile.Find("New Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
