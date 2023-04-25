using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoPickUp : MonoBehaviour
{
    private bool isPickedUp = false;
    public GameObject CanvasPuzzleTwo;
    public GameObject writing;

  void Start()
  {
        CanvasPuzzleTwo.SetActive(false);
        isPickedUp = false;
        writing.SetActive(false);
    }
  void OnMouseDown()
  {
    if (isPickedUp)
    {
        writing.SetActive(true);

        CanvasPuzzleTwo.SetActive(false);
        isPickedUp = false;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
    }
    else
    {
        CanvasPuzzleTwo.SetActive(true);
        isPickedUp = true;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
    }
  }
}
