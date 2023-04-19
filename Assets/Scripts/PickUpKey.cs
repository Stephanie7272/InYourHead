using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour, iInteractable
{
    public Component doorOpenObject;
    public GameObject GetKeyObject;
    public GameObject PickUpText;
    public GameObject Enemies;

    void Start()
    {
        PickUpText.SetActive(false);
        Enemies.SetActive(false);
    }


    // Start is called before the first frame update
    public void Interact()
    {
            doorOpenObject.GetComponent<BoxCollider>().enabled = true;
            GetKeyObject.SetActive(false);
            Enemies.SetActive(true);
    }
}
