using UnityEngine;

public class cameraOffset : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
