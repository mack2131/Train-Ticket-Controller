using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk : MonoBehaviour {

    public bool trainInside;
    public GameObject spawnPoint0;
    public GameObject spawnPoint1;
    public GameObject stopPoint0;
    public GameObject stopPoint1;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<TrainManager>() != null)
            trainInside = true;
    }

    void OnTriggerExit(Collider coll)
    {
        trainInside = false;
    }
}
