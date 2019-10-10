using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public Transform target;
    public float zDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, zDistance, target.position.z);        
    }

}
