using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class energyBar : MonoBehaviour
{
    private Vector2 pos = new Vector2(40, 540);

    private Vector2 size = new Vector2(200, 16);

    private powerAttack _mana;
    
    private float barFill = 0.8f;

    private string barText;

    public GUIStyle progress_empty;

    public GUIStyle progress_full;

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), barText, progress_empty);
        
        GUI.BeginGroup(new Rect(0, 0, size.x * barFill, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), barText, progress_full);
        
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {
        barFill = _mana.disp;
    }
}
