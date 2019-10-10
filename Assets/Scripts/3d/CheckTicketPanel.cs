using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTicketPanel : MonoBehaviour {

    [Header("UI Settings")]
    public Button printButton;
    public Button docButton;
    public Button exitButton;
    public GameObject mainUIPanel;

    [Header("Ticket information")]
    public GameObject ticket;
    public Image print;
    public string tType;
    public string tFrom;
    public string tTo;
    public string tPrice;
    public string tPaid;

    public GameObject printTool;
    public GameObject passanger;

    private bool enablePrint;
    private bool tChecked;
    private Vector3 printPos;

    // Use this for initialization
    void Start ()
    {
        printButton.onClick.AddListener(EnablePrint);
        docButton.onClick.AddListener(Documents);
        exitButton.onClick.AddListener(Exit);
    }

    void OnEnable()
    {
        if (!passanger.GetComponent<MobPassagers>().t.tChecked)
        {
            printButton.gameObject.SetActive(true);
            print.transform.position = Vector3.zero;
            tChecked = false;
        }
        else
        {
            print.transform.position = printPos;
            printButton.gameObject.SetActive(false);
        }

        ticket.GetComponent<Ticket>().type = tType;
        ticket.GetComponent<Ticket>().from = tFrom;
        ticket.GetComponent<Ticket>().to = tTo;
        ticket.GetComponent<Ticket>().price = tPrice;
        ticket.GetComponent<Ticket>().paid = tPaid;
        ticket.GetComponent<Ticket>().FillInfo();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enablePrint)
            Print();
	}

    void Exit()
    {
        GameObject.FindObjectOfType<PlayerMove>().enabled = true;
        Camera.main.GetComponent<LookAround>().enabled = true;

        if (tChecked)
        {

            Debug.Log("fake true");
            passanger.GetComponent<MobPassagers>().t.tChecked = true;
            passanger.GetComponent<MobPassagers>().t.printPos = print.transform.position;
        }

        passanger = null;

        gameObject.SetActive(false);
        mainUIPanel.SetActive(true);
    }

    void Documents()
    {

    }

    void EnablePrint()
    {
        if (!enablePrint)
        {
            printButton.transform.GetChild(0).GetComponent<Text>().text = "Wait";
            printTool.SetActive(true);
            enablePrint = true;
        }
        else
        {
            printButton.transform.GetChild(0).GetComponent<Text>().text = "Approve Ticket";
            printTool.SetActive(false);
            enablePrint = false;
        }
    }

    void CheckPlayer()
    {
        GameObject.FindObjectOfType<LookAround>().money += 50;
    }

    void Print()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<Canvas>().transform as RectTransform, 
                                                                Input.mousePosition,
                                                                transform.parent.GetComponent<Canvas>().worldCamera, out pos);
        //print.transform.position = transform.parent.GetComponent<Canvas>().transform.TransformPoint(pos);
        printPos = transform.parent.GetComponent<Canvas>().transform.TransformPoint(pos);
        printTool.transform.position = printPos;
        if (Input.GetMouseButtonDown(0) && GoodForPrint(printPos))
        {
            print.transform.position = printPos;
            printButton.transform.GetChild(0).GetComponent<Text>().text = "Approve Ticket";
            printButton.gameObject.SetActive(false);
            printTool.SetActive(false);
            CheckPlayer();
            enablePrint = false;
            tChecked = true;
        }
    }

    bool GoodForPrint(Vector3 position)
    {
        if (position.x < 33 && position.x > -17.3f && position.y > 513 && position.y < 547)
            return true;
        return false;
    }
}
