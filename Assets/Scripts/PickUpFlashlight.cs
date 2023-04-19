using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour, iInteractable
{
    public GameObject FlashLightOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    public void Interact()
    {
                this.gameObject.SetActive(false);
                FlashLightOnPlayer.SetActive(true);
    }
}
