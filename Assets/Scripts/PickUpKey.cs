using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public Component doorOpenObject;
    public GameObject GetKeyObject;
    public GameObject PickUpText;

    void Start()
    {
        PickUpText.SetActive(false);
    }


    // Start is called before the first frame update
    void OnTriggerStay()
    {
        PickUpText.SetActive(true);

        if(Input.GetKey(KeyCode.E))
        {
            doorOpenObject.GetComponent<BoxCollider>().enabled = true;
            GetKeyObject.SetActive(false);
        }
    }
}
