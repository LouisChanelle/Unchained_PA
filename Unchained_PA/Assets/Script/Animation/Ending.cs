using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public bool isFinish;
    public Canvas endCan;
    public GameObject player;
    private Animation anim;
    private bool animing;

    private void Start()
    {
        endCan.enabled = false;
        isFinish = false;
        anim = player.GetComponent<Animation>();
        animing = false;
    }


    private void Update()
    {
        if (isFinish == true)
        {
            Debug.Log(isFinish + " is finish is True");
            if (player.GetComponent<PlayerMovement>().isGrounding() == true)
            {
                if (animing == false)
                {
                    player.GetComponent<PlayerMovement>().bossDie();
                    anim.Play("Salto");
                    animing = true;
                }

                if (!anim.isPlaying && animing)
                {
                    Time.timeScale = 0.0f;

                    endCan.enabled = true;
                }
            }
        }
    }
    
    public void End()
    {
        if (isFinish == false)
        {
            isFinish = true;
        }
    }
}
