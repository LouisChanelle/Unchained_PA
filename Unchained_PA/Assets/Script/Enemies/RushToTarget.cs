using UnityEngine;

public class RushToTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    private GameObject _gameObject;
    private Transform _transform;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _transform = _gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        target = _transform;
        if (target == null)
        {
            return;
        }

        transform.LookAt(target);

        var direction = target.position - transform.position;
        direction.x = 0;
        direction = direction.normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameObject.CompareTag("boss"))
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            o.transform.position = _transform.position;
        }
    }
}