using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{
    private float masterVolume;
    private GameObject optionsObj;

    private void Awake()
    {
        optionsObj = GameObject.Find("CanvasOptions");
        masterVolume = optionsObj.GetComponentInChildren<Slider>().value;
    }

    void ChangeVolume()
    {
        
    }
}
