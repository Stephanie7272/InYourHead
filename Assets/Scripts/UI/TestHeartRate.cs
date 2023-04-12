using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeartRate : MonoBehaviour
{

    private HeartRateController hr_Controller;
    public FlashLightSwitch flashlight;
    [SerializeField] GameObject mesh;

    // Start is called before the first frame update
    void Awake()
    {
        hr_Controller = FindObjectOfType<HeartRateController>().GetComponent<HeartRateController>();
        flashlight = FindObjectOfType<FlashLightSwitch>().GetComponent<FlashLightSwitch>();
        mesh.SetActive(false);
    }

    private void OnMouseEnter()
    {
        if(flashlight.FlashLightActive == true)
        {
            hr_Controller.isIncreasing = true;
            mesh.SetActive(true);
        }
        
    }

    private void OnMouseOver()
    {
        if(flashlight.FlashLightActive == true)
        {
            hr_Controller.fadingIn = true;
            hr_Controller.FadeIn();
        }
        
    }

    private void OnMouseExit()
    {
        
            hr_Controller.fadingIn = false;
            hr_Controller.isIncreasing = false;
            StartCoroutine(hr_Controller.FadeOut());
            
        
        mesh.SetActive(false);

    }

}
