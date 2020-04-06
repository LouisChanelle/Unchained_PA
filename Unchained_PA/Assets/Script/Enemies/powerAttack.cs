using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class powerAttack : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;
    private Color colorStart;
    private Color colorEnd = Color.yellow + Color.red;
    private Renderer renderer;
    private int diffKills = 0;
    private  int countKills;
    private Text CounterOfKill;
    public float disp = 100f;
    private bool regen;
    private float cd = 2.5f;
    private float regenStart;
    
    public static powerAttack SharedInstance;
    
    [SerializeField] private GameObject can;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        colorStart = renderer.material.GetColor($"Color");

        countKills = objectPooling.SharedInstance.amountToPool;
        
        CounterOfKill = can.GetComponent<Text>();
        CounterOfKill.text = countKills.ToString();

        regen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"enemy"))
        { 
            nearEnemy.Add(other.gameObject);
            diffKills = diffKills + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag($"enemy"))
        {
            nearEnemy.Remove(other.gameObject);
            diffKills = diffKills - 1;
        }
    }

    private void Update()
    {
        float lerp = Mathf.PingPong(Time.time, 0.1f) / 0.1f;
        if (Input.GetKey(KeyCode.Mouse1) && disp > 7.5f && regen == false)
        {
            disp -= 75f * Time.deltaTime;
            renderer.material.color = Color.Lerp(renderer.material.GetColor($"Color"), colorEnd, lerp);
            
            foreach (GameObject t in nearEnemy)
            {
                if (diffKills > 0)
                {
                    if (countKills > 0)
                    {
                        countKills = countKills - 1;
                        CounterOfKill.text = countKills.ToString();
                    }
                    
                    diffKills = diffKills - 1;
                }
                t.SetActive(false);
                nearEnemy.Remove(t);
            }
        }

        else if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            renderer.material.color = colorStart;
        }

        disp += 25f * Time.deltaTime;
        
        if (disp > 100f)
        {
            disp = 100f;
        }

        if (disp <= 7.5f)
        {
            regen = true;
            regenStart = Time.time;
        }

        if (regen)
        {
            if (Time.time - regenStart >= cd)
            {
                regen = false;
            }
        }
    }
}
