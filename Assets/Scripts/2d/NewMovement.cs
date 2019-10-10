using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float speed;

    private CharacterController cc;

    private bool u, d, l, r;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(u);
        if (Input.GetKeyDown(KeyCode.W))
            u = true;
        else if (Input.GetKeyDown(KeyCode.S))
            d = true;

        if (Input.GetKeyUp(KeyCode.W))
            u = false;
        if (Input.GetKeyUp(KeyCode.S))
            d = false;

        if (Input.GetKeyDown(KeyCode.A))
            l = true;
        else if (Input.GetKeyDown(KeyCode.D))
            r = true;

        if (Input.GetKeyUp(KeyCode.A))
            l = false;
        if (Input.GetKeyUp(KeyCode.D))
            r = false;

        if (u)//z-axis
            cc.Move(transform.forward * Time.deltaTime * speed);
        else if(d)
            cc.Move(-transform.forward * Time.deltaTime * speed);
        if(r)//x-axis
            cc.Move(transform.right * Time.deltaTime * speed);
        else if (l)//x-axis
            cc.Move(-transform.right * Time.deltaTime * speed);
    }
}
