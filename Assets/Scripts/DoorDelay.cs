using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDelay : MonoBehaviour
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
                StartCoroutine(Example());
            }
        }
    }

    IEnumerator Example()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            creak.Play();
            doorV3.Play("DoorOpenV3", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }
}
