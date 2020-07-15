using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;
    private Color colorStart;
    private readonly Color colorEnd = Color.blue;
    private Renderer renderer;
    public float disp = 100f;
    private bool regen;
    private float cd = 1.5f;
    private float regenStart;
    private float cost = 75f;
    private float regenRate = 25f;

    public static Shield SharedInstance;
    
    [SerializeField] private GameObject can;

    public Image Energy;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        colorStart = renderer.material.GetColor($"Color");

        regen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"bullet"))
        { 
            nearEnemy.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag($"bullet"))
        {
            nearEnemy.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        float lerp = Mathf.PingPong(Time.time, 0.1f) / 0.1f;
        if (Input.GetKey(KeyCode.LeftShift) && disp > 7.5f && regen == false)
        {
            disp -= cost * Time.deltaTime;
            renderer.material.color = Color.Lerp(renderer.material.GetColor($"Color"), colorEnd, lerp);
            
            foreach (GameObject t in nearEnemy)
            {
                t.SetActive(false);
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

        Energy.fillAmount = disp / 100f;
    }
}
