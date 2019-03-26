using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPassagers : MonoBehaviour {

    private Animation animation;
    public AnimationClip animation_seat;
    public int seatNumber;
    [System.Serializable]
    public struct ticketInfo
    {
        public string tType;
        public string tFrom;
        public string tTo;
        public string tPrice;
        public string tPaid;
        public Vector2 printPos;
        public bool tChecked;
    }
    public ticketInfo t;

    // Use this for initialization
    void Start ()
    {
        animation = GetComponent<Animation>();
        GenerateTicket();
	}
	
	// Update is called once per frame
	void Update ()
    {
        animation.CrossFade(animation_seat.name);
	}

    void GenerateTicket()
    {
        t.tType = "Ticket Type : Full";
        t.tFrom = "From : Moscow";
        t.tTo = "To : Vykhino";
        t.tPrice = "Price : 4.99$";
        t.tPaid = "Price : 4.45$";
    }
}
