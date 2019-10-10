using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDButton : MonoBehaviour
{
    public int dimension;

    public void ChooseDimension()
    {
        switch (dimension)
        {
            case 2/*d*/:
                {
                    SceneManager.LoadScene(1);
                    break;
                }
            case 3/*d*/:
                {
                    SceneManager.LoadScene(2);
                    break;
                }
        }
    }
}
