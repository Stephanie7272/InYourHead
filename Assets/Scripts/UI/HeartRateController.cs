using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

public class HeartRateController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI hr_UI;
    [SerializeField] TextMeshProUGUI hr_Text;
    [SerializeField] int hr_Current;
    [SerializeField] int hr_Min;
    [SerializeField] int hr_Max;
    int hr_UpdateInt;
    int hr_idleMin;
    int hr_idleMax;
    [SerializeField] int hr_UpdateMax = 8;
    [SerializeField] int hr_UpdateMin = 7;
    [SerializeField] float hr_UpdateSpeed;
    [SerializeField] float fadeSpeed;

    [SerializeField] int callCounter = 0;

    private void Awake()
    {
        hr_UI.alpha = 1;
        hr_Text.alpha = 1;
        hr_idleMin = hr_Min - 5;
        hr_idleMax = hr_Min + 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Decrease());
    }

    public void UpdateUI()
    {
        hr_UI.text = hr_Current.ToString();
    }

    public IEnumerator Increase()
    {
        callCounter++;
        hr_UpdateInt = UnityEngine.Random.Range(hr_UpdateMin, hr_UpdateMax) * callCounter;
        hr_Current += hr_UpdateInt;
        if(hr_Current > hr_Max)
        {
            hr_Current = hr_Max;
        }
        UpdateUI();
        yield return new WaitForSeconds(hr_UpdateSpeed);
        if(hr_Current < hr_Max)
        {
            StartCoroutine(Increase());
        }
        else if(hr_Current == hr_Max)
        {
            Death();
        }
    }

    public IEnumerator Decrease()
    {
        if(callCounter > 1)
        {
            callCounter--;
        }
        hr_UpdateInt = UnityEngine.Random.Range(hr_UpdateMin, hr_UpdateMax) * callCounter * 2;
        hr_Current -= hr_UpdateInt;
        if (hr_Current < hr_Min)
        {
            hr_Current = hr_Min;
        }
        UpdateUI();
        yield return new WaitForSeconds(hr_UpdateSpeed);
        if (hr_Current > hr_Min)
        {
            StartCoroutine(Decrease());
        }
        else if(hr_Current == hr_Min)
        {
            callCounter = 0;
            StartCoroutine(Idle());
        }
    }

    public IEnumerator Idle()
    {
        hr_Current = UnityEngine.Random.Range(hr_idleMin, hr_idleMax);
        UpdateUI();
        yield return new WaitForSeconds(hr_UpdateSpeed);
        if(callCounter == 0)
        {
            StartCoroutine(Idle());
        }
    }

    public void Death()
    {
        hr_Current = 0;
        UpdateUI();
    }

    public IEnumerator FadeIn()
    {
        hr_UI.alpha += 0.01f;
        hr_Text.alpha += 0.01f;
        yield return new WaitForSeconds(fadeSpeed);
        if(hr_UI.alpha < 1 || hr_Text.alpha < 1)
        {
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeOut()
    {
        hr_UI.alpha -= 0.01f;
        hr_Text.alpha -= 0.01f;
        yield return new WaitForSeconds(fadeSpeed);
        if (hr_UI.alpha < 1 || hr_Text.alpha < 1)
        {
            StartCoroutine(FadeOut());
        }
    }




}
