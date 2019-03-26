using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

    public bool debugMove;
    public bool debugPlayerInTrain;
    public bool moving;
    [Tooltip("0 - left, 1 - right")]
    public int side;
    public bool doorsOpen;

    [System.Serializable]
    public struct Wagon
    {
        public Transform wagonTransform;
        public GameObject DoorExit;
        public GameObject seatsStorage;
    }
    public Wagon[] wagons;

    public AudioSource[] audio;

    public GameObject mobPrefab;

    public GameObject platform;
    public int direction;
    public Transform stopPoint;
    public float speed;
    public bool resetShake;

    public GameObject terrainChunk;
    public GameObject previousChunk;
    public GameObject currentChunk;
    public GameObject nextChunk;

    private int seconds;
    private bool stationStop;
    private bool goingToHell;

    private bool startMove;
    private bool keepMoving;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponents<AudioSource>();
        DebugGeneratePassangers();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (debugMove)
            Move();
        /*if (Input.GetKeyUp(KeyCode.M))
        {
            debugMove = true;
            startMove = true;
        }

        if (debugMove && debugPlayerInTrain)
            Move();

        if (Input.GetKeyUp(KeyCode.O))
        {
            side = 0;
            OpenCloseExitDoors();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            side = 1;
            OpenCloseExitDoors();
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            debugMove = true;
            startMove = true;
            debugPlayerInTrain = true;
        }*/
    }

    void Move()
    {
        if (startMove)
        {
            audio[2].Play();
            startMove = false;
        }
        else if (audio[2].time > 4)
        {
            audio[2].volume -= Time.deltaTime;
            if (!keepMoving)
                keepMoving = true;
            if (audio[2].volume <= 0)
                audio[2].Stop();
        }

        if (keepMoving && audio[3].time == 0)
            audio[3].Play();

        if (direction == 0)
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        else if (direction == 1)
            transform.Translate(transform.forward * speed * Time.deltaTime);

        moving = true;

        if (DistanceBeforeStop() < 100 && speed == 5 && !stationStop)
            speed /= 2;

        if (DistanceBeforeStop() < 50 && !stationStop)
        {
            debugMove = false;
            startMove = false;
            StartCoroutine("Waiting");
            stationStop = true;
            resetShake = true;
        }

        if (DistanceBeforeStop() > 170 && goingToHell)
            Destroy(this.gameObject);
    }

    void OpenCloseExitDoors()
    {
        audio[0].Play();
        for(int i = 0; i < wagons.Length; i++)
        {
            if(side == 0)//left
            {
                for(int j = 0; j < wagons[i].DoorExit.transform.GetChild(0).transform.childCount; j++)
                    wagons[i].DoorExit.transform.GetChild(0).transform.GetChild(j).GetComponent<ExitDoors>().open = true;
            }
            if (side == 1)//right
            {
                for (int j = 0; j < wagons[i].DoorExit.transform.GetChild(0).transform.childCount; j++)
                    wagons[i].DoorExit.transform.GetChild(1).transform.GetChild(j).GetComponent<ExitDoors>().open = true;
            }
        }
    }

    void DebugGeneratePassangers()
    {
        /*int emptyPlaces = 0;*/
        for (int w = 0; w < wagons.Length; w++)
        {
            int emptyPlaces = 0;
            for (int i = 0; i < wagons[w].seatsStorage.transform.childCount; i++)
            {
                if (wagons[w].seatsStorage.transform.GetChild(i).GetComponent<Seats>().empty)
                    emptyPlaces++;
            }
            Debug.Log(emptyPlaces);
            for (int i = 0; i < emptyPlaces; i++)
            {
                int j = Random.Range(0, 101);
                //Debug.Log(j);
                if (j < 25)
                {
                    GameObject mob = Instantiate(mobPrefab, wagons[w].wagonTransform, true);
                    mob.transform.position = new Vector3(wagons[w].seatsStorage.transform.GetChild(i).transform.position.x,
                                                         wagons[w].seatsStorage.transform.GetChild(i).transform.position.y - 0.35f,
                                                         wagons[w].seatsStorage.transform.GetChild(i).transform.position.z);
                    mob.transform.rotation = wagons[w].seatsStorage.transform.GetChild(i).transform.rotation;
                }
            }
        }
    }

    float DistanceBeforeStop()
    {
        return Vector3.Distance(transform.position, stopPoint.position);
    }

    IEnumerator Waiting()
    {
        while(true)
        {
            seconds++;
            if (seconds == 3)
                OpenCloseExitDoors();
            if(seconds == 30)
                OpenCloseExitDoors();
            if(seconds == 32)
                audio[1].Play();
            if (seconds == 33)
            {
                debugMove = true;
                startMove = true;
                speed = 5;
                if(side == 0)
                    platform.GetComponent<Platform>().rightTrain = false;
                else if(side == 1)
                    platform.GetComponent<Platform>().leftTrain = false;
                if (!debugPlayerInTrain)
                    goingToHell = true;
                StopCoroutine("Waiting");
            }
            yield return new WaitForSeconds(1);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.GetComponent<TerrainChunk>() != null)
        {
            Debug.Log("Hi");
            /*currentChunk = coll.gameObject;
            if (previousChunk != null)
                Destroy(previousChunk.gameObject);
            else 
            {
                nextChunk = Instantiate(terrainChunk);
                if(side == 0)
                    nextChunk.transform.position = new Vector3(currentChunk.transform.position.x, 
                                                               currentChunk.transform.position.y, 
                                                               currentChunk.transform.position.z + 500);
                else if(side == 1)
                    nextChunk.transform.position = new Vector3(currentChunk.transform.position.x,
                                                               currentChunk.transform.position.y,
                                                               currentChunk.transform.position.z - 500);
            }*/

        }
    }
}
