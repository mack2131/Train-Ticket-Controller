using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rb;
    public GameObject pausePanel;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {        
        if (Input.GetKeyUp(KeyCode.Escape) && pausePanel.activeSelf)
            pausePanel.SetActive(false);
        else if (Input.GetKeyUp(KeyCode.Escape))
            pausePanel.SetActive(true);
    }

    void FixedUpdate()
    {
        float hozizontal = Input.GetAxis("Mouse X") * 360 * Time.deltaTime;
        transform.Rotate(0, hozizontal, 0);
        if (Input.GetKey(KeyCode.W))
            rb.MovePosition(rb.position + rb.transform.forward * 2 * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(rb.position - rb.transform.forward * 2 * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            rb.MovePosition(rb.position - rb.transform.right * 2 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.MovePosition(rb.position + rb.transform.right * 2 * Time.deltaTime);
    }
}
