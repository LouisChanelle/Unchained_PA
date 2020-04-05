using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyKiller : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;
    private Color colorStart;
    private Color colorEnd = Color.yellow + Color.red;
    private Renderer renderer;
    private int diffKills = 0;
    public  int countKills;
    private Text CounterOfKill;
    
    [SerializeField] private GameObject can;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        colorStart = renderer.material.GetColor($"Color");
        
        CounterOfKill = can.GetComponent<Text>();
        CounterOfKill.text = countKills.ToString();
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            renderer.material.color =
                Color.Lerp(renderer.material.GetColor($"Color"), colorEnd, lerp);
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
                //Destroy(t);
                t.SetActive(false);
            }

        }

        else if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            renderer.material.color = colorStart;
        }
    }
}
