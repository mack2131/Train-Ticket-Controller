using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrain : MonoBehaviour
{
    public bool headWagon;
    public GameObject roof;
    public GameObject headRoof;

    public int spwnChance;
    public GameObject mobPref;
    public Transform mobStorage;
    public Transform seatStorage;

    // Start is called before the first frame update
    void Start()
    {
        NewTrainSeats[] nts;
        if(headWagon)
        {
            BoxCollider[] c = GetComponents<BoxCollider>();
            for(int i = 0; i < c.Length; i++)
            {
                if(c[i].isTrigger)
                {
                    /* trigger collider size */
                    /*x: 3.9   y: 3    z: 23.7  - no cabin*/
                    /*0 0 1.73 - center*/
                    /*x: 3.9   y: 3    z: 27 - with cabin*/
                    /*0 0 -1.7 - center*/
                    c[i].center = new Vector3(0, 0, -1.7f);
                    c[i].size = new Vector3(3.9f, 3, 27);
                }
            }
        }
        nts = GetComponentsInChildren<NewTrainSeats>();
        for(int i = 0; i < nts.Length; i++)
        {
            if(Random.Range(0, 100) <= spwnChance)
            {
                GameObject m = Instantiate(mobPref);
                m.transform.position = new Vector3(nts[i].gameObject.transform.position.x, nts[i].gameObject.transform.position.y - 0.6f, nts[i].gameObject.transform.position.z);
                if (!nts[i].haveToRotate)
                    m.transform.rotation *= Quaternion.Euler(0, 180f, 0);/*m.transform.Rotate(m.transform.up, 180);*/
                m.transform.SetParent(mobStorage);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<NewMovement>() != null)
        {
            roof.SetActive(false);
            mobStorage.gameObject.SetActive(true);
            seatStorage.gameObject.SetActive(true);
            if (headWagon)
                headRoof.SetActive(false);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<NewMovement>() != null)
        {
            roof.SetActive(true);
            mobStorage.gameObject.SetActive(false);
            seatStorage.gameObject.SetActive(false);
            if (headWagon)
                headRoof.SetActive(true);
        }
    }
}
