using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using Unity.VisualScripting;
using UnityEngine.Profiling;

public class HeartRateController : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI hr_UI;
    [SerializeField] TextMeshProUGUI hr_Text;
    public int currentHeartRate;
    [SerializeField] int minHeartRate;
    [SerializeField] int maxHeartRate;
    int hr_UpdateInt;
    int hr_idleMin;
    int hr_idleMax;
    [SerializeField] int maxUpdateInterval;
    [SerializeField] int minUpdateInterval;
    [SerializeField] float monitorUpdateSpeed;
    [SerializeField] float fadeSpeed;
    public bool fadingIn;
    public bool isIncreasing;
    public bool flatlined;
    public bool idle;
    [SerializeField] int callCounter = 0;
    float time;

    public SoundManager soundManager;


    //public Volume Volume;
    //public bool enableVig;
    //public bool overrideVig;
    #endregion

    private void Awake()
    {
        hr_UI.alpha = 0;
        hr_Text.alpha = 0;
        hr_idleMin = minHeartRate - 5;
        hr_idleMax = minHeartRate + 5;

        flatlined = false;
        idle = false;
        soundManager = soundManager.GetComponent<SoundManager>();
    }

    //private void Start()
    //{
    //    VolumeProfile profile = Volume.sharedProfile;
    //    if (!profile.TryGet<Vignette>(out var vig))
    //    {
    //        vig = profile.Add<Vignette>(false);
    //    }

    //    vig.intensity.Override(0.5f);


    //}

    private void Update()
    {
        if(flatlined == false)
        {
            time += Time.deltaTime;
            if (time > monitorUpdateSpeed)
            {
                time -= monitorUpdateSpeed;
                if (isIncreasing == true)
                {
                    if (currentHeartRate == maxHeartRate)
                    {
                        Flatline();
                    }
                    else
                    {
                        Increase();
                    }
                }
                else if (isIncreasing == false)
                {
                    if (callCounter == 0)
                    {
                        Idle();
                    }
                    else
                    {
                        Decrease();
                    }
                }
                UpdateUI();
                soundManager.HeartBeat();
            }
        }
        else if(flatlined == true)
        {
            soundManager.HeartBeat();
        }
        
    }

    private void Flatline()
    {
        flatlined = true;
        currentHeartRate = 0;
    }

    private void UpdateUI()
    {
        hr_UI.text = currentHeartRate.ToString();
    }
    
    private void Increase()
    {
        idle = false;
        callCounter++;
        hr_UpdateInt = UnityEngine.Random.Range(minUpdateInterval, maxUpdateInterval) * callCounter;
        currentHeartRate += hr_UpdateInt;
        if (currentHeartRate > maxHeartRate)
        {
            currentHeartRate = maxHeartRate;
        }
    }
    
    private void Decrease()
    {
        idle = false;
        if (callCounter > 1)
        {
            callCounter--;
        }
        hr_UpdateInt = UnityEngine.Random.Range(minUpdateInterval, maxUpdateInterval) * callCounter/2;
        currentHeartRate -= hr_UpdateInt;
        if (currentHeartRate < minHeartRate)
        {
            currentHeartRate = minHeartRate;
            callCounter = 0;
        }
    }
   
    private void Idle()
    {
        idle = true;
        currentHeartRate = UnityEngine.Random.Range(hr_idleMin, hr_idleMax);
    }

    public void FadeIn()
    {
        if (hr_UI.alpha < 1 && hr_Text.alpha < 1)
        {
            hr_UI.alpha += Time.deltaTime;
            hr_Text.alpha += Time.deltaTime;
        }
        
    }

    public IEnumerator FadeOut()
    {
        hr_UI.alpha -= 0.01f;
        hr_Text.alpha -= 0.01f;
        yield return new WaitForSeconds(fadeSpeed);
        if (hr_UI.alpha > 0 && hr_Text.alpha > 0 && fadingIn != true)
        {
            StartCoroutine(FadeOut());
        }
    }




}
