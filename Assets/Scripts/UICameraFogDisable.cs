using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraFogDisable : MonoBehaviour {

    bool fog;
     
    void Start()
    {
        fog = RenderSettings.fog;
    }

    void OnPreRender()
    {
        RenderSettings.fog = false;
    }

    void OnPostRender()
    {
        RenderSettings.fog = fog;
    }
}
