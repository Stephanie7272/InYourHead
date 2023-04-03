using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrigger : MonoBehaviour
{
    [SerializeField] private Animator DoorV3 = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Example");
IEnumerator Example()
{
     if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                
                
                    yield return new WaitForSeconds(5);
                    DoorV3.Play("OpenDoorV3", 0 , 0.0f);
                    gameObject.SetActive(false);
                
                
            }
        }
}
       
    }
}
