using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public Component doorOpenObject;
    public GameObject GetKeyObject;
    public GameObject PickUpText;
    public GameObject Enemies;
    public GameObject OldDoor;
    public GameObject NewDoor;
    private AudioSource audioSource;

    public AudioClip CloseDoor;

    void Start()
    {
        PickUpText.SetActive(false);
        Enemies.SetActive(false);
        NewDoor.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void OnTriggerStay()
    {
        PickUpText.SetActive(true);

        if(Input.GetKey(KeyCode.E))
        {
            doorOpenObject.GetComponent<BoxCollider>().enabled = true;
            GetKeyObject.SetActive(true);
            Enemies.SetActive(true);
            Destroy(OldDoor);
            NewDoor.SetActive(true);
            transform.position = new Vector3(1000, 1000, 1000);
            audioSource.PlayOneShot(CloseDoor);
        }
    }
}
