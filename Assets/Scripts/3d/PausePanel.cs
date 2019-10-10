using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {

    public Button buttonReset;
    public Button buttonQuit;

	// Use this for initialization
	void Start ()
    {
        buttonQuit.onClick.AddListener(Quit);
        buttonReset.onClick.AddListener(Reset);
	}

    void Quit()
    {
        Application.Quit();
    }

    void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
