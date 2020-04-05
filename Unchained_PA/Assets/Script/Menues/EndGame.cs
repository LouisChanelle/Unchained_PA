using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public enemyKiller EnemyKiller;
    private int GetCountKills;
    private Canvas WinCanvas;
    private Canvas CanvasCount;


    // Start is called before the first frame update
    void Awake()
    {
        EnemyKiller= GetComponent<enemyKiller>();
    }
    
    void Start()
    {
        WinCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();

    }

    // Update is called once per frame
   
    void Update()
    {
        GetCountKills = EnemyKiller.countKills;
        
        Debug.Log(Time.time);
        
        if (GetCountKills == 1)
        {
            WinCanvas.enabled = true;
        }

        if (GetCountKills == 0)
        {
            WinCanvas.enabled = false;
        }
        
    }
}
