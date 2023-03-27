using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    public GameObject Enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }

    }
}
