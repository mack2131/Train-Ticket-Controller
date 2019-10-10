using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoors : MonoBehaviour {

    public GameObject leftDoor;
    public GameObject rightDoor;
    public bool open;
    [Tooltip("0 - left, 1 - right")]
    public int side;

    private bool opened;//открыты ли двери

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {        
        if (open && opened)
            Close();
        else if (open)
            Open();
    }

    void Open()
    {

        if (side == 0)
        {
            if (leftDoor.transform.localPosition.z < 0.93 || rightDoor.transform.localPosition.z > -0.4)
            {
                leftDoor.transform.Translate(-leftDoor.transform.forward * Time.deltaTime, Space.Self);
                rightDoor.transform.Translate(rightDoor.transform.forward * Time.deltaTime, Space.Self);
            }
            else
            {
                open = false;
                opened = true;
            }
        }
        else if (side == 1)
        {
            if (leftDoor.transform.localPosition.z < 0.93 || rightDoor.transform.localPosition.z > -0.4)
            {
                leftDoor.transform.Translate(leftDoor.transform.forward * Time.deltaTime, Space.Self);
                rightDoor.transform.Translate(-rightDoor.transform.forward * Time.deltaTime, Space.Self);
            }
            else
            {
                open = false;
                opened = true;
            }
        }
    }

    void Close()
    {
        if (side == 0)
        {
            if (leftDoor.transform.localPosition.z > 0.484 || rightDoor.transform.localPosition.z < 0)
            {
                leftDoor.transform.Translate(leftDoor.transform.forward * Time.deltaTime, Space.Self);
                rightDoor.transform.Translate(-rightDoor.transform.forward * Time.deltaTime, Space.Self);
            }
            else
            {
                opened = false;
                open = false;
            }
        }
        else if (side == 1)
        {
            if (leftDoor.transform.localPosition.z > 0.484 || rightDoor.transform.localPosition.z < 0)
            {
                leftDoor.transform.Translate(-leftDoor.transform.forward * Time.deltaTime, Space.Self);
                rightDoor.transform.Translate(rightDoor.transform.forward * Time.deltaTime, Space.Self);
            }
            else
            {
                opened = false;
                open = false;
            }
        }
    }
}
