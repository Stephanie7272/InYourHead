using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSwitch : MonoBehaviour
{
    [SerializeField] GameObject LightSwitch;
    public bool FlashLightActive = false;
    
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        LightSwitch.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashLightActive == false)
            {
                LightSwitch.gameObject.SetActive(true);
                FlashLightActive = true;
                clickSound.Play();
            }

            else
            {
                LightSwitch.gameObject.SetActive(false);
                FlashLightActive = false;
                clickSound.Play();

            }
        }
    }
}
