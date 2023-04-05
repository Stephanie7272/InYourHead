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
    public AudioSource audioSource2;
    public HeartRateController heartRateController;

    int previousStage;
    int currentStage = 1;

    private void Awake()
    {
        heartRateController = heartRateController.GetComponent<HeartRateController>();
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(heartRateController.isIncreasing == true)
        {
            currentStage = 1;
        }
        else if (heartRateController.flatlined == true)
        {
            currentStage = 2;
        }
        else if(heartRateController.isIncreasing == false && heartRateController.hr_UI.alpha > 0)
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
                PlaySound2(breathing);
            }
            else if (currentStage == 2)
            {
                PlaySound(flatline);
                audioSource2.Stop();
            }
            else if (currentStage == 3)
            {
                PlaySound(heartBeat2);
                audioSource2.Stop();
            }
        }
        previousStage = currentStage;
        
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void PlaySound2(AudioClip clip)
    {
        audioSource2.clip = clip;
        audioSource2.Play();
    }

}
