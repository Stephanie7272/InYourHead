using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource Whispers;
    public AudioSource Mute;
    
    [SerializeField] private bool openTrigger = false;

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                Mute.Stop();
                Whispers.Play();
            }
        }
    }
}
