using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayManager : MonoBehaviour {

    public GameObject terrainChunk;
    public GameObject previousChunk;
    public GameObject currentChunk;
    public GameObject nextChunk;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.GetComponent<TerrainChunk>() != null)
        {
            Debug.Log("chunk");
            if(nextChunk == null)
            {
                //nextChunk = Instantiate();
            }
        }
    }
}
