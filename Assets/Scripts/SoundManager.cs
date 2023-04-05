using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip idleHeartBeat;
    public AudioClip mediumHeartBeat;
    public AudioClip fastHeartBeat;
    public AudioClip flatline;

    public AudioSource audioSource;
    public HeartRateController heartRateController;

    int previousStage;
    int currentStage = 1;

    private void Awake()
    {
        heartRateController = heartRateController.GetComponent<HeartRateController>();
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(heartRateController.currentHeartRate > 69 && heartRateController.currentHeartRate < 110)
        {
            currentStage = 1;
        }
        else if (heartRateController.currentHeartRate > 110 && heartRateController.currentHeartRate < 155)
        {
            currentStage = 2;
        }
        else if(heartRateController.currentHeartRate > 155 && heartRateController.currentHeartRate < 255)
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
                PlaySound(idleHeartBeat);
            }
            else if (currentStage == 2)
            {
                PlaySound(mediumHeartBeat);
            }
            else if (currentStage == 3)
            {
                PlaySound(fastHeartBeat);
            }
        }
        previousStage = currentStage;
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
