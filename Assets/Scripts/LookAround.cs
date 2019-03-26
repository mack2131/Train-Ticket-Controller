using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {

    public GameObject player;
    private RaycastHit hit;

    public GameObject checkTicketPanel;
    public GameObject mainUIPanel;

    public int money;

    // Use this for initialization
    void Start ()
    {
        money = 0;	
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            Use();
    }

	// Update is called once per frame
	void LateUpdate ()
    {
        Look();
	}

    void Look()
    {
        float mY = Input.GetAxis("Mouse Y");
        //float rotY = Mathf.Clamp(-mY * 45 * Time.deltaTime, -40, 40);
        transform.RotateAround(player.transform.position, transform.right, -mY * 5);
    }

    void Use()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.4f))
        {
            if (hit.collider.GetComponent<CabinDoors>() != null)
            {
                hit.collider.GetComponent<CabinDoors>().canOpen = true;
            }
            else if (hit.collider.GetComponent<MobPassagers>() != null)
            {
                //Time.timeScale = 0;
                checkTicketPanel.GetComponent<CheckTicketPanel>().tType = hit.collider.GetComponent<MobPassagers>().t.tType;
                checkTicketPanel.GetComponent<CheckTicketPanel>().tFrom = hit.collider.GetComponent<MobPassagers>().t.tFrom;
                checkTicketPanel.GetComponent<CheckTicketPanel>().tTo = hit.collider.GetComponent<MobPassagers>().t.tTo;
                checkTicketPanel.GetComponent<CheckTicketPanel>().passanger = hit.collider.gameObject;
                checkTicketPanel.SetActive(true);
                mainUIPanel.SetActive(false);
                Camera.main.GetComponent<LookAround>().enabled = false;
                transform.parent.GetComponent<PlayerMove>().enabled = false;
            }
        }
    }
}
