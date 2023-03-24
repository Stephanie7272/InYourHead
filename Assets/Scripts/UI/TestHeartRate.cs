using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeartRate : MonoBehaviour
{

    private HeartRateController hr_Controller;

    // Start is called before the first frame update
    void Awake()
    {
        hr_Controller = FindObjectOfType<HeartRateController>().GetComponent<HeartRateController>();
    }

    private void OnMouseEnter()
    {
        hr_Controller.isIncreasing = true;
    }

    private void OnMouseOver()
    {
        hr_Controller.fadingIn = true;
        hr_Controller.FadeIn();
    }

    private void OnMouseExit()
    {
        hr_Controller.fadingIn = false;
        hr_Controller.isIncreasing= false;
        StartCoroutine(hr_Controller.FadeOut());
    }

}
