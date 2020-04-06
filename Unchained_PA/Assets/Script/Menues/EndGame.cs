using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private int GetCountKills;
    private Canvas WinCanvas;
    private Canvas CanvasCount;
    
    void Start()
    {
        WinCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();

    }

    // Update is called once per frame
   
    void Update()
    {
        GetCountKills = objectPooling.SharedInstance.amountToPool;
        
        
        if (GetCountKills <= 10)
        {
            WinCanvas.enabled = true;
        }

        if (GetCountKills == 0)
        {
            WinCanvas.enabled = false;
        }
        
    }
}
