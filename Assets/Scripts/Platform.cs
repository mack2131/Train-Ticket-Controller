using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public bool isEndOfRoute;
    public bool playerOnPlatform;
    public GameObject train;
    public Transform spawnPoint0;
    public Transform spawnPoint1;
    public Transform stopPoint0;
    public Transform stopPoint1;
    public bool leftTrain;
    public bool rightTrain;
    private bool timetableStart;
    private int secondsL;
    private int secondsR;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("Timetable");
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnTriggerStay(Collider coll)
    {
        if (coll.GetComponent<PlayerMove>() != null)
        {
            coll.gameObject.transform.SetParent(transform, true);
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        playerOnPlatform = false;
    }

    void SpawnTrain(int direction)
    {
        GameObject newTrain = Instantiate(train);
        newTrain.GetComponent<TrainManager>().direction = direction;
        /*newTrain.GetComponent<TrainManager>().debugPlayerInTrain = true;*/
        newTrain.GetComponent<TrainManager>().debugMove = true;
        newTrain.GetComponent<TrainManager>().platform = this.gameObject;
        if (direction == 0)
        {
            newTrain.name = "Train 0";
            newTrain.transform.position = spawnPoint0.position;
            newTrain.GetComponent<TrainManager>().stopPoint = stopPoint0;
            newTrain.GetComponent<TrainManager>().side = 0;
            rightTrain = true;
        }
        else if (direction == 1)
        {
            newTrain.name = "Train 1";
            newTrain.transform.position = spawnPoint1.position;
            newTrain.GetComponent<TrainManager>().stopPoint = stopPoint1;
            newTrain.GetComponent<TrainManager>().side = 1;
            leftTrain = true;
        }
    }

    public void StartTimetable()
    {

    }

    IEnumerator Timetable()
    {
        while (true)
        {
            if (playerOnPlatform)
            {
                if (!leftTrain)
                {
                    secondsL++;
                    if (secondsL == 10)
                    {
                        SpawnTrain(1);
                        secondsL = 0;
                        //StopCoroutine("Timetable");
                    }
                }

                if (!rightTrain)
                {
                    secondsR++;
                    if (secondsR == 60)
                    {
                        SpawnTrain(0);
                        secondsR = 0;
                        //StopCoroutine("Timetable");
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
