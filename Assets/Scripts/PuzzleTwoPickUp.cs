using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoPickUp : MonoBehaviour, iInteractable
{
  private bool isPickedUp = false;
  public GameObject CanvasPuzzleTwo;

  void Start()
  {
        CanvasPuzzleTwo.SetActive(false);
        isPickedUp = false;
  }
  public void Interact()
  {
    if (isPickedUp)
    {
        CanvasPuzzleTwo.SetActive(false);
        isPickedUp = false;
    }
    else
    {
        CanvasPuzzleTwo.SetActive(true);
        isPickedUp = true;
    }
  }
}
