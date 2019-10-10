using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {

    public string title;
    public string type;
    public string from;
    public string to;
    public string price;
    public string paid;
    public Image print;

    public Text titleField;
    public Text typeField;
    public Text fromField;
    public Text toField;
    public Text priceField;
    public Text paidField;
    public Vector3 position;

    public void FillInfo()
    {
        //titleField.text = title;
        typeField.text = type;
        fromField.text = from;
        toField.text = to;
        //priceField.text = price;
        //paidField.text = paid;
        
    }
}
