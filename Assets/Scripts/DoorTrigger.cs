using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorV3 = null;

    [SerializeField] private bool openTrigger = false;

    public AudioSource creak;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                creak.Play();
                doorV3.Play("DoorOpenV3", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
