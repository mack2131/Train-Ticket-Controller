using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TambDoor : MonoBehaviour {

    public AnimationClip anim_open;
    public AnimationClip anim_close;
    private Animation anim;
    private bool open;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
        anim.CrossFade(anim_close.name);
    }

    void OnTriggerStay(Collider coll)
    {
        if(!open)
        {
            open = true;
            anim.CrossFade(anim_open.name);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (open)
        {
            open = false;
            anim.CrossFade(anim_close.name);
        }
    }
}
