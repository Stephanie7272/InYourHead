using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject FlashLightOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                FlashLightOnPlayer.SetActive(true);

            }
        }
    }
}
