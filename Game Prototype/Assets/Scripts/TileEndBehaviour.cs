using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEndBehaviour : MonoBehaviour
{
    public float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            Destroy(transform.parent.gameObject, destroyTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
