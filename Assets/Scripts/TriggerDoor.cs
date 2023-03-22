using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
  [SerializeField] private Animator DoorV1 = null;

    [SerializeField] private bool OpenTrigger = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OpenTrigger)
            {
                DoorV1.Play("OpenDoorV1", 0, 0.0f);
                gameObject.SetActive(false);
            }

        }
    }
}
