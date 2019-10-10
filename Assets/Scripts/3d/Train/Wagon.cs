using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour {

    public int number;
    private bool changeShkaeDirection;
    private float amplitude;
    public bool resetShake;

	// Use this for initialization
	void Start ()
    {
        amplitude = 0.01f * Random.Range(1, 3);
        //amplitude = 0.03f;
        if (number % 2 == 0)
            changeShkaeDirection = true;
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - amplitude, transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.parent.GetComponent<TrainManager>().moving)
            Shake();

        if (transform.parent.GetComponent<TrainManager>().resetShake)
            ResetShake();
	}

    void Shake()
    {
        if (transform.position.y < amplitude && !changeShkaeDirection)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f * Time.deltaTime, transform.position.z);
        else changeShkaeDirection = true;

        if (transform.position.y > -amplitude && changeShkaeDirection)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f * Time.deltaTime, transform.position.z);
        else changeShkaeDirection = false;

    }

    public void ResetShake()
    {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f * Time.deltaTime, transform.position.z);
        else transform.parent.GetComponent<TrainManager>().resetShake = false;

        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f * Time.deltaTime, transform.position.z);
        else transform.parent.GetComponent<TrainManager>().resetShake = false;
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<PlayerMove>() != null)
        {
            coll.gameObject.transform.SetParent(transform, true);
            transform.parent.GetComponent<TrainManager>().debugPlayerInTrain = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        transform.parent.GetComponent<TrainManager>().debugPlayerInTrain = false;
    }
}
