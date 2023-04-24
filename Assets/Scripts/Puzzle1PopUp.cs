using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle1PopUp : MonoBehaviour
{

    public GameObject canvas;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject key;
    public Button close1;


    void Start()
    {
        canvas.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        Button close = close1.GetComponent<Button>();
        close.onClick.AddListener(TaskOnClose);
    }

    void OnMouseDown()
    {
        canvas.SetActive(true);
        image1.SetActive(true);
        image2.SetActive(true);
        image3.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
    }

    void TaskOnClose()
    {
        canvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
    }

}