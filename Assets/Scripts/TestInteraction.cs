using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour, iInteractable
{

    public void Interact()
    {
        transform.Translate(transform.right);
    }
}
