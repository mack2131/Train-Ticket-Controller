using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinDoors : MonoBehaviour {

    [Tooltip("0 - left, 1 - right")]
    public int rightOrLeft;
    public bool canOpen;//дверь можно открыть
    private bool canClose;//дверь можно закрыть
    private bool opened;//дверь не находится в процессе открытия, закрытия
    private int secondsAfterOpened;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canOpen)
            Open();
        else if (canClose)
            Close();

        
    }

    void Open()
    {
        if (rightOrLeft == 0)//left
        {
            if (transform.rotation.y < 0.80)
                transform.Rotate(transform.up, 120 * Time.deltaTime);
            else
            {
                canOpen = false;
                StartCoroutine(Count());
            }
        }
        else if(rightOrLeft == 1)//right
        {
            if (transform.rotation.y > -0.80)
                transform.Rotate(transform.up, -120 * Time.deltaTime);
            else
            {
                canOpen = false;
                StartCoroutine(Count());
            }
        }
        else if (rightOrLeft == 2)//inside
        {
            if (transform.rotation.y > -0.70)
                transform.Rotate(transform.up, -120 * Time.deltaTime);
            else
            {
              canOpen = false;
              StartCoroutine(Count());
            }
        }
        else if (rightOrLeft == 3)//inside 2
        {
            if (transform.rotation.y < -0.70)
                transform.Rotate(transform.up, -120 * Time.deltaTime);
            else
            {
                canOpen = false;
                StartCoroutine(Count());
            }
        }
    }

    void Close()
    {
        if (rightOrLeft == 0)//left
        {
            if (transform.rotation.y > 0)
                transform.Rotate(transform.up, -120 * Time.deltaTime);
            else
            {
                canClose = false;
            }
        }
        else if (rightOrLeft == 1)//right
        {
            if (transform.rotation.y < 0)
                transform.Rotate(transform.up, 120 * Time.deltaTime);
            else
            {
                canClose = false;
            }
        }
        else if (rightOrLeft == 2)//inside
        {
            if (transform.rotation.y < 0)
                transform.Rotate(transform.up, 120 * Time.deltaTime);
            else
            {
                canClose = false;
            }
        }
        else if (rightOrLeft == 3)//inside 2
        {
            if (transform.rotation.y > -0.9999999)
                transform.Rotate(transform.up, 120 * Time.deltaTime);
            else
            {
                canClose = false;
            }
        }
    }

    IEnumerator Count()
    {
        while (true)
        {
            secondsAfterOpened++;
            if(secondsAfterOpened == 5)
            {
                canClose = true;
                secondsAfterOpened = 0;
                StopCoroutine(Count());
            }
            yield return new WaitForSeconds(1);
        }
    }
}
