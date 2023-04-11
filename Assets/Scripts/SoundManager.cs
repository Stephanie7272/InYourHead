using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip flatline;
    public AudioClip heartBeat;
    public AudioClip heartBeat2;
    public AudioClip breathing;

    public AudioSource audioSource;
    public HeartRateController heartRateController;

    public int previousStage;
    public int currentStage = 0;

    private void Awake()
    {
        heartRateController = heartRateController.GetComponent<HeartRateController>();
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(heartRateController.hr_UI.alpha > 0)
        {
            currentStage = 1;
        }
        if (heartRateController.flatlined == true)
        {
            currentStage = 2;
        }
        if(heartRateController.idle == true)
        {
            currentStage = 3;
        }
    }

    public void HeartBeat()
    {
        if(currentStage != previousStage)
        {
            if (currentStage == 1)
            {
                PlaySound(heartBeat);
            }
            else if (currentStage == 2)
            {
                PlaySound(flatline);
            }
            else if (currentStage == 3)
            {
                audioSource.Stop();
            }
        }
        previousStage = currentStage;
        
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
