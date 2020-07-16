using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerAttack : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;
    private Color colorStart;
    private Color colorEnd = Color.yellow + Color.red;
    private Renderer renderer;
    private int diffKills = 0;
    public  int countKills;
    public Text CounterOfKill;
    public float disp = 100f;
    private bool regen;
    private float cd = 1.5f;
    private float regenStart;
    private float randDrop;
    private float randProb;
    public GameObject poLife;
    public GameObject poEnergy;
    public bool activateDrop = false;
    public Text ScoreText;
    
    
    private float cost = 75f;
    private float regenRate = 25f;
    
    public static powerAttack SharedInstance;
    private static int scrSh;

    public Image Mana;
    
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
        
        //CounterOfKill = can.GetComponent<Text>();
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
        countKills = GameObject.FindGameObjectWithTag("lightAtt").GetComponent<enemyKiller>().countKills;
        
        float lerp = Mathf.PingPong(Time.time, 0.1f) / 0.1f;
        
        if (Input.GetKey(KeyCode.Mouse1) && disp > 7.5f && regen == false)
        {
            disp -= cost * Time.deltaTime;
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

                if (activateDrop)
                {
                    if (randDrop < 0.5f && randProb > 0.05f)
                    {
                        Instantiate(poLife, t.transform);
                    }
                    else if (randDrop > 0.5f && randProb > 0.05f)
                    {
                        Instantiate(poEnergy, t.transform);
                    }
                }

                t.SetActive(false);
                
                enemyKiller.scored++;
                ScoreText.text = enemyKiller.scored.ToString();

                nearEnemy.Remove(t);
            }
        }

        else if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            renderer.material.color = colorStart;
        }

        disp += regenRate * Time.deltaTime;
        
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

        Debug.Log(disp);
        Mana.fillAmount = disp / 100f;
    }
}
