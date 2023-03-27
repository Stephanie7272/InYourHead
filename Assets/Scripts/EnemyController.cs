using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    public 

    void Start()
    {
        
        current = 0;
    }


    void Update()
    {
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
