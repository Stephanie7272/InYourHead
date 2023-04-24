using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4Piece : MonoBehaviour
{
    public FirstPersonController player;
    public GameObject puzzlePieceUI;
    public GameObject puzzlePieceTextUI;
    public GameObject fullPaperUI;
    public GameObject fullPaperBackUI;
    public GameObject fullPaperTextUI;
    private bool isViewing = false;
    private bool hasAllFour = false;
    private bool hasFlipped = false;


    // Start is called before the first frame update
    void Awake()
    {
        player = player.GetComponent<FirstPersonController>();
        puzzlePieceUI.SetActive(false);
        puzzlePieceTextUI.SetActive(false);
        fullPaperUI.SetActive(false);
        fullPaperBackUI.SetActive(false);
        fullPaperTextUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) <= 100 && isViewing == false)
        {
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            isViewing = true;
            player.paperScraps++;
            if (player.paperScraps < 4)
            {
                puzzlePieceUI.SetActive(true);
                puzzlePieceTextUI.SetActive(true);
            }
            else if (player.paperScraps == 4)
            {
                hasAllFour = true;
                fullPaperUI.SetActive(true);
                fullPaperTextUI.SetActive(true);
            }
        }
        else if (isViewing == true && hasAllFour == true && hasFlipped == false)
        {
            hasFlipped = true;
            fullPaperUI.SetActive(false);
            fullPaperTextUI.SetActive(false);
            fullPaperBackUI.SetActive(true);
        }
        else if(isViewing == true)
        {
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
            isViewing = false;
            puzzlePieceUI.SetActive(false);
            puzzlePieceTextUI.SetActive(false);
            fullPaperUI.SetActive(false);
            fullPaperTextUI.SetActive(false);
            fullPaperBackUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
