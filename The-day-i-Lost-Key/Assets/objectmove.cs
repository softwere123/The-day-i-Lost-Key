using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float newX = startX + Mathf.Sin(Time.time * speed) * range;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}