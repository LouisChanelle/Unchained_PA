using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyKiller : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;
    private Color colorStart;
    private Color colorEnd = Color.yellow + Color.red;
    private Renderer renderer;
    public int diffKills = 0;
    public  int countKills;
    public Text CounterOfKill;
    private Text Score;
    private float randDrop;
    private float randProb;
    public GameObject poLife;
    public GameObject poEnergy;
    public bool activateDrop = true;
    private Vector3 offsetSpawnPo;
    
    [SerializeField] private GameObject can;
    
    
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        colorStart = renderer.material.GetColor($"Color");

        countKills = objectPooling.SharedInstance.amountToPool;
        
        //CounterOfKill = can.GetComponent<Text>();
        
        CounterOfKill.text = countKills.ToString();

        offsetSpawnPo = new Vector3(0f, -1f, 0f);
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
        countKills = GameObject.FindGameObjectWithTag("pwrAttack").GetComponent<powerAttack>().countKills;
        float lerp = Mathf.PingPong(Time.time, 0.1f) / 0.1f;
        if (Input.GetKey(KeyCode.Mouse0))
        {
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
                //Destroy(t);
                randDrop = UnityEngine.Random.value;
                randProb = UnityEngine.Random.value;

                if (activateDrop)
                {
                    if (randDrop < 0.5f && randProb < 0.05f)
                    {
                        Instantiate(poLife, t.transform);
                    }
                    else if (randDrop > 0.5f && randDrop < 0.05f)
                    {
                        Instantiate(poEnergy, t.transform);
                    }
                }

                t.SetActive(false);
                nearEnemy.Remove(t);
            }
        }

        else if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            renderer.material.color = colorStart;
        }
    }
}
