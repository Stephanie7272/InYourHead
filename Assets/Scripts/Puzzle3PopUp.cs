using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3PopUp : MonoBehaviour
{
    public GameObject CanvasPuzzleThree;
    public GameObject Cunningham;
    public GameObject Martinez;
    public GameObject Hughes;
    public GameObject Jenkins;
    public GameObject Graves;
    public GameObject Brown;

    public Button LeftArrow;
    public Button RightArrow;
    public Button Close;

    public int count;

    void Start()
    {
        CanvasPuzzleThree.SetActive(false);
        Cunningham.SetActive(false);
        Martinez.SetActive(false);
        Hughes.SetActive(false);
        Jenkins.SetActive(false);
        Graves.SetActive(false);
        Brown.SetActive(false);

        Button leftArw = LeftArrow.GetComponent<Button>();
        Button rightArw = RightArrow.GetComponent<Button>();
        Button close = Close.GetComponent<Button>();
        leftArw.onClick.AddListener(TaskOnClickLeft);
        rightArw.onClick.AddListener(TaskOnClickRight);
        close.onClick.AddListener(TaskOnClose);

        /*GameObject cunningham = Cunningham.GetComponent<GameObject>();
        GameObject martinez = Martinez.GetComponent<GameObject>();
        GameObject hughes = Hughes.GetComponent<GameObject>();
        GameObject jenkins = Jenkins.GetComponent<GameObject>();
        GameObject graves = Graves.GetComponent<GameObject>();
        GameObject brown = Brown.GetComponent<GameObject>();*/

        count = 1;
    }
    void OnMouseDown()
    {
        CanvasPuzzleThree.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
    }

    private void Update()
    {
        if(count == 1)
        {
            Cunningham.SetActive(true);
            Martinez.SetActive(false);
        }
        else if(count == 2)
        {
            Cunningham.SetActive(false);
            Martinez.SetActive(true);
            Hughes.SetActive(false);
        }
        else if (count == 3)
        {
            Martinez.SetActive(false);
            Hughes.SetActive(true);
            Jenkins.SetActive(false);
        }
        else if (count == 4)
        {
            Hughes.SetActive(false);
            Jenkins.SetActive(true);
            Graves.SetActive(false);
        }
        else if (count == 5)
        {
            Jenkins.SetActive(false);
            Graves.SetActive(true);
            Brown.SetActive(false);
        }
        else if (count == 6)
        {
            Graves.SetActive(false);
            Brown.SetActive(true);
        }

    }

    void TaskOnClickLeft()
    {
        if(count > 1)
            count--;
    }

    void TaskOnClickRight()
    {
        if(count < 6)
            count++;
    }

    void TaskOnClose()
    {
        CanvasPuzzleThree.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
    }
}